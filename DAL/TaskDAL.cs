using System;
using System.Collections.Generic;
using System.Data.SQLite;
using TimeSands.Entities.Enums;
using TimeSands.Entities.Models;

namespace TimeSands.DAL
{
    internal class TaskDAL : BaseDAL<TaskDAL>, IBaseCRUD<TaskModel>
    {
        public void Create(TaskModel task)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                task.CreateTime = DateTime.Now;

                command.CommandText = @"
INSERT INTO T_TASKS
    (jira_id, board_id, sprint_id, name, create_time, task_state_id)
VALUES
    (@jira_id, @board_id, @sprint_id, @name, @create_time, @task_state_id);
SELECT last_insert_rowid()
";
                command.Parameters.Add(new SQLiteParameter("@jira_id", task.JiraId));
                command.Parameters.Add(new SQLiteParameter("@board_id", task.BoardId));
                command.Parameters.Add(new SQLiteParameter("@sprint_id", task.SprintId));
                command.Parameters.Add(new SQLiteParameter("@name", task.Name));
                command.Parameters.Add(new SQLiteParameter("@create_time", task.CreateTime));
                command.Parameters.Add(new SQLiteParameter("@task_state_id", TaskState.Idle));

                try
                {
                    task.Id = Convert.ToInt32(command.ExecuteScalar());
                }
                catch
                {
                    throw new Exception($"Duplicate task name \"{task.Name}\"");
                }
            }
        }

        public void Delete(TaskModel task)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
UPDATE T_TASKS
SET
     task_state_id = @state_deleted
    ,update_time = CURRENT_TIMESTAMP
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", task.Id));
                command.Parameters.Add(new SQLiteParameter("@state_deleted", TaskState.Deleted));
                command.ExecuteNonQuery();
            }
        }

        private TaskModel TaskModelFromReader(SQLiteDataReader reader)
        {
            return new TaskModel
            {
                Id = Convert.ToInt32(reader["id"]),
                JiraId = StringOrNull(reader["jira_id"]),
                BoardId = Convert.ToInt32(reader["board_id"]),
                SprintId = Convert.ToInt32(reader["sprint_id"]),
                Name = reader["name"].ToString(),
                CreateTime = Convert.ToDateTime(reader["create_time"]),
                UpdateTime = DateTimeOrNull(reader["update_time"]),
                CloseTime = DateTimeOrNull(reader["close_time"]),
                State = (TaskState)Convert.ToInt32(reader["task_state_id"])
            };
        }

        public TaskModel Get(int id)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
SELECT *
FROM T_TASKS
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", id));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return TaskModelFromReader(reader);
                    }
                }
            }
            return null;
        }

        public ICollection<TaskModel> GetAll(params (string, object)[] filter)
        {
            List<TaskModel> models = new List<TaskModel>();
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
SELECT *
FROM T_TASKS
WHERE task_state_id <> @state_deleted
";
                ApplyFilter(command, filter);
                command.Parameters.Add(new SQLiteParameter("@state_deleted", TaskState.Deleted));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        models.Add(TaskModelFromReader(reader));
                    }
                }
            }
            return models;
        }

        public void Update(TaskModel task)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                task.UpdateTime = DateTime.Now;
                if (task.State == TaskState.Closed)
                {
                    task.CloseTime = task.UpdateTime;
                }

                command.CommandText = @"
UPDATE T_TASKS
SET 
     jira_id = CASE WHEN id = @id THEN @jira_id ELSE jira_id END
    ,sprint_id = CASE WHEN id = @id THEN @sprint_id ELSE sprint_id END
    ,board_id = CASE WHEN id = @id THEN @board_id ELSE board_id END
    ,name = CASE WHEN id = @id THEN @name ELSE name END
    ,task_state_id = CASE WHEN id = @id THEN @task_state_id ELSE @state_idle END
    ,update_time = @update_time
    ,close_time = CASE WHEN id = @id THEN @close_time ELSE close_time END
WHERE id = @id OR (@task_state_id = @state_active AND task_state_id = @state_active)
";
                command.Parameters.Add(new SQLiteParameter("@id", task.Id));
                command.Parameters.Add(new SQLiteParameter("@jira_id", task.JiraId));
                command.Parameters.Add(new SQLiteParameter("@board_id", task.BoardId));
                command.Parameters.Add(new SQLiteParameter("@sprint_id", task.SprintId));
                command.Parameters.Add(new SQLiteParameter("@name", task.Name));
                command.Parameters.Add(new SQLiteParameter("@update_time", task.UpdateTime));
                command.Parameters.Add(new SQLiteParameter("@close_time", DateTimeOrDBNull(task.CloseTime)));
                command.Parameters.Add(new SQLiteParameter("@task_state_id", task.State));
                command.Parameters.Add(new SQLiteParameter("@state_idle", TaskState.Idle));
                command.Parameters.Add(new SQLiteParameter("@state_active", TaskState.Active));
                command.ExecuteNonQuery();
            }
        }

        protected override void CreateTables(SQLiteCommand command)
        {
            //T_TASK_STATE
            command.CommandText = @"
CREATE TABLE T_TASK_STATE
(
    id INTEGER PRIMARY KEY NOT NULL,
    name TEXT(160) NOT NULL UNIQUE
)";
            command.ExecuteNonQuery();

            //T_TASKS
            command.CommandText = @"
CREATE TABLE T_TASKS
(
    id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    jira_id TEXT(20) DEFAULT NULL,
    board_id INTEGER NOT NULL,
    sprint_id INTEGER NOT NULL,
    name TEXT(160) NOT NULL UNIQUE COLLATE NOCASE,
    create_time TIMESTAMP NOT NULL,
    update_time TIMESTAMP DEFAULT NULL,
    close_time TIMESTAMP DEFAULT NULL,
    task_state_id INTEGER NOT NULL,

    FOREIGN KEY(board_id) REFERENCES T_BOARDS(id),
    FOREIGN KEY(sprint_id) REFERENCES T_SPRINTS(id),
    FOREIGN KEY(task_state_id) REFERENCES T_TASK_STATE(id)
)";
            command.ExecuteNonQuery();
        }

        protected override void CreateTablesData(SQLiteCommand command)
        {
            InsertStateData<TaskState>(command, "T_TASK_STATE");
        }
    }
}
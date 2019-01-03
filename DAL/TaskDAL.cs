using System.Collections.Generic;
using System.Data.SQLite;
using TimeSands.Entities.Enums;
using TimeSands.Entities.Models;

namespace TimeSands.DAL
{
    internal class TaskDAL : BaseDAL<TaskDAL>, IBaseCRUD<TaskModel>
    {
        public void Create(TaskModel model)
        {
            //id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
            //jira_id TEXT(20) DEFAULT NULL,
            //name TEXT(160) NOT NULL,
            //create_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
            //update_time TIMESTAMP DEFAULT NULL,
            //close_time TIMESTAMP DEFAULT NULL,
            //task_state_id INTEGER NOT NULL,

//            using (SQLiteCommand command = new SQLiteCommand(Connection))
//            {
//                command.CommandText = @"
//INSERT INTO T_TASKS
//    (jira_id, name, sprint_state_id)
//VALUES
//    (@jira_id, @name, @sprint_state_id);
//SELECT last_insert_rowid()";

//                command.Parameters.Add(new SQLiteParameter("@jira_id", sprint.JiraId));
//                command.Parameters.Add(new SQLiteParameter("@name", sprint.Name));
//                command.Parameters.Add(new SQLiteParameter("@sprint_state_id", SprintState.Available));

//                try
//                {
//                    sprint.Id = Convert.ToInt32(command.ExecuteScalar());
//                }
//                catch
//                {
//                    throw new Exception($"Duplicate sprint name \"{sprint.Name}\"");
//                }
//            }
        }

        public void Delete(TaskModel model)
        {
            throw new System.NotImplementedException();
        }

        public TaskModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<TaskModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(TaskModel model)
        {
            throw new System.NotImplementedException();
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
    sprint_id INTEGER NOT NULL,
    name TEXT(160) NOT NULL UNIQUE COLLATE NOCASE,
    create_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    update_time TIMESTAMP DEFAULT NULL,
    close_time TIMESTAMP DEFAULT NULL,
    task_state_id INTEGER NOT NULL,

    FOREIGN KEY(sprint_id) REFERENCES T_SPRINTS(id),
    FOREIGN KEY(task_state_id) REFERENCES T_TASK_STATE(id)
)";
            command.ExecuteNonQuery();

            //T_TASK_RECORD_STATE
            command.CommandText = @"
CREATE TABLE T_TASK_RECORD_STATE
(
    id INTEGER PRIMARY KEY NOT NULL,
    name TEXT(160) NOT NULL UNIQUE
)";
            command.ExecuteNonQuery();

            //T_TASK_RECORD
            command.CommandText = @"
CREATE TABLE T_TASK_RECORD
(
    id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    task_id INTEGER NOT NULL,
    start_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    end_time TIMESTAMP DEFAULT NULL,
    record_state_id INTEGER NOT NULL,

    FOREIGN KEY(task_id) REFERENCES T_TASKS(id),
    FOREIGN KEY(record_state_id) REFERENCES T_TASK_RECORD_STATE(id)
)";
            command.ExecuteNonQuery();
        }

        protected override void CreateTablesData(SQLiteCommand command)
        {
            InsertStateData<TaskState>(command, "T_TASK_STATE");
            InsertStateData<TaskRecordState>(command, "T_TASK_RECORD_STATE");
        }
    }
}
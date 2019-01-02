using System;
using System.Collections.Generic;
using System.Data.SQLite;
using TimeSands.Entities.Enums;
using TimeSands.Helpers;

namespace TimeSands.DAL
{
    internal class TaskDAL : BaseDAL<TaskDAL>
    {
        private void CreateTables(SQLiteCommand command)
        {
            //T_SPRINT_STATE
            command.CommandText = @"
CREATE TABLE T_SPRINT_STATE
(
    id INTEGER PRIMARY KEY NOT NULL,
    name TEXT(160) NOT NULL UNIQUE
)";
            command.ExecuteNonQuery();

            //T_SPRINTS
            command.CommandText = @"
CREATE TABLE T_SPRINTS
(
    id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    jira_id TEXT(20) DEFAULT NULL,
    name TEXT(160) NOT NULL,
    create_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    update_time TIMESTAMP DEFAULT NULL,
    sprint_state_id INTEGER NOT NULL,

    FOREIGN KEY(sprint_state_id) REFERENCES T_SPRINT_STATE(id)
)";
            command.ExecuteNonQuery();

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
    name TEXT(160) NOT NULL,
    create_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    update_time TIMESTAMP DEFAULT NULL,
    close_time TIMESTAMP DEFAULT NULL,
    task_state_id INTEGER NOT NULL,

    FOREIGN KEY(task_state_id) REFERENCES T_TASK_STATE(id)
)";
            command.ExecuteNonQuery();

            //T_TASK_EVENT_STATE
            command.CommandText = @"
CREATE TABLE T_TASK_EVENT_STATE
(
    id INTEGER PRIMARY KEY NOT NULL,
    name TEXT(160) NOT NULL UNIQUE
)";
            command.ExecuteNonQuery();

            //T_TASK_EVENT
            command.CommandText = @"
CREATE TABLE T_TASK_EVENT
(
    id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    task_id INTEGER NOT NULL,
    start_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    stop_time TIMESTAMP DEFAULT NULL,
    event_state_id INTEGER NOT NULL,

    FOREIGN KEY(task_id) REFERENCES T_TASKS(id),
    FOREIGN KEY(event_state_id) REFERENCES T_TASK_EVENT_STATE(id)
)";
            command.ExecuteNonQuery();
        }

        private void CreateTablesData(SQLiteCommand command)
        {
            //Insert StateData
            void CreateStateData<T>(string tableName)
            {
                command.CommandText = $@"
INSERT INTO {tableName}
    (id, name)
VALUES
    (@id, @name)";
                IEnumerable<Tuple<int, string>> kv = CommonHelpers.EnumToKeyValue<T>();
                foreach (Tuple<int, string> item in kv)
                {
                    command.Parameters.Clear();
                    command.Parameters.Add(new SQLiteParameter("@id", item.Item1));
                    command.Parameters.Add(new SQLiteParameter("@name", item.Item2));
                    command.ExecuteNonQuery();
                }
            }

            CreateStateData<SprintState>("T_SPRINT_STATE");
            CreateStateData<TaskState>("T_TASK_STATE");
            CreateStateData<TaskEventState>("T_TASK_EVENT_STATE");

            //Insert Default Sprint
            command.CommandText = @"
INSERT INTO T_SPRINTS
    (name, sprint_state_id)
VALUES
    (@name, @sprint_state_id)";

            command.Parameters.Clear();
            command.Parameters.Add(new SQLiteParameter("@name", SprintState.Default.ToString()));
            command.Parameters.Add(new SQLiteParameter("@sprint_state_id", SprintState.Default));
            command.ExecuteNonQuery();
        }

        protected override void CreateDbStructure()
        {
            using (SQLiteTransaction transaction = Connection.BeginTransaction())
            {
                using (SQLiteCommand command = new SQLiteCommand(Connection))
                {
                    //Create tables structure
                    CreateTables(command);

                    //Create tables data
                    CreateTablesData(command);

                    //Commit
                    transaction.Commit();
                }
            }
        }
    }
}
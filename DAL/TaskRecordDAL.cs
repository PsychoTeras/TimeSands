using System;
using System.Collections.Generic;
using System.Data.SQLite;
using TimeSands.Entities.Models;

namespace TimeSands.DAL
{
    internal class TaskRecordDAL : BaseDAL<TaskRecordDAL>, IBaseCRUD<TaskRecordModel>
    {
        public void Create(TaskRecordModel record)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
INSERT INTO T_TASK_RECORDS
    (task_id, start_time)
VALUES
    (@task_id, @start_time);
SELECT last_insert_rowid()
";
                command.Parameters.Add(new SQLiteParameter("@task_id", record.TaskId));
                command.Parameters.Add(new SQLiteParameter("@start_time", record.StartTime));
                record.Id = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(TaskRecordModel record)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
DELETE FROM T_TASK_RECORDS
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", record.Id));
                command.ExecuteNonQuery();
            }
        }

        private TaskRecordModel TaskRecordModelFromReader(SQLiteDataReader reader)
        {
            return new TaskRecordModel
            {
                Id = Convert.ToInt32(reader["id"]),
                TaskId = Convert.ToInt32(reader["task_id"]),
                StartTime = Convert.ToDateTime(reader["start_time"]),
                StopTime = DateTimeOrNull(reader["stop_time"]),
                Suspended = Convert.ToInt32(reader["suspended"]) == 1
            };
        }

        public TaskRecordModel Get(int id)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
SELECT *
FROM T_TASK_RECORDS
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", id));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return TaskRecordModelFromReader(reader);
                    }
                }
            }
            return null;
        }

        public ICollection<TaskRecordModel> GetAll(params (string, object)[] filter)
        {
            List<TaskRecordModel> models = new List<TaskRecordModel>();
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
SELECT *
FROM T_TASK_RECORDS
WHERE 1 = 1
";
                ApplyFilter(command, filter);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        models.Add(TaskRecordModelFromReader(reader));
                    }
                }
            }
            return models;
        }

        public void Update(TaskRecordModel record)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
UPDATE T_TASK_RECORDS
SET
     stop_time = @stop_time
    ,suspended = @suspended
WHERE WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", record.Id));
                command.Parameters.Add(new SQLiteParameter("@stop_time", DateTimeOrDBNull(record.StopTime)));
                command.Parameters.Add(new SQLiteParameter("@suspended", record.Suspended ? 1 : 0));
                command.ExecuteNonQuery();
            }
        }

        protected override void CreateTables(SQLiteCommand command)
        {
            //T_TASK_RECORD
            command.CommandText = @"
CREATE TABLE T_TASK_RECORDS
(
    id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    task_id INTEGER NOT NULL,
    start_time TIMESTAMP NOT NULL,
    stop_time TIMESTAMP DEFAULT NULL,
    suspended INTEGER NOT NULL DEFAULT 0,

    FOREIGN KEY(task_id) REFERENCES T_TASKS(id)
)";
            command.ExecuteNonQuery();
        }
    }
}
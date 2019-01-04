using System;
using System.Collections.Generic;
using System.Data.SQLite;
using TimeSands.Entities.Enums;
using TimeSands.Entities.Models;

namespace TimeSands.DAL
{
    internal class SprintDAL : BaseDAL<SprintDAL>, IBaseCRUD<SprintModel>
    {
        public void Create(SprintModel sprint)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                sprint.CreateTime = DateTime.Now;

                command.CommandText = @"
INSERT INTO T_SPRINTS
    (jira_id, name, create_time, sprint_state_id)
VALUES
    (@jira_id, @name, @create_time, @sprint_state_id);
SELECT last_insert_rowid()
";
                command.Parameters.Add(new SQLiteParameter("@jira_id", sprint.JiraId));
                command.Parameters.Add(new SQLiteParameter("@name", sprint.Name));
                command.Parameters.Add(new SQLiteParameter("@create_time", sprint.CreateTime));
                command.Parameters.Add(new SQLiteParameter("@sprint_state_id", SprintState.Idle));

                try
                {
                    sprint.Id = Convert.ToInt32(command.ExecuteScalar());
                }
                catch
                {
                    throw new Exception($"Duplicate sprint name \"{sprint.Name}\"");
                }
            }
        }

        public void Delete(SprintModel sprint)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
UPDATE T_SPRINTS
SET
     sprint_state_id = @state_deleted
    ,update_time = CURRENT_TIMESTAMP
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", sprint.Id));
                command.Parameters.Add(new SQLiteParameter("@state_deleted", SprintState.Deleted));
                command.ExecuteNonQuery();
            }
        }

        private SprintModel SprintModelFromReader(SQLiteDataReader reader)
        {
            return new SprintModel
            {
                Id = Convert.ToInt32(reader["id"]),
                JiraId = StringOrNull(reader["jira_id"]),
                Name = reader["name"].ToString(),
                CreateTime = Convert.ToDateTime(reader["create_time"]),
                UpdateTime = DateTimeOrNull(reader["update_time"]),
                State = (SprintState)Convert.ToInt32(reader["sprint_state_id"])
            };
        }

        public SprintModel Get(int id)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
SELECT *
FROM T_SPRINTS
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", id));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return SprintModelFromReader(reader);
                    }
                }
            }
            return null;
        }

        public ICollection<SprintModel> GetAll(params (string, object)[] filter)
        {
            List<SprintModel> models = new List<SprintModel>();
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
SELECT *
FROM T_SPRINTS
WHERE sprint_state_id <> @state_deleted
";
                ApplyFilter(command, filter);
                command.Parameters.Add(new SQLiteParameter("@state_deleted", SprintState.Deleted));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        models.Add(SprintModelFromReader(reader));
                    }
                }
            }
            return models;
        }

        public void Update(SprintModel sprint)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                sprint.UpdateTime = DateTime.Now;

                command.CommandText = @"
UPDATE T_SPRINTS
SET 
     jira_id = CASE WHEN id = @id THEN @jira_id ELSE jira_id END
    ,name = CASE WHEN id = @id THEN @name ELSE name END
    ,sprint_state_id = CASE WHEN id = @id THEN @sprint_state_id ELSE @state_idle END
    ,update_time = @update_time
WHERE id = @id OR (@sprint_state_id = @state_active AND sprint_state_id = @state_active)
";
                command.Parameters.Add(new SQLiteParameter("@id", sprint.Id));
                command.Parameters.Add(new SQLiteParameter("@jira_id", sprint.JiraId));
                command.Parameters.Add(new SQLiteParameter("@name", sprint.Name));
                command.Parameters.Add(new SQLiteParameter("@update_time", sprint.UpdateTime));
                command.Parameters.Add(new SQLiteParameter("@sprint_state_id", sprint.State));
                command.Parameters.Add(new SQLiteParameter("@state_idle", SprintState.Idle));
                command.Parameters.Add(new SQLiteParameter("@state_active", SprintState.Active));
                command.ExecuteNonQuery();
            }
        }

        protected override void CreateTables(SQLiteCommand command)
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
    name TEXT(160) NOT NULL UNIQUE COLLATE NOCASE,
    create_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    update_time TIMESTAMP DEFAULT NULL,
    sprint_state_id INTEGER NOT NULL,

    FOREIGN KEY(sprint_state_id) REFERENCES T_SPRINT_STATE(id)
)";
            command.ExecuteNonQuery();
        }

        protected override void CreateTablesData(SQLiteCommand command)
        {
            InsertStateData<SprintState>(command, "T_SPRINT_STATE");

            //Insert Default Sprint
            command.CommandText = @"
INSERT INTO T_SPRINTS
    (name, sprint_state_id)
VALUES
    (@name, @sprint_state_id)";

            command.Parameters.Clear();
            command.Parameters.Add(new SQLiteParameter("@name", "Default"));
            command.Parameters.Add(new SQLiteParameter("@sprint_state_id", SprintState.Active));
            command.ExecuteNonQuery();
        }
    }
}

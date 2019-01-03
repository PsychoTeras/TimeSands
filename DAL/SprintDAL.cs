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
SELECT last_insert_rowid()";

                command.Parameters.Add(new SQLiteParameter("@jira_id", sprint.JiraId));
                command.Parameters.Add(new SQLiteParameter("@name", sprint.Name));
                command.Parameters.Add(new SQLiteParameter("@create_time", sprint.CreateTime));
                command.Parameters.Add(new SQLiteParameter("@sprint_state_id", SprintState.Available));

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
SET sprint_state_id = @deleted_state
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", sprint.Id));
                command.Parameters.Add(new SQLiteParameter("@deleted_state", SprintState.Deleted));
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
                State = (SprintState)Convert.ToInt32(reader["sprint_state_id"]),
                IsActive = Convert.ToBoolean(reader["is_active"])
            };
        }

        public SprintModel Get(int id)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
SELECT *
FROM T_SPRINTS
WHERE id = @id AND sprint_state_id <> @deleted_state
";
                command.Parameters.Add(new SQLiteParameter("@id", id));
                command.Parameters.Add(new SQLiteParameter("@deleted_state", SprintState.Deleted));
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

        public ICollection<SprintModel> GetAll()
        {
            List<SprintModel> sprints = new List<SprintModel>();
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
SELECT *
FROM T_SPRINTS
WHERE sprint_state_id <> @deleted_state
";
                command.Parameters.Add(new SQLiteParameter("@deleted_state", SprintState.Deleted));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sprints.Add(SprintModelFromReader(reader));
                    }
                }
            }
            return sprints;
        }

        public void Update(SprintModel sprint)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
UPDATE T_SPRINTS
SET 
     jira_id = @jira_id
    ,name = @name
    ,sprint_state_id = @sprint_state_id
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", sprint.Id));
                command.Parameters.Add(new SQLiteParameter("@jira_id", sprint.JiraId));
                command.Parameters.Add(new SQLiteParameter("@name", sprint.Name));
                command.Parameters.Add(new SQLiteParameter("@sprint_state_id", sprint.State));
                command.ExecuteNonQuery();
            }
        }

        public void UpdateState(SprintModel sprint)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
UPDATE T_SPRINTS
SET sprint_state_id = @sprint_state_id
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", sprint.Id));
                command.Parameters.Add(new SQLiteParameter("@sprint_state_id", sprint.State));
                command.ExecuteNonQuery();
            }
        }

        public void SetActive(SprintModel sprint)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
UPDATE T_SPRINTS
SET is_active = CASE WHEN id = @id THEN 1 ELSE 0 END
";
                command.Parameters.Add(new SQLiteParameter("@id", sprint.Id));
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
    create_time TIMESTAMP NOT NULL,
    sprint_state_id INTEGER NOT NULL,
    is_active INTEGER NOT NULL DEFAULT 0,

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
    (name, sprint_state_id, is_active)
VALUES
    (@name, @sprint_state_id, 1)";

            command.Parameters.Clear();
            command.Parameters.Add(new SQLiteParameter("@name", SprintState.Default.ToString()));
            command.Parameters.Add(new SQLiteParameter("@sprint_state_id", SprintState.Default));
            command.ExecuteNonQuery();
        }
    }
}

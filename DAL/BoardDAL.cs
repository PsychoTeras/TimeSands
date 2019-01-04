using System;
using System.Collections.Generic;
using System.Data.SQLite;
using TimeSands.Entities.Enums;
using TimeSands.Entities.Models;

namespace TimeSands.DAL
{
    internal class BoardDAL : BaseDAL<BoardModel>, IBaseCRUD<BoardModel>
    {
        public void Create(BoardModel board)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                board.CreateTime = DateTime.Now;

                command.CommandText = @"
INSERT INTO T_BOARDS
    (jira_id, name, create_time, board_state_id)
VALUES
    (@jira_id, @name, @create_time, @board_state_id);
SELECT last_insert_rowid()
";
                command.Parameters.Add(new SQLiteParameter("@jira_id", board.JiraId));
                command.Parameters.Add(new SQLiteParameter("@name", board.Name));
                command.Parameters.Add(new SQLiteParameter("@create_time", board.CreateTime));
                command.Parameters.Add(new SQLiteParameter("@board_state_id", BoardState.Available));

                try
                {
                    board.Id = Convert.ToInt32(command.ExecuteScalar());
                }
                catch
                {
                    throw new Exception($"Duplicate board name \"{board.Name}\"");
                }
            }
        }

        public void Delete(BoardModel board)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
UPDATE T_BOARDS
SET
     board_state_id = @state_deleted
    ,update_time = CURRENT_TIMESTAMP
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", board.Id));
                command.Parameters.Add(new SQLiteParameter("@state_deleted", BoardState.Deleted));
                command.ExecuteNonQuery();
            }
        }

        private BoardModel BoardModelFromReader(SQLiteDataReader reader)
        {
            return new BoardModel
            {
                Id = Convert.ToInt32(reader["id"]),
                JiraId = StringOrNull(reader["jira_id"]),
                Name = reader["name"].ToString(),
                CreateTime = Convert.ToDateTime(reader["create_time"]),
                UpdateTime = DateTimeOrNull(reader["update_time"]),
                State = (BoardState)Convert.ToInt32(reader["board_state_id"])
            };
        }

        public BoardModel Get(int id)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
SELECT *
FROM T_BOARDS
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", id));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return BoardModelFromReader(reader);
                    }
                }
            }
            return null;
        }

        public ICollection<BoardModel> GetAll(params (string, object)[] filter)
        {
            List<BoardModel> models = new List<BoardModel>();
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                command.CommandText = @"
SELECT *
FROM T_BOARDS
WHERE board_state_id <> @state_deleted
";
                ApplyFilter(command, filter);
                command.Parameters.Add(new SQLiteParameter("@state_deleted", BoardState.Deleted));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        models.Add(BoardModelFromReader(reader));
                    }
                }
            }
            return models;
        }

        public void Update(BoardModel board)
        {
            using (SQLiteCommand command = new SQLiteCommand(Connection))
            {
                board.UpdateTime = DateTime.Now;

                command.CommandText = @"
UPDATE T_BOARDS
SET
     jira_id = @jira_id
    ,name = @name
    ,board_state_id = @board_state_id
    ,update_time = @update_time
WHERE id = @id
";
                command.Parameters.Add(new SQLiteParameter("@id", board.Id));
                command.Parameters.Add(new SQLiteParameter("@jira_id", board.JiraId));
                command.Parameters.Add(new SQLiteParameter("@name", board.Name));
                command.Parameters.Add(new SQLiteParameter("@update_time", board.UpdateTime));
                command.Parameters.Add(new SQLiteParameter("@board_state_id", board.State));
                command.ExecuteNonQuery();
            }
        }

        protected override void CreateTables(SQLiteCommand command)
        {
            //T_BOARD_STATE
            command.CommandText = @"
CREATE TABLE T_BOARD_STATE
(
    id INTEGER PRIMARY KEY NOT NULL,
    name TEXT(160) NOT NULL UNIQUE
)";
            command.ExecuteNonQuery();

            //T_BOARDS
            command.CommandText = @"
CREATE TABLE T_BOARDS
(
    id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    jira_id TEXT(20) DEFAULT NULL,
    name TEXT(160) NOT NULL UNIQUE COLLATE NOCASE,
    create_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    update_time TIMESTAMP DEFAULT NULL,
    board_state_id INTEGER NOT NULL,

    FOREIGN KEY(board_state_id) REFERENCES T_BOARD_STATE(id)
)";
            command.ExecuteNonQuery();
        }

        protected override void CreateTablesData(SQLiteCommand command)
        {
            InsertStateData<BoardState>(command, "T_BOARD_STATE");
        }
    }
}

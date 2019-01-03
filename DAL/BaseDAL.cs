using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Runtime.CompilerServices;
using TimeSands.Common;

namespace TimeSands.DAL
{
    static class SQLiteHost
    {
        private static readonly string _baseFileName = Path .GetFullPath("Data\\local.sqlite");

        public static bool IsNewDatabase { get; }

        public static HashSet<Type> WhoHasCreatedDbStructureYet { get; }

        public static SQLiteConnection Connection { get; }

        static SQLiteHost()
        {
            WhoHasCreatedDbStructureYet = new HashSet<Type>();

            string dbFolderPath = Path.GetDirectoryName(_baseFileName);
            Directory.CreateDirectory(dbFolderPath);

            IsNewDatabase = !File.Exists(_baseFileName);
            Connection = new SQLiteConnection($"Data Source={_baseFileName};Version=3;New={IsNewDatabase};Compress=True;");
            Connection.Open();
        }
    }

    public abstract class BaseDAL<TParentType>
        where TParentType : class, new()
    {
        protected SQLiteConnection Connection
        {
            get { return SQLiteHost.Connection; }
        }

        public static TParentType Instance { get; } = new TParentType();

        protected BaseDAL()
        {
            CheckDBStructure();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void CheckDBStructure()
        {
            Type thisType = GetType();
            if (SQLiteHost.IsNewDatabase && !SQLiteHost.WhoHasCreatedDbStructureYet.Contains(thisType))
            {
                CreateDbStructure();
                SQLiteHost.WhoHasCreatedDbStructureYet.Add(thisType);
            }
        }

        protected virtual void CreateTables(SQLiteCommand command) { }

        protected virtual void CreateTablesData(SQLiteCommand command) { }

        protected virtual void CreateDbStructure()
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

        protected void InsertStateData<T>(SQLiteCommand command, string tableName)
        {
            command.CommandText = $@"
INSERT INTO {tableName}
    (id, name)
VALUES
    (@id, @name)";
            IEnumerable<Tuple<int, string>> kv = Helpers.EnumToKeyValue<T>();
            foreach (Tuple<int, string> item in kv)
            {
                command.Parameters.Clear();
                command.Parameters.Add(new SQLiteParameter("@id", item.Item1));
                command.Parameters.Add(new SQLiteParameter("@name", item.Item2));
                command.ExecuteNonQuery();
            }
        }

        protected object StringOrDBNull(string str)
        {
            return string.IsNullOrEmpty(str) ? (object)DBNull.Value : str;
        }

        protected string StringOrNull(object val)
        {
            return val == DBNull.Value ? null : val.ToString();
        }

        protected DateTime? DateTimeOrNull(object val)
        {
            return val == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(val);
        }
    }
}

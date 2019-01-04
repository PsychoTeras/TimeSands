namespace TimeSands.DAL
{
    internal static class Repository
    {
        public static BoardDAL Board { get; } = new BoardDAL();

        public static SprintDAL Sprint { get; } = new SprintDAL();

        public static TaskDAL Task { get; } = new TaskDAL();

        public static TaskRecordDAL TaskRecord { get; } = new TaskRecordDAL();
    }
}

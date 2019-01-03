namespace TimeSands.DAL
{
    internal static class Repository
    {
        public static SprintDAL Sprint { get; } = new SprintDAL();

        public static TaskDAL Task { get; } = new TaskDAL();
    }
}

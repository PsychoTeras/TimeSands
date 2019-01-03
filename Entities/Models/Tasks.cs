using TimeSands.DAL;

namespace TimeSands.Entities.Models
{
    internal class Tasks : BaseCollectionModel<TaskModel, Tasks>
    {
        protected Tasks() : base(Repository.Task)
        {
        }
    }
}

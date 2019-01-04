using TimeSands.DAL;
using TimeSands.Entities.Enums;
using TimeSands.Entities.Models;

namespace TimeSands.Entities.Collections
{
    internal class Tasks : BaseCollectionSingleton<TaskModel, Tasks>
    {
        public TaskModel ActiveTask
        {
            get { return Collection.Find(m => m.State == TaskState.Active); }
        }

        public TaskModel Create(int boardId, int sprintId)
        {
            TaskModel model = base.Create();
            model.BoardId = boardId;
            model.SprintId = sprintId;
            return model;
        }

        protected Tasks() : base(Repository.Task)
        {
        }
    }
}

using System.Linq;
using TimeSands.DAL;
using TimeSands.Entities.Enums;
using TimeSands.Entities.Models;

namespace TimeSands.Entities.Collections
{
    internal class Tasks : BaseCollectionSingleton<TaskModel, Tasks>
    {
        public TaskModel ActiveTask
        {
            get
            {
                return Collection.Find(m => m.State == TaskState.Active);
            }
            set
            {
                AssertModelExists(value);
                value.State = TaskState.Active;
                Save(value);
            }
        }

        public TaskModel Create(int boardId, int sprintId)
        {
            TaskModel model = base.Create();
            model.BoardId = boardId;
            model.SprintId = sprintId;
            return model;
        }

        public override void Save(TaskModel model)
        {
            base.Save(model);
            if (model.State == TaskState.Active)
            {
                Collection.Where(m => m != model && m.State == TaskState.Active).ToList().ForEach(m =>
                {
                    m.State = TaskState.Idle;
                    m.UpdateTime = model.UpdateTime;
                });
            }
        }

        protected Tasks() : base(Repository.Task)
        {
        }
    }
}

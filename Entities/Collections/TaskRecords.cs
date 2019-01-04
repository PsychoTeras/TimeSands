using TimeSands.DAL;
using TimeSands.Entities.Models;

namespace TimeSands.Entities.Collections
{
    internal class TaskRecords : BaseCollection<TaskRecordModel, TaskRecords>
    {
        public TaskRecords() : base(Repository.TaskRecord)
        {
        }
    }
}

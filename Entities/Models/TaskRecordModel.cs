using System;
using TimeSands.Entities.Collections;

namespace TimeSands.Entities.Models
{
    internal class TaskRecordModel : BaseModel<TaskRecordModel>
    {
        public int TaskId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? StopTime { get; set; }

        public bool IsStopped
        {
            get { return StopTime.HasValue; }
        }

        public TaskRecordModel() : base(null)
        {
        }

        public void Bind(int taskId, TaskRecords owner)
        {
            TaskId = taskId;
            Owner = owner;
        }
    }
}

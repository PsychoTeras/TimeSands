using System;
using TimeSands.Entities.Collections;

namespace TimeSands.Entities.Models
{
    internal class TaskRecordModel : BaseModel<TaskRecordModel>
    {
        public int TaskId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? StopTime { get; set; }

        public bool Suspended { get; set; }

        public TaskRecordModel() : base(null)
        {
        }

        public void Bind(int taskId, TaskRecords owner)
        {
            TaskId = taskId;
            Owner = owner;
        }

        public void StopRecord()
        {
            Tasks.Instance.Get(TaskId).StopRecord(this);
        }

        public void SuspendRecord()
        {
            Tasks.Instance.Get(TaskId).SuspendRecord(this);
        }

        public void ResumeRecord()
        {
            Tasks.Instance.Get(TaskId).ResumeRecord(this);
        }
    }
}

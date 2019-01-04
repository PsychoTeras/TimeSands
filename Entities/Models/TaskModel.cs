using System;
using TimeSands.Common;
using TimeSands.Entities.Collections;
using TimeSands.Entities.Enums;

namespace TimeSands.Entities.Models
{
    internal class TaskModel : BaseModel<TaskModel>
    {
        private TaskRecords _records;

        public string JiraId { get; set; }

        public int BoardId { get; set; }

        public int SprintId { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime? CloseTime { get; set; }

        public TaskState State { get; set; }

        public string SprintName
        {
            get { return Sprints.Instance.Get(SprintId)?.Name ?? string.Empty; }
        }

        public string CreatedAt
        {
            get { return CreateTime.ToString(); }
        }

        public string ClosedAt
        {
            get { return CloseTime?.ToString() ?? string.Empty; }
        }

        public string TimeSpent
        {
            get
            {
                TimeSpan total = new TimeSpan();
                foreach (TaskRecordModel record in _records)
                {
                    DateTime endTime = record.StopTime ?? DateTime.Now;
                    total = total.Add(endTime.Subtract(record.StartTime));
                }
                return Helpers.TimeSpanToTimeString(total);
            }
        }

        public TaskModel() : base(Tasks.Instance)
        {
            _records = new TaskRecords();
            _records.GetAll(("task_id", Id));
        }

        public void SetActive()
        {
            if (State != TaskState.Active)
            {
                Tasks.Instance.ActiveTask = this;
            }
        }

        public TaskRecordModel StartRecord()
        {
            TaskRecordModel record = _records.Create();
            record.StartTime = DateTime.Now;
            record.Bind(Id, _records);
            record.Save();
            return record;
        }

        public void StopRecord(TaskRecordModel record)
        {
            record.StopTime = DateTime.Now;
            record.Save();
        }

        public void SuspendRecord(TaskRecordModel record)
        {
            if (!record.Suspended)
            {
                record.Suspended = true;
                record.Save();
            }
        }

        public void ResumeRecord(TaskRecordModel record)
        {
            if (record.Suspended)
            {
                record.Suspended = false;
                record.Save();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

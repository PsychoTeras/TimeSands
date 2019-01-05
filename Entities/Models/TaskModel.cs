using System;
using System.Linq;
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

        public DateTime? StartTime
        {
            get { return _records.FirstOrDefault()?.StartTime; }
        }

        public string StartedAt
        {
            get { return StartTime?.ToString(); }
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
        }

        public void GetAllRecords()
        {
            _records.GetAll(("task_id", Id));
        }

        public bool SetActive()
        {
            if (State != TaskState.Active && State != TaskState.Deleted)
            {
                foreach (TaskModel task in Tasks.Instance.Where(t => t != this))
                {
                    task.SetInactive();
                }

                switch (State)
                {
                    case TaskState.Idle:
                    case TaskState.Closed:
                        StartRecord();
                        break;
                }

                State = TaskState.Active;
                Save();
                return true;
            }

            return false;
        }

        public bool SetInactive()
        {
            if (State == TaskState.Active || State == TaskState.Suspended)
            {
                StopRecord();
                State = TaskState.Idle;
                Save();
                return true;
            }

            return false;
        }

        public bool ToggleActive()
        {
            return SetActive() || SetInactive();
        }

        private void StartRecord()
        {
            TaskRecordModel record = _records.Create();
            record.StartTime = DateTime.Now;
            record.Bind(Id, _records);
            record.Save();
        }

        private void StopRecord()
        {
            TaskRecordModel record = _records.Last();
            record.StopTime = DateTime.Now;
            record.Save();
        }

        public void Suspend()
        {
            if (State == TaskState.Active)
            {
                State = TaskState.Suspended;
                Save();
            }
        }

        public void Resume()
        {
            if (State == TaskState.Suspended)
            {
                State = TaskState.Active;
                Save();
            }
        }

        public void Close()
        {
            if (State != TaskState.Closed && State != TaskState.Deleted)
            {
                TaskRecordModel record = _records.LastOrDefault();
                if (record != null && !record.IsStopped)
                {
                    StopRecord();
                }
                State = TaskState.Closed;
                Save();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

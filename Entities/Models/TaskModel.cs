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

        public bool CanStart
        {
            get { return State != TaskState.Active && State != TaskState.Deleted; }
        }

        public bool Start()
        {
            if (CanStart)
            {
                foreach (TaskModel task in Tasks.Instance.Where(t => t != this))
                {
                    task.Stop();
                }

                switch (State)
                {
                    case TaskState.Idle:
                    case TaskState.Closed:
                    case TaskState.Suspended:
                        StartRecord();
                        break;
                }

                State = TaskState.Active;
                Save();
                return true;
            }

            return false;
        }

        public bool CanStop
        {
            get { return State == TaskState.Active || State == TaskState.Suspended; }
        }

        public bool Stop()
        {
            if (CanStop)
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
            return Start() || Stop();
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

        public bool CanSuspend
        {
            get { return State == TaskState.Active; }
        }

        public void Suspend()
        {
            if (CanSuspend)
            {
                StopRecord();
                State = TaskState.Suspended;
                Save();
            }
        }

        public bool CanResume
        {
            get { return State == TaskState.Suspended; }
        }

        public void Resume()
        {
            if (CanResume)
            {
                StartRecord();
                State = TaskState.Active;
                Save();
            }
        }

        public bool CanClose
        {
            get { return State != TaskState.Closed && State != TaskState.Deleted; }
        }

        public void Close()
        {
            if (CanClose)
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

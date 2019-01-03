using System;
using System.Collections.Generic;
using TimeSands.Common;
using TimeSands.Entities.Enums;

namespace TimeSands.Entities.Models
{
    internal class TaskModel : BaseModel
    {
        public string JiraId { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime? CloseTime { get; set; }

        public TaskState State { get; set; }

        public SprintModel Sprint { get; set; }

        public List<TaskRecordModel> Records { get; }

        public string SprintName
        {
            get { return Sprint?.Name ?? string.Empty; }
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
                foreach (TaskRecordModel record in Records)
                {
                    DateTime endTime = record.EndTime ?? DateTime.Now;
                    total = total.Add(endTime.Subtract(record.StartTime));
                }
                return Helpers.TimeSpanToTimeString(total);
            }
        }

        public TaskModel()
        {
            Records = new List<TaskRecordModel>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

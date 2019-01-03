using System;
using System.Collections.Generic;
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

        public List<TaskRecordModel> Records { get; }

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

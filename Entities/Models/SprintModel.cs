using System;
using System.Collections.Generic;
using TimeSands.Entities.Enums;

namespace TimeSands.Entities.Models
{
    internal class SprintModel : BaseModel
    {
        public string JiraId { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public SprintState State { get; set; }

        public List<TaskModel> Tasks { get; }

        public SprintModel()
        {
            Tasks = new List<TaskModel>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

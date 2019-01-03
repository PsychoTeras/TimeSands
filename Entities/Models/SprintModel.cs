using System;
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

        public override string ToString()
        {
            return Name;
        }
    }
}

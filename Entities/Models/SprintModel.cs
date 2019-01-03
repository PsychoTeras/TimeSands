using System;
using TimeSands.Entities.Enums;

namespace TimeSands.Entities.Models
{
    internal class SprintModel : BaseModel<SprintModel>
    {
        public string JiraId { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public SprintState State { get; set; }

        public bool IsActive { get; set; }

        public SprintModel() : base(Sprints.Instance)
        {
        }

        public override string ToString()
        {
            return IsActive ? $"{Name} (active)" : Name;
        }
    }
}

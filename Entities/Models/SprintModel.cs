using System;
using TimeSands.Entities.Collections;
using TimeSands.Entities.Enums;

namespace TimeSands.Entities.Models
{
    internal class SprintModel : BaseModel<SprintModel>
    {
        public string JiraId { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public SprintState State { get; set; }

        public SprintModel() : base(Sprints.Instance)
        {
        }

        public void SetActive()
        {
            if (State != SprintState.Active)
            {
                Sprints.Instance.ActiveSprint = this;
            }
        }

        public override string ToString()
        {
            return State == SprintState.Active
                ? $"{Name} ({State.ToString()})"
                : Name;
        }
    }
}

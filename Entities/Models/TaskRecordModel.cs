using System;
using TimeSands.Entities.Enums;

namespace TimeSands.Entities.Models
{
    internal class TaskRecordModel : BaseModel
    {
        public DateTime StartTime { get; set; }

        public DateTime? StopTime { get; set; }

        public TaskRecordState State { get; set; }
    }
}

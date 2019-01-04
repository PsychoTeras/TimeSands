using System;
using TimeSands.Entities.Collections;
using TimeSands.Entities.Enums;

namespace TimeSands.Entities.Models
{
    internal class BoardModel : BaseModel<BoardModel>
    {
        public string JiraId { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public BoardState State { get; set; }

        public BoardModel() : base(Boards.Instance)
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

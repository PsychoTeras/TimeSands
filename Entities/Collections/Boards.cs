﻿using TimeSands.DAL;
using TimeSands.Entities.Models;

namespace TimeSands.Entities.Collections
{
    internal class Boards : BaseCollectionSingleton<BoardModel, Boards>
    {
        protected Boards() : base(Repository.Board)
        {
        }
    }
}

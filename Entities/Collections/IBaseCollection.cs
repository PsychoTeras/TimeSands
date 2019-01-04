using System.Collections.Generic;
using System.ComponentModel;
using TimeSands.Entities.Models;

namespace TimeSands.Entities.Collections
{
    internal interface IBaseCollection<T> : IEnumerable<T>, IListSource
        where T : BaseModel<T>, new()
    {
        void Delete(T model);

        void Save(T model);
    }
}

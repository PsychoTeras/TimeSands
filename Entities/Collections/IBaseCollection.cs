using System.Collections.Generic;
using TimeSands.Entities.Models;

namespace TimeSands.Entities.Collections
{
    internal interface IBaseCollection<T> : IEnumerable<T>, IReadOnlyCollection<T>
        where T : BaseModel<T>, new()
    {
        void Delete(T model);

        void Save(T model);
    }
}

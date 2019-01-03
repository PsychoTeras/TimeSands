using System.Collections.Generic;

namespace TimeSands.Entities.Models
{
    internal interface IBaseCollectionModel<T> : IEnumerable<T>
        where T : BaseModel<T>, new()
    {
        T Create();

        T Get(int id);

        void Append(T model);

        void Delete(T model);

        void Save(T model);
    }
}

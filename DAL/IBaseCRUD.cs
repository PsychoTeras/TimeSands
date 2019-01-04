using System.Collections.Generic;
using TimeSands.Entities.Models;

namespace TimeSands.DAL
{
    internal interface IBaseCRUD<T>
        where T: BaseModel<T>, new()
    {
        T Get(int id);

        ICollection<T> GetAll(params (string, object)[] filter);

        void Create(T model);

        void Update(T model);

        void Delete(T model);
    }
}

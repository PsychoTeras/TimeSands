using System;
using System.Collections;
using System.Collections.Generic;
using TimeSands.DAL;
using TimeSands.Entities.Models;

namespace TimeSands.Entities.Collections
{
    internal abstract class BaseCollection<T, TC> : IBaseCollection<T>
        where T: BaseModel<T>, new() 
        where TC: BaseCollection<T, TC>
    {
        private IBaseCRUD<T> _dbObject;

        protected List<T> Collection;

        public bool ContainsListCollection
        {
            get { return true; }
        }

        protected void AssertModelNotExists(T model)
        {
            if (model == null || Collection.IndexOf(model) != -1)
            {
                throw new Exception("Item exists");
            }
        }

        protected void AssertModelExists(T model)
        {
            if (model == null || Collection.IndexOf(model) == -1)
            {
                throw new Exception("Item doesn't exists");
            }
        }

        protected BaseCollection(IBaseCRUD<T> dbObject)
        {
            _dbObject = dbObject;
            Collection = new List<T>();
        }

        public virtual T Create()
        {
            T model = new T();
            Collection.Add(model);
            return model;
        }

        public virtual T Get(int id)
        {
            T model = Collection.Find(m => m.Id == id);
            if (model == default(T))
            {
                model = _dbObject.Get(id);
                if (model != null)
                {
                    Collection.Add(model);
                }
            }
            return model;
        }

        public virtual void GetAll(params (string, object)[] filter)
        {
            Collection.Clear();
            ICollection<T> models = _dbObject.GetAll(filter);
            Collection.AddRange(models);
        }

        public virtual void Append(T model)
        {
            AssertModelNotExists(model);
            Collection.Add(model);
        }

        public virtual void Delete(T model)
        {
            AssertModelExists(model);

            if (model.Id != 0)
            {
                _dbObject.Delete(model);
            }
            Collection.Remove(model);
        }

        public virtual void Save(T model)
        {
            AssertModelExists(model);
            if (model.Id == 0)
            {
                _dbObject?.Create(model);
            }
            else
            {
                _dbObject?.Update(model);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IList GetList()
        {
            return Collection;
        }
    }
}

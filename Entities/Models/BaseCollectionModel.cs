using System;
using System.Collections;
using System.Collections.Generic;
using TimeSands.DAL;

namespace TimeSands.Entities.Models
{
    internal abstract class BaseCollectionModel<T, TC> : IBaseCollectionModel<T>
        where T: BaseModel<T>, new() 
        where TC: BaseCollectionModel<T, TC>
    {
        private static readonly TC _instance = (TC)Activator.CreateInstance(typeof(TC), true);

        private bool _isLoaded;
        private IBaseCRUD<T> _dbObject;

        protected List<T> Collection;        

        public static TC Instance
        {
            get
            {
                if (!_instance._isLoaded)
                {
                    lock (_instance)
                    {
                        if (!_instance._isLoaded)
                        {
                            _instance._isLoaded = true;
                            _instance.LoadFromDB();
                        }
                    }
                }
                return _instance;
            }
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
                throw new Exception("Item not exists");
            }
        }

        protected BaseCollectionModel(IBaseCRUD<T> dbObject)
        {
            _dbObject = dbObject;
            Collection = new List<T>();
        }

        public virtual T Create()
        {
            return new T();
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

        public virtual void LoadFromDB()
        {
            Collection.Clear();
            _dbObject.GetAll();
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
    }
}

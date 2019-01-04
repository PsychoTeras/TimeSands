using System;
using TimeSands.DAL;
using TimeSands.Entities.Models;

namespace TimeSands.Entities.Collections
{
    internal abstract class BaseCollectionSingleton<T, TC> : BaseCollection<T, TC>
        where T : BaseModel<T>, new()
        where TC : BaseCollectionSingleton<T, TC>
    {
        private static readonly TC _instance = (TC)Activator.CreateInstance(typeof(TC), true);

        private bool _isLoaded;

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
                            _instance.GetAll();
                        }
                    }
                }
                return _instance;
            }
        }

        protected BaseCollectionSingleton(IBaseCRUD<T> dbObject) 
            : base(dbObject)
        {
        }
    }
}

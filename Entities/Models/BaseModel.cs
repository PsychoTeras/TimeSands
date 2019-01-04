using TimeSands.Entities.Collections;

namespace TimeSands.Entities.Models
{
    internal abstract class BaseModel<T>
        where T : BaseModel<T>, new()
    {
        protected IBaseCollection<T> Owner;

        public int Id { get; set; }

        protected BaseModel(IBaseCollection<T> owner)
        {
            Owner = owner;
        }

        public virtual void Save()
        {
            Owner.Save((T)this);
        }

        public virtual void Delete()
        {
            Owner.Delete((T)this);
        }
    }
}

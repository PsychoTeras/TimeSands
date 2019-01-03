namespace TimeSands.Entities.Models
{
    internal abstract class BaseModel<T>
        where T : BaseModel<T>, new()
    {
        protected IBaseCollectionModel<T> Owner;

        public int Id { get; set; }

        public BaseModel(IBaseCollectionModel<T> owner)
        {
            if (owner != null)
            {
                Owner = owner;
                Owner.Append((T)this);
            }
        }

        public virtual void Save()
        {
            Owner.Save((T)this);
        }
    }
}

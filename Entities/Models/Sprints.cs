using TimeSands.DAL;

namespace TimeSands.Entities.Models
{
    internal class Sprints : BaseCollectionModel<SprintModel, Sprints>
    {
        private SprintDAL _dal;

        public SprintModel ActiveSprint
        {
            get
            {
                return Collection.Find(m => m.IsActive);
            }
            set
            {
                AssertModelExists(value);

                if (value.IsActive)
                {
                    return;
                }

                _dal.SetActive(value);
                foreach (SprintModel model in Collection)
                {
                    model.IsActive = model == value;
                }
            }
        }

        protected Sprints() : base(Repository.Sprint)
        {
            _dal = Repository.Sprint;
        }
    }
}

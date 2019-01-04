using System.Linq;
using TimeSands.DAL;
using TimeSands.Entities.Enums;
using TimeSands.Entities.Models;

namespace TimeSands.Entities.Collections
{
    internal class Sprints : BaseCollectionSingleton<SprintModel, Sprints>
    {
        public SprintModel ActiveSprint
        {
            get
            {
                return Collection.Find(m => m.State == SprintState.Active);
            }
            set
            {
                AssertModelExists(value);
                value.State = SprintState.Active;
                Save(value);
            }
        }

        public override void Save(SprintModel model)
        {
            base.Save(model);
            if (model.State == SprintState.Active)
            {
                Collection.Where(m => m != model && m.State == SprintState.Active).ToList().ForEach(m =>
                {
                    m.State = SprintState.Idle;
                    m.UpdateTime = model.UpdateTime;
                });
            }
        }

        protected Sprints() : base(Repository.Sprint)
        {
        }
    }
}

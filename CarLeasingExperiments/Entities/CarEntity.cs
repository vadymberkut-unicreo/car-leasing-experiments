using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Entities
{
    public class CarEntity : BaseEntity, ITransitionableEntity
    {
        public StateEnum State { get; set; }
    }
}

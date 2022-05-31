using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Entities
{
    public class CarEntity : BaseEntity, ITransitionableEntity
    {
        public string State { get; set; }
    }
}

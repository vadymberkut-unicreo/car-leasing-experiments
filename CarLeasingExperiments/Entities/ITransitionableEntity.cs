using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Entities
{
    public interface ITransitionableEntity
    {
        public string Id { get; set; }
        public string State { get; set; }
    }
}

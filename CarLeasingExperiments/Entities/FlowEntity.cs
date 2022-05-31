using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Entities
{
    public class FlowEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Target { get; set; }
        public bool IsDefault { get; set; }
        public IStateTree StateTree { get; set; }
    }
}

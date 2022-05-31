using CarLeasingExperiments.Infrustructure;
using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Entities
{
    public class StateDataEntity : BaseEntity, IStateData
    {
        public string EntityId { get; set; }
        public string State { get; set; }
        public IEnumerable<UserEntity> Assignees { get; set; }
}
}

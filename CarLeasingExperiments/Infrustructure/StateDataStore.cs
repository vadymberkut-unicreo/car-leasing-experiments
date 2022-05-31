using CarLeasingExperiments.Entities;
using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Infrustructure
{
    public class StateDataStore : IStateDataStore
    {
        public IStateData GetStateData(string entityId, string state)
        {
            // query from DB ...

            return new StateDataEntity()
            {
                Id = null,
                EntityId = entityId,
                State = state,
                Assignees = Enumerable.Empty<UserEntity> (),
            };
        }
    }
}

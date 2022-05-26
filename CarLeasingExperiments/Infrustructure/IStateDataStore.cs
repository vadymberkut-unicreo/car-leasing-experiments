using CarLeasingExperiments.Entities;
using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Infrustructure
{
    public interface IStateDataStore
    {
        IStateData GetStateData(string entityId, StateEnum state);
    }
}

using CarLeasingExperiments.Entities;
using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Infrustructure
{
    /// <summary>
    /// Represents dynamic state data that can be changed at runtime
    /// </summary>
    public interface IStateData
    {
        string EntityId { get; }
        string State { get; }
        IEnumerable<UserEntity> Assignees { get; }
    }
}

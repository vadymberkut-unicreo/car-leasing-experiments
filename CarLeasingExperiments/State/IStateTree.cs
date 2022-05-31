namespace CarLeasingExperiments.State
{
    public interface IStateTree
    {
        string State { get; }
        IList<IStateTreeChild> Children { get; }

        IStateTree AddNextState(string transitionNameId, IStateTree child, IEnumerable<string> allowedRoles = null);
        IEnumerable<IStateTreeChild> GetNextStates(string fromState);
    }
}

namespace CarLeasingExperiments.State
{
    public interface IStateTree
    {
        StateEnum State { get; }
        IList<IStateTreeChild> Children { get; }

        IStateTree AddNextState(Type transitionType, IStateTree child);
        IEnumerable<IStateTreeChild> GetNextStates(StateEnum fromState);
    }

    public interface IStateTreeChild
    {
        IStateTree Child { get; set; }
        Type TransitionType { get; set; }
    }

    public class StateTreeChild : IStateTreeChild
    {
        public IStateTree Child { get; set; }
        public Type TransitionType { get; set; }
    }
}

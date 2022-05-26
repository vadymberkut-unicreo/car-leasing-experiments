namespace CarLeasingExperiments.State
{
    public class StateTree : IStateTree
    {
        public StateEnum State { get; private set; }
        public IList<IStateTreeChild> Children { get; private set; }

        public StateTree(StateEnum state)
        {
            State = state;
            Children = new List<IStateTreeChild>();
        }

        public IStateTree AddNextState(Type transitionType, IStateTree child)
        {
            Children.Add(new StateTreeChild()
            {
                Child = child,
                TransitionType = transitionType,
            });
            return this;
        }

        public IEnumerable<IStateTreeChild> GetNextStates(StateEnum fromState)
        {
            if(State == fromState)
            {
                return Children;
            }
            else if (!Children.Any())
            {
                return Enumerable.Empty<IStateTreeChild>();
            }
            else
            {
                foreach (var child in Children)
                {
                    var result = child.Child.GetNextStates(fromState);
                    if(result.Any())
                    {
                        return result;
                    }
                }
            }

            return Enumerable.Empty<IStateTreeChild>();
        }
    }
}

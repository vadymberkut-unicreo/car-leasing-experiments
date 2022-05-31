namespace CarLeasingExperiments.State
{
    public class StateTree : IStateTree
    {
        public string State { get; private set; }
        public IList<IStateTreeChild> Children { get; private set; }

        public StateTree(string state)
        {
            State = state;
            Children = new List<IStateTreeChild>();
        }

        public IStateTree AddNextState(string transitionNameId, IStateTree child, IEnumerable<string> allowedRoles = null)
        {
            Children.Add(new StateTreeChild()
            {
                Child = child,
                TransitionNameId = transitionNameId,
                AllowedRoles = allowedRoles ?? new string[] { },
            });
            return this;
        }

        public IEnumerable<IStateTreeChild> GetNextStates(string fromState)
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

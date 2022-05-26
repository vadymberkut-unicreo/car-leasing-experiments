using CarLeasingExperiments.Infrustructure;
using CarLeasingExperiments.State;
using MediatR;

namespace CarLeasingExperiments.Transitions
{
    public class BToDTransition : ITransition<Unit>
    {
        public IEnumerable<string> AllowedRoles { get; private set; } = new List<string>() { };

        public BToDTransition()
        {
        }

        public bool Validate(ITransitionData<Unit> data, IStateData? stateData)
        {
            return true;
        }

        public void Execute(ITransitionData<Unit> data, IStateData? stateData)
        {
            data.Entity.State = StateEnum.StateD;
        }
    }
}

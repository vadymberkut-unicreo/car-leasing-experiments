using CarLeasingExperiments.Infrustructure;
using CarLeasingExperiments.State;
using MediatR;

namespace CarLeasingExperiments.Transitions
{
    public class ToATransition : ITransition<Unit>
    {
        public IEnumerable<string> AllowedRoles { get; private set; } = new List<string>()
        {
        };

        public ToATransition()
        {
        }

        public bool Validate(ITransitionData<Unit> data, IStateData? stateData)
        {
            return true;
        }

        public void Execute(ITransitionData<Unit> data, IStateData? stateData)
        {
            data.Entity.State = StateEnum.StateA;
        }
    }
}

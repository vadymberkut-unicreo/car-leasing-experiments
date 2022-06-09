using CarLeasingExperiments.Infrustructure;
using MediatR;

namespace CarLeasingExperiments.Transitions
{
    public class DefaultTransition : ITransition<Unit>
    {
        public DefaultTransition()
        {
        }

        public bool Validate(ITransitionData<Unit> data, IStateData? stateData)
        {
            return true;
        }

        public void Execute(ITransitionData<Unit> data, IStateData? stateData)
        {
            data.Entity.State = data.NewState;
        }
    }
}

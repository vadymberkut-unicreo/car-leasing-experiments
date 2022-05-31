using CarLeasingExperiments.Constants;
using CarLeasingExperiments.Infrustructure;
using CarLeasingExperiments.State;
using MediatR;

namespace CarLeasingExperiments.Transitions
{
    public class BToDTransition : ITransition<Unit>
    {
        public BToDTransition()
        {
        }

        public bool Validate(ITransitionData<Unit> data, IStateData? stateData)
        {
            return true;
        }

        public void Execute(ITransitionData<Unit> data, IStateData? stateData)
        {
            data.Entity.State = StateNameIds.StateD;
        }
    }
}

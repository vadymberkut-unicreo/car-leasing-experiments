using CarLeasingExperiments.Constants;
using CarLeasingExperiments.Infrustructure;

namespace CarLeasingExperiments.Transitions
{
    public class AToBTransitionData
    {
        public string Message { get; set; }
    }

    public class AToBTransition : ITransition<AToBTransitionData>
    {
        public AToBTransition()
        {
        }

        public bool Validate(ITransitionData<AToBTransitionData> data, IStateData? stateData)
        {
            return data.User != null;
        }

        public void Execute(ITransitionData<AToBTransitionData> data, IStateData? stateData)
        {
            data.Entity.State = StateNameIds.StateB;
        }
    }
}

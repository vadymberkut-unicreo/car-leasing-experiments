using CarLeasingExperiments.Constants;
using CarLeasingExperiments.Infrustructure;

namespace CarLeasingExperiments.Transitions
{
    public class ToBTransitionData
    {
        public string Message { get; set; }
    }

    public class ToBTransition : ITransition<ToBTransitionData>
    {
        public ToBTransition()
        {
        }

        public bool Validate(ITransitionData<ToBTransitionData> data, IStateData? stateData)
        {
            return data.User != null;
        }

        public void Execute(ITransitionData<ToBTransitionData> data, IStateData? stateData)
        {
            data.Entity.State = StateNameIds.StateB;
        }
    }
}

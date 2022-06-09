using CarLeasingExperiments.Constants;
using CarLeasingExperiments.Infrustructure;
using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Transitions
{
    public class ToCTransitionData
    {
        public int Limit { get; set; }
        public string SomeId { get; set; }
    }

    public class ToCTransition : ITransition<ToCTransitionData>
    {
        public ToCTransition()
        {
        }

        public bool Validate(ITransitionData<ToCTransitionData> data, IStateData? stateData)
        {
            return data.Data != null && data.Data.Limit < 100;
        }

        public void Execute(ITransitionData<ToCTransitionData> data, IStateData? stateData)
        {
            data.Entity.State = StateNameIds.StateC;
        }
    }
}

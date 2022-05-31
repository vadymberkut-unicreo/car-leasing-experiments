using CarLeasingExperiments.Constants;
using CarLeasingExperiments.Infrustructure;
using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Transitions
{
    public class BToCTransitionData
    {
        public int Limit { get; set; }
        public string SomeId { get; set; }
    }

    public class BToCTransition : ITransition<BToCTransitionData>
    {
        public BToCTransition()
        {
        }

        public bool Validate(ITransitionData<BToCTransitionData> data, IStateData? stateData)
        {
            return data.Data != null && data.Data.Limit < 100;
        }

        public void Execute(ITransitionData<BToCTransitionData> data, IStateData? stateData)
        {
            data.Entity.State = StateNameIds.StateC;
        }
    }
}

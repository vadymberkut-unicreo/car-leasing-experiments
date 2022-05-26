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
        public IEnumerable<string> AllowedRoles { get; private set; } = new List<string>()  { };

        public BToCTransition()
        {
        }

        public bool Validate(ITransitionData<BToCTransitionData> data, IStateData? stateData)
        {
            return data.Data != null && data.Data.Limit < 100;
        }

        public void Execute(ITransitionData<BToCTransitionData> data, IStateData? stateData)
        {
            data.Entity.State = StateEnum.StateC;
        }
    }
}

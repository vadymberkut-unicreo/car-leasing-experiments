using CarLeasingExperiments.Infrustructure;
using CarLeasingExperiments.State;
using MediatR;

namespace CarLeasingExperiments.Transitions
{
    public class AToBTransition : ITransition<Unit>
    {
        public IEnumerable<string> AllowedRoles { get; private set; } = new List<string>()
        {
            "SuperAdmin",
            "Admin",
        };

        public AToBTransition()
        {
        }

        public bool Validate(ITransitionData<Unit> data, IStateData? stateData)
        {
            return data.User != null && AllowedRoles.Any(role => data.User.Roles.Contains(role));
        }

        public void Execute(ITransitionData<Unit> data, IStateData? stateData)
        {
            data.Entity.State = StateEnum.StateB;
        }
    }
}

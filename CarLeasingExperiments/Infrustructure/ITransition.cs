using MediatR;

namespace CarLeasingExperiments.Infrustructure
{
    public interface ITransition<TData>
    {
        IEnumerable<string> AllowedRoles { get; }
        bool Validate(ITransitionData<TData> data, IStateData? stateData);
        void Execute(ITransitionData<TData> data, IStateData? stateData);
    }
}

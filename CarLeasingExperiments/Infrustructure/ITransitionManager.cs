using CarLeasingExperiments.Entities;
using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Infrustructure
{
    public interface ITransitionManager
    {
        public IStateTree StateTree { get; }
        void Transit(UserEntity? user, ITransitionableEntity entity, StateEnum newState);
        void Transit<TData>(UserEntity? user, ITransitionableEntity entity, StateEnum newState, TData? data);
    }
}

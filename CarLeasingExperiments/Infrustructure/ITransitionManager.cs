using CarLeasingExperiments.Entities;
using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Infrustructure
{
    public interface ITransitionManager
    {
        void Transit(UserEntity? user, ITransitionableEntity entity, string newState);
        void Transit<TData>(UserEntity? user, ITransitionableEntity entity, string newState, TData? data);
    }
}

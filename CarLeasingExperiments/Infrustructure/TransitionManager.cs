using CarLeasingExperiments.Entities;
using CarLeasingExperiments.State;
using MediatR;

namespace CarLeasingExperiments.Infrustructure
{
    public abstract class TransitionManager : ITransitionManager
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IStateDataStore _stateDataStore;

        public TransitionManager(
            IServiceProvider serviceProvider,
            IStateDataStore stateDataStore,
            IStateTree stateTree
        )
        {
            _serviceProvider = serviceProvider;
            _stateDataStore = stateDataStore;

            StateTree = stateTree;
        }

        public IStateTree StateTree { get; set; }

        public void Transit(UserEntity? user, ITransitionableEntity entity, StateEnum newState)
        {
            Transit<Unit>(user, entity, newState, data: Unit.Value);
        }


        public void Transit<TData>(UserEntity? user, ITransitionableEntity entity, StateEnum newState, TData? data)
        {
            // ensure transition is possible
            var nextStates = StateTree.GetNextStates(entity.State);
            var nextState = nextStates.SingleOrDefault(x => x.Child.State == newState);
            if (nextState == null)
            {
                throw new Exception($"Transition from state {entity.State} to state {newState} doesn't exist.");
            }

            // resolve transition from DI
            var transitionObj = _serviceProvider.GetService(nextState.TransitionType);
            if (transitionObj == null)
            {
                throw new Exception($"Transition from state {entity.State} to state {newState} isn't registered.");
            }
            var transition = transitionObj as ITransition<TData>;
            if (transition == null)
            {
                throw new Exception($"Transition of type {nextState.TransitionType.Name} doesn't expect data of type {typeof(TData).Name}.");
            }

            // get state data from DB
            var stateData = _stateDataStore.GetStateData(entity.Id, entity.State);

            var transitionData = new TransitionData<TData>()
            {
                User = user,
                Entity = entity,
                Data = data,
            };

            // ensure we can transit
            if (!transition.Validate(transitionData, stateData))
            {
                throw new Exception($"Transition from state {entity.State} to state {newState} failed - validation error.");
            }

            // transit
            transition.Execute(transitionData, stateData);
        }
    }
}

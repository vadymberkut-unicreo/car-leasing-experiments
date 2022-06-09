using CarLeasingExperiments.Entities;
using CarLeasingExperiments.State;
using MediatR;

namespace CarLeasingExperiments.Infrustructure
{
    public abstract class TransitionManager : ITransitionManager
    {
        private readonly string _flowTarget;

        private readonly ITransitionResolver _transitionResolver;
        private readonly IFlowStore _flowStore;
        private readonly IStateDataStore _stateDataStore;

        public TransitionManager(
            string flowTarget,
            ITransitionResolver transitionResolver,
            IFlowStore flowStore,
            IStateDataStore stateDataStore
        )
        {
            _flowTarget = flowTarget;

            _transitionResolver = transitionResolver;
            _flowStore = flowStore;
            _stateDataStore = stateDataStore;
        }

        public void Transit(UserEntity? user, ITransitionableEntity entity, string newState)
        {
            Transit<Unit>(user, entity, newState, data: Unit.Value);
        }


        public void Transit<TData>(UserEntity? user, ITransitionableEntity entity, string newState, TData? data)
        {
            // get flow assigned to the entity or default
            var flow = _flowStore.GetFlow(entity.Id, _flowTarget);
            if (flow == null)
            {
                throw new Exception($"Flow not found.");
            }

            // ensure transition is possible
            var nextStates = flow.StateTree.GetNextStates(entity.State);
            var nextState = nextStates.SingleOrDefault(x => x.Child.State == newState);
            if (nextState == null)
            {
                throw new Exception($"Transition from state {entity.State} to state {newState} doesn't exist.");
            }

            // authorization
            if(nextState.AllowedRoles.Any())
            {
                if(user == null || !nextState.AllowedRoles.Any(role => user.Roles.Contains(role)))
                {
                    throw new Exception($"Unauthorized.");
                }
            }

            // resolve transition
            var transition = _transitionResolver.Resolve<TData>(nextState.TransitionNameId);
        
            // get state data from DB
            var stateData = _stateDataStore.GetStateData(entity.Id, entity.State);

            var transitionData = new TransitionData<TData>()
            {
                User = user,
                Entity = entity,
                NewState = newState,
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

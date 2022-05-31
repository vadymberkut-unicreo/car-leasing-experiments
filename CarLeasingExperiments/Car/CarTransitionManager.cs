using CarLeasingExperiments.Constants;
using CarLeasingExperiments.Entities;
using CarLeasingExperiments.Infrustructure;
using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Car
{
    public class CarTransitionManager : TransitionManager, ICarTransitionManager
    {
        public CarTransitionManager(
            ITransitionResolver transitionResolver,
            IFlowStore flowStore,
            IStateDataStore stateDataStore
        ) : base(
            FlowTargets.Car,
            transitionResolver,
            flowStore,
            stateDataStore
        )
        {
        }
    }
}

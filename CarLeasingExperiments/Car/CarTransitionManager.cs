using CarLeasingExperiments.Entities;
using CarLeasingExperiments.Infrustructure;
using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Car
{
    public class CarTransitionManager : TransitionManager, ICarTransitionManager
    {
        public CarTransitionManager(
            IServiceProvider serviceProvider,
            IStateDataStore stateDataStore,
            ICarStateTree stateTree
        ) : base(serviceProvider, stateDataStore, stateTree)
        {
        }
    }
}

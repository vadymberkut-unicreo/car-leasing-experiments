using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Car
{
    public class CarStateTree : StateTree, ICarStateTree
    {
        public CarStateTree(StateEnum state) : base(state)
        {
        }
    }
}

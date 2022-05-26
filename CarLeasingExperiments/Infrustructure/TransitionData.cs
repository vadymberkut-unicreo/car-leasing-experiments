using CarLeasingExperiments.Entities;

namespace CarLeasingExperiments.Infrustructure
{
    public class TransitionData<TData> : ITransitionData<TData>
    {
        public UserEntity? User { get; set; }
        public ITransitionableEntity Entity { get; set; }
        public TData? Data { get; set; }
    }
}

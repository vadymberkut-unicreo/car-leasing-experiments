using MediatR;
using CarLeasingExperiments.Entities;

namespace CarLeasingExperiments.Infrustructure
{
    public interface ITransitionData<TData>
    {
        public UserEntity? User { get; set; }
        public ITransitionableEntity Entity { get; set; }
        public TData? Data { get; set; }
    }

    public interface ITransitionData : ITransitionData<Unit>
    {
        TData GetData<TData>();
    }
}

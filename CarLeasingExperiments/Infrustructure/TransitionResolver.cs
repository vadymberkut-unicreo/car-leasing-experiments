namespace CarLeasingExperiments.Infrustructure
{
    public class TransitionResolver : ITransitionResolver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ITransitionRegister _transitionRegister;

        public TransitionResolver(
            IServiceProvider serviceProvider,
            ITransitionRegister transitionRegister
        )
        {
            _serviceProvider = serviceProvider;
            _transitionRegister = transitionRegister;
        }

        public ITransition<TData> Resolve<TData>(string nameId)
        {
            // resolve transition from DI
            var transitionType = _transitionRegister.GetTransitionType(nameId);
            if(transitionType == null)
            {
                throw new Exception($"Transition type for {nameId} isn't registered.");
            }

            var transitionObj = _serviceProvider.GetService(transitionType);
            if (transitionObj == null)
            {
                throw new Exception($"Transition of type {transitionType.Name} isn't registered in DI.");
            }

            var transition = transitionObj as ITransition<TData>;
            if (transition == null)
            {
                throw new Exception($"Transition of type {transitionType.Name} doesn't expect data of type {typeof(TData).Name}.");
            }

            return transition;
        }
    }
}

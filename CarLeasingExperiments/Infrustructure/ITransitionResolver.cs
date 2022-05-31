namespace CarLeasingExperiments.Infrustructure
{
    public interface ITransitionResolver
    {
        ITransition<TData> Resolve<TData>(string nameId);
    }
}

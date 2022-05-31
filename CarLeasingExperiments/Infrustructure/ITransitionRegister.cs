namespace CarLeasingExperiments.Infrustructure
{
    public interface ITransitionRegister
    {
        Type? GetTransitionType(string transitionNameId);
    }
}

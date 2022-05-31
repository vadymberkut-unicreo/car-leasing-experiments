namespace CarLeasingExperiments.State
{
    public interface IStateTreeChild
    {
        IStateTree Child { get; set; }
        string TransitionNameId { get; set; }
        IEnumerable<string> AllowedRoles { get; set; }
    }
}

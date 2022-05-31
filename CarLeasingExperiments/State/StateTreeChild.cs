namespace CarLeasingExperiments.State
{
    public class StateTreeChild : IStateTreeChild
    {
        public IStateTree Child { get; set; }
        public string TransitionNameId { get; set; }
        public IEnumerable<string> AllowedRoles { get; set; } = new List<string>();
    }
}

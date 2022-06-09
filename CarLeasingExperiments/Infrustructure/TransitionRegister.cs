using CarLeasingExperiments.Constants;
using CarLeasingExperiments.Transitions;

namespace CarLeasingExperiments.Infrustructure
{
    public class TransitionRegister : ITransitionRegister
    {
        /// <summary>
        /// Maps transition nameId to transition type
        /// </summary>
        private readonly IDictionary<string, Type> _register = new Dictionary<string, Type>()
        {
            { TransitionNameIds.ToATransition, typeof(ToATransition) },
            { TransitionNameIds.ToBTransition, typeof(ToBTransition) },
            { TransitionNameIds.ToCTransition, typeof(ToCTransition) },
            { TransitionNameIds.ToDTransition, typeof(ToDTransition) },
        };

        public Type? GetTransitionType(string transitionNameId)
        {
            if(_register.TryGetValue(transitionNameId, out Type? type))
            {
                return type;
            }
            else
            {
                return null;
            }
        }
    }
}

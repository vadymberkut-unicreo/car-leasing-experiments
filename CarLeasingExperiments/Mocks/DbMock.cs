using CarLeasingExperiments.Car;
using CarLeasingExperiments.Constants;
using CarLeasingExperiments.Entities;
using CarLeasingExperiments.State;

namespace CarLeasingExperiments.Mocks
{
    public static class DbMock
    {
        public static List<FlowEntity> Flows = new List<FlowEntity>()
        {
            new FlowEntity()
            {
                Id = "MainCarFlow",
                Name = "Main car flow",
                Target = FlowTargets.Car,
                IsDefault = true,
                StateTree = new StateTree(StateNameIds.Initial).AddNextState(
                    transitionNameId: TransitionNameIds.ToATransition,
                    allowedRoles: new string[] { "SuperAdmin" },
                    child: new StateTree(StateNameIds.StateA)
                        .AddNextState(
                            transitionNameId: TransitionNameIds.AToBTransition,
                            allowedRoles: new string[] { "Admin", "Dealer" },
                             child: new StateTree(StateNameIds.StateB)
                                .AddNextState(
                                    transitionNameId: TransitionNameIds.BToCTransition,
                                    allowedRoles: new string[] { "Dealer" },
                                    child: new StateTree(StateNameIds.StateC)
                                )
                                .AddNextState(
                                    transitionNameId: TransitionNameIds.BToDTransition,
                                    allowedRoles: new string[] { "Dealer" },
                                    child: new StateTree(StateNameIds.StateD)
                                )
                        )
                ),
            },
            new FlowEntity()
            {
                Id = "AlternativeCarFlow",
                Name = "Alternative car flow",
                Target = FlowTargets.Car,
                IsDefault = false,
                 StateTree = new StateTree(StateNameIds.Initial).AddNextState(
                    transitionNameId: TransitionNameIds.ToATransition,
                    allowedRoles: new string[] { },
                    child: new StateTree(StateNameIds.StateA)
                        .AddNextState(
                            transitionNameId: TransitionNameIds.AToBTransition,
                            allowedRoles: new string[] { },
                            child: new StateTree(StateNameIds.StateB)
                        )
                ),
            },
        };

        public static List<EntityFlowEntity> EntityFlows = new List<EntityFlowEntity>()
        {
            new EntityFlowEntity()
            {
                EntityId = "Car1",
                FlowId = "MainCarFlow",
            },
            new EntityFlowEntity()
            {
                EntityId = "Car2",
                FlowId = "AlternativeCarFlow",
            },
        };

        public static List<CarEntity> Cars = new List<CarEntity>()
        {
            new CarEntity()
            {
                Id = "Car1",
                State = StateNameIds.Initial,
            },
            new CarEntity()
            {
                Id = "Car2",
                State = StateNameIds.Initial,
            },
            new CarEntity()
            {
                Id = "Car3",
                State = StateNameIds.Initial,
            },
        };
    }
}

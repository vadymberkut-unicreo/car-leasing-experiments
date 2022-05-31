using CarLeasingExperiments.Constants;
using CarLeasingExperiments.Entities;
using CarLeasingExperiments.Mocks;

namespace CarLeasingExperiments.Infrustructure
{
    public class FlowStore : IFlowStore
    {
        public FlowEntity? GetFlow(string entityId, string target)
        {
            // for instance:
            var entityFlow = DbMock.EntityFlows.FirstOrDefault(x => x.EntityId == entityId);
            if(entityFlow != null)
            {
                return DbMock.Flows.FirstOrDefault(x => x.Id == entityFlow.FlowId);
            }
            else
            {
                return DbMock.Flows.FirstOrDefault(x => x.Target == target && x.IsDefault);
            }
        }

        public EntityFlowEntity SetEntityFlow(string entityId, string flowId)
        {
            var existing = DbMock.EntityFlows.FirstOrDefault(x => x.EntityId == entityId && x.FlowId == flowId);
            if(existing != null)
            {
                return existing;
            }
            else
            {
                var created = new EntityFlowEntity()
                {
                    EntityId = entityId,
                    FlowId = flowId,
                };
                DbMock.EntityFlows.Add(created);
                return created;
            }
        }
    }
}

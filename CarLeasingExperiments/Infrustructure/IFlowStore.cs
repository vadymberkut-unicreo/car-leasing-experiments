using CarLeasingExperiments.Entities;

namespace CarLeasingExperiments.Infrustructure
{
    public interface IFlowStore
    {
        FlowEntity? GetFlow(string entityId, string target);
        EntityFlowEntity SetEntityFlow(string entityId, string flowId);
    }
}

namespace Dijkstra
{
    public class NoConstraint : IConstraint<CostDurationStepGraphData>
    {
        public bool IsConstrainted(CostDurationStepGraphData graphData) => false;
    }
}


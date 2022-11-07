namespace Dijkstra
{
    public class NoConstraint : IGraphConstraint<CostDurationStepGraphData>
    {
        public bool IsConstrainted(CostDurationStepGraphData graphData) => false;
    }
}


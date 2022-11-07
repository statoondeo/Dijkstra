namespace Dijkstra
{
    public class StepConstraint : IGraphConstraint<CostDurationStepGraphData>
    {
        protected int MaxSteps;

        public StepConstraint(int maxSteps) => MaxSteps = maxSteps;

        public bool IsConstrainted(CostDurationStepGraphData graphData)
        {
            if (null == graphData) throw new ArgumentNullException(nameof(graphData));
            return (MaxSteps < graphData.Steps);
        }
    }
}


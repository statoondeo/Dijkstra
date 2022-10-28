using System;

namespace Dijkstra
{
    public class StepConstraint : IConstraint<CostDurationStepGraphData>
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


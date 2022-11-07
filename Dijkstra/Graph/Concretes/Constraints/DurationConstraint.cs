using System;

namespace Dijkstra
{
    public class DurationConstraint : IGraphConstraint<CostDurationStepGraphData>
    {
        protected int MaxDuration;

        public DurationConstraint(int maxDuration) => MaxDuration = maxDuration;

        public bool IsConstrainted(CostDurationStepGraphData graphData)
        {
            if (null == graphData) throw new ArgumentNullException(nameof(graphData));
            return (MaxDuration < graphData.Duration);
        }
    }
}


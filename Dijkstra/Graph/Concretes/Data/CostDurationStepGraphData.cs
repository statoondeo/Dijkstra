using System.Diagnostics.CodeAnalysis;

namespace Dijkstra
{
    public class CostDurationStepGraphData : IGraphData
    {
        public int Cost { get; protected set; }
        public int Duration { get; protected set; }
        public int Steps { get; protected set; }

        public CostDurationStepGraphData() : this(0, 0, 0) { }
        public CostDurationStepGraphData(int cost, int duration, int steps = 1)
        {
            Cost = cost;
            Duration = duration;
            Steps = steps;
		}

		public IGraphData Add(params IGraphData[] data)
        {
            if (null == data) return (this);

            int cost = Cost;
            int duration = Duration;
            int steps = Steps;
            for (int i = 0; i < data.Length; i++)
            {
                CostDurationStepGraphData graphData = (CostDurationStepGraphData)data[i];
                cost += graphData.Cost;
                duration += graphData.Duration;
                steps += graphData.Steps;
            }
            return (new CostDurationStepGraphData(cost, duration, steps));
        }
        public void Reset()
        {
            Cost = 0;
            Duration = 0;
            Steps = 0;
		}

        public override string ToString() => $"({Cost}, {Duration}, {Steps})";
        public int CompareTo([AllowNull] IGraphData other)
        {
            CostDurationStepGraphData graphData = (CostDurationStepGraphData)other ?? throw new ArgumentNullException(nameof(other));
            IList<int> paramDataByPriority = new List<int> { graphData.Cost, graphData.Duration, graphData.Steps };
            IList<int> dataByPriority = new List<int> { Cost, Duration, Steps };
            for (int i = 0; i < dataByPriority.Count; i++)
            {
                int compareResult = dataByPriority[i].CompareTo(paramDataByPriority[i]);
                if (compareResult != 0) return (compareResult);
            }
            return (0);
        }
    }
}


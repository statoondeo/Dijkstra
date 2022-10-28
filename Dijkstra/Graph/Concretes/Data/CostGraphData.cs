using System.Diagnostics.CodeAnalysis;

namespace Dijkstra
{
    public class CostGraphData : IGraphData
    {
        public int Cost { get; protected set; }

        public CostGraphData(int cost) => Cost = cost;

        public IGraphData Add(params IGraphData[] data)
        {
            if (null == data) return (this);
            int cost = Cost;
            for (int i = 0; i < data.Length; i++) cost += ((CostGraphData)data[i]).Cost;
            return (new CostGraphData(cost));
        }

        public void Reset() => Cost = 0;

        public int CompareTo([AllowNull] IGraphData other) => null == other ? Cost.CompareTo(null) : Cost.CompareTo(((CostGraphData)other).Cost);
    }
}


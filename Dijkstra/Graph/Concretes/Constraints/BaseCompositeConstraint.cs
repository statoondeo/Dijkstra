using System;
using System.Collections.Generic;

namespace Dijkstra
{
    public abstract class BaseCompositeConstraint<T> : IConstraint<T> where T : IGraphData
    {
        protected List<IConstraint<T>> Constraints;

        protected BaseCompositeConstraint(List<IConstraint<T>> constraints) => Constraints = constraints ?? throw new ArgumentNullException(nameof(constraints));

        public abstract bool IsConstrainted(T graphData);
    }
}


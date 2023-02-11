using System.Collections.Concurrent;

namespace Application.Common.Specifications
{
    public abstract class Specification<T>
    {
        private static readonly ConcurrentDictionary<string, Func<T, bool>> DelegateCache = new();
        private readonly List<string> cacheKey;

        protected Specification() => this.cacheKey = new List<string> { this.GetType().Name };

        protected virtual bool Include => true;
    }
}

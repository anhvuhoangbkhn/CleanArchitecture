using Domain.Common.Events;

namespace Domain.Common.Entities.Models
{
    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> Events { get; }

        void ClearEvents();
    }
}

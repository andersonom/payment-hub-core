using System;
using MediatR;

namespace PaymentHub.Core.Messages.CommonMessages
{
    public abstract class DomainEvent : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Timestamp = DateTime.UtcNow;
        }
    }
}
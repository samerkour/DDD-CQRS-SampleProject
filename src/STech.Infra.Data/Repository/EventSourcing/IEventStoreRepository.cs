using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using STech.Domain.Core.Events;

namespace STech.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        Task<IList<StoredEvent>> All(Guid aggregateId);
    }
}
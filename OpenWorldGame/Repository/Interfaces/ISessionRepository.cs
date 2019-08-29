using Repository.POCO;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface ISessionRepository : IRepository<Session>
    {
        IEnumerable<EventAmount> GetLastEvents();
    }
}
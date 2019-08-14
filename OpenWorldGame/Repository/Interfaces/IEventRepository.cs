using System.Collections;
using System.Collections.Generic;
using Repository.POCO;

namespace Repository.Interfaces
{
    public interface IEventRepository:IRepository<Event>
    {
        IEnumerable<EventAmount> GetAllEventAmounts();

        IEnumerable<EventAmount> GetNextEvents(string name);
    }
}
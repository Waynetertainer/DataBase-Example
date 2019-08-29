using System.Collections;
using System.Collections.Generic;
using Repository.POCO;

namespace Repository.Interfaces
{
    public interface IEventRepository:IRepository<Event>
    {
        /// <summary>
        /// Counts how often each Event occours
        /// </summary>
        /// <returns>
        /// Each Event withy the nuber of times it occours
        /// </returns>
        IEnumerable<EventAmount> GetAllEventAmounts();

        /// <summary>
        /// Finds every Event that follows after a given Event with the same Session
        /// </summary>
        /// <param name="name">The name of the given Event</param>
        /// <returns>
        /// Every Event that follows after a given Event with the same Session
        /// </returns>
        IEnumerable<EventAmount> GetNextEvents(string name);
    }
}
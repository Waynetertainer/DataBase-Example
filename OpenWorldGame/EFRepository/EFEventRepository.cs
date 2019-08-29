using Repository.Interfaces;
using Repository.POCO;
using System.Collections.Generic;
using System.Linq;

namespace EFRepository
{
    public class EFEventRepository : EFRepository<Event>, IEventRepository
    {
        public EFEventRepository(Context ctx) : base(ctx)
        {
        }

        /// <summary>
        /// Counts how often each Event occours
        /// </summary>
        /// <returns>
        /// Each Event withy the nuber of times it occours
        /// </returns>
        public IEnumerable<EventAmount> GetAllEventAmounts()
        {
            return ctx.Events.GroupBy(T => T.Name).Select(T => new EventAmount()
            {
                Name = T.Key,
                Amount = T.Count()
            })
            .OrderByDescending(T => T.Amount).ToList();
        }

        /// <summary>
        /// Finds every Event that follows after a given Event with the same Session
        /// </summary>
        /// <param name="name">The name of the given Event</param>
        /// <returns>
        /// Every Event that follows after a given Event with the same Session
        /// </returns>
        public IEnumerable<EventAmount> GetNextEvents(string name)
        {
            return ctx.Events
                .Where(T => T.Name == name)
                .SelectMany
                (
                    T => ctx.Events
                        .Where(e => e.SessionID == T.SessionID && e.TimeStampTicks > T.TimeStampTicks)
                        .OrderBy(t => t.TimeStampTicks).Take(1)
                )
                .GroupBy(T => T.Name)
                .Select(T => new EventAmount()
                {
                    Name = T.Key,
                    Amount = T.Count()
                })
                .OrderByDescending(T => T.Amount).ToList();

        }
    }
}

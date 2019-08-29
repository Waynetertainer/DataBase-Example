using Repository.Interfaces;
using Repository.POCO;
using System.Collections.Generic;
using System.Linq;

namespace EFRepository
{
    public class EFSessionRepository : EFRepository<Session>, ISessionRepository
    {
        public EFSessionRepository(Context ctx) : base(ctx)
        {
        }

        /// <summary>
        /// Finds every Event that is the last in its Session
        /// </summary>
        /// <returns>
        /// The last Event of every Session
        /// </returns>
        public IEnumerable<EventAmount> GetLastEvents()
        {
            return ctx.Sessions.SelectMany
                (
                    S => S.Events.OrderByDescending(E => E.TimeStampTicks).Take(1)
                )
                .GroupBy(E => E.Name)
                .Select(T => new EventAmount()
                {
                    Name = T.Key,
                    Amount = T.Count()
                })
                .OrderByDescending(T => T.Amount).ToList();
        }
    }
}

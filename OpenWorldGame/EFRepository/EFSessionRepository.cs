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

        public IEnumerable<EventAmount> GetLastEvents()
        {
            return ctx.Sessions.SelectMany
                (
                    S => S.Events.OrderByDescending(E => E.TimeStamp).Take(1)
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

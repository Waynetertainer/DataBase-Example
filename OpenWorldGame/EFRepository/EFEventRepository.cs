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

        public IEnumerable<EventAmount> GetAllEventAmounts()
        {
            IEnumerable<int> test()
            {
                foreach (EventAmount allEventAmount in GetAllEventAmounts())
                {
                    if (allEventAmount.Amount > 2)
                    {
                        yield return allEventAmount.Amount;
                    }
                    yield break;
                }

            }
            return ctx.Events.GroupBy(T => T.Name).Select(T => new EventAmount()
            {
                Name = T.Key,
                Amount = T.Count()
            })
            .OrderByDescending(T => T.Amount).ToList();

        }

        public IEnumerable<EventAmount> GetNextEvents(string name)
        {
            return ctx.Events
                .Where(T => T.Name == name)
                .SelectMany
                (
                    T => ctx.Events
                        .Where(e => e.SessionID == T.SessionID && e.TimeStamp > T.TimeStamp)
                        .OrderBy(t => t.TimeStamp).Take(1)
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

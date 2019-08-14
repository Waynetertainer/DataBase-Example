using Common;
using Common.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class Service<S> : IService where S : Repository.Interfaces.ISessionScope, new()
    {
        private Controller mController = new Controller(() => new S());

        public Event CreateEvent(string name, int sessionID)
        {
            return mController.CreateEvent(name, sessionID).ToDTO();
        }

        public Session CreateSession()
        {
            return mController.CreateSession().ToDTO();
        }

        public Session GetSessionByID(int id)
        {
            return mController.GetSessionByID(id).ToDTO();
        }

        public Event GetEventByID(int id)
        {
            return mController.GetEventByID(id).ToDTO();
        }

        public IEnumerable<EventAmount> GetAllEventAmounts()
        {
            return mController.GetAllEventAmounts().Select(T => T.ToDTO());
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return mController.GetAllEvents().Select(T => T.ToDTO());
        }

        public IEnumerable<Session> GetAllSessions()
        {
            return mController.GetAllSessions().Select(T => T.ToDTO());
        }

        public IEnumerable<EventAmount> GetNextEvents(string name)
        {
            return mController.GetNextEvents(name).Select(T=>T.ToDTO());
        }

        public IEnumerable<EventAmount> GetLastEvents()
        {
            return mController.GetLastEvents().Select(T => T.ToDTO());
        }
    }
}
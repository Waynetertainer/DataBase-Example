using Repository.Interfaces;
using Repository.POCO;
using System.Collections.Generic;

namespace Server
{
    public delegate ISessionScope Factory();

    public class Controller
    {
        private Factory mScope;

        public Controller(Factory scope)
        {
            mScope = scope;
        }

        public Session CreateSession()
        {
            using (var scope = mScope.Invoke())
            {
                Session session = scope.SessionRepository.Create(new Session());
                scope.SaveChanges();
                return session;
            }
        }

        public Event CreateEvent(string name, int sessionID)
        {
            using (var scope = mScope.Invoke())
            {
                Event ev = scope.EventRepository.Create(new Event(name, sessionID));
                scope.SaveChanges();
                return ev;
            }
        }

        public IEnumerable<EventAmount> GetAllEventAmounts()
        {
            using (var scope = mScope.Invoke())
            {
                return scope.EventRepository.GetAllEventAmounts();
            }
        }

        public Session GetSessionByID(int id)
        {
            using (var scope = mScope.Invoke())
            {
                return scope.SessionRepository.GetByID(id);
            }
        }

        public Event GetEventByID(int id)
        {
            using (var scope = mScope.Invoke())
            {
                return scope.EventRepository.GetByID(id);
            }
        }

        public IEnumerable<Event> GetAllEvents()
        {
            using (var scope = mScope.Invoke())
            {
                return scope.EventRepository.GetAll();
            }
        }

        public IEnumerable<Session> GetAllSessions()
        {
            using (var scope = mScope.Invoke())
            {
                return scope.SessionRepository.GetAll();
            }
        }

        public IEnumerable<EventAmount> GetNextEvents(string name)
        {
            using (var scope = mScope.Invoke())
            {
                return scope.EventRepository.GetNextEvents(name);
            }
        }

        public IEnumerable<EventAmount> GetLastEvents()
        {
            using (var scope = mScope.Invoke())
            {
                return scope.SessionRepository.GetLastEvents();
            }
        }
    }
}
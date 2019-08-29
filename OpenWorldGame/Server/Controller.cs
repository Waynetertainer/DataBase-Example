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

        /// <summary>
        /// Creates a Session
        /// </summary>
        /// <returns>
        /// The created Session
        /// </returns>
        public Session CreateSession()
        {
            using (var scope = mScope.Invoke())
            {
                Session session = scope.SessionRepository.Create(new Session());
                scope.SaveChanges();
                return session;
            }
        }

        /// <summary>
        /// Creates an Event
        /// </summary>
        /// <param name="name">The name of the Event</param>
        /// <param name="sessionID">The sessionID of the event</param>
        /// <returns>
        /// The Created Event
        /// </returns>
        public Event CreateEvent(string name, int sessionID)
        {
            using (var scope = mScope.Invoke())
            {
                Event ev = scope.EventRepository.Create(new Event(name, sessionID));
                scope.SaveChanges();
                return ev;
            }
        }

        /// <summary>
        /// Counts how often each Event occours
        /// </summary>
        /// <returns>
        /// Each Event withy the nuber of times it occours
        /// </returns>
        public IEnumerable<EventAmount> GetAllEventAmounts()
        {
            using (var scope = mScope.Invoke())
            {
                return scope.EventRepository.GetAllEventAmounts();
            }
        }

        /// <summary>
        /// Finds a Session by ID
        /// </summary>
        /// <param name="id">The ID of the Session</param>
        /// <returns>
        /// The Session with the given ID
        /// </returns>
        public Session GetSessionByID(int id)
        {
            using (var scope = mScope.Invoke())
            {
                return scope.SessionRepository.GetByID(id);
            }
        }

        /// <summary>
        /// Finds an Event by ID
        /// </summary>
        /// <param name="id">The ID of the Event</param>
        /// <returns>
        /// The Event with the given ID
        /// </returns>
        public Event GetEventByID(int id)
        {
            using (var scope = mScope.Invoke())
            {
                return scope.EventRepository.GetByID(id);
            }
        }

        /// <summary>
        /// Returns all Events
        /// </summary>
        /// <returns>
        /// All Events
        /// </returns>
        public IEnumerable<Event> GetAllEvents()
        {
            using (var scope = mScope.Invoke())
            {
                return scope.EventRepository.GetAll();
            }
        }

        /// <summary>
        /// Returns all Sessions
        /// </summary>
        /// <returns>
        /// All Sessions
        /// </returns>
        public IEnumerable<Session> GetAllSessions()
        {
            using (var scope = mScope.Invoke())
            {
                return scope.SessionRepository.GetAll();
            }
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
            using (var scope = mScope.Invoke())
            {
                return scope.EventRepository.GetNextEvents(name);
            }
        }

        /// <summary>
        /// Finds every Event that is the last in its Session
        /// </summary>
        /// <returns>
        /// The last Event of every Session
        /// </returns>
        public IEnumerable<EventAmount> GetLastEvents()
        {
            using (var scope = mScope.Invoke())
            {
                return scope.SessionRepository.GetLastEvents();
            }
        }
    }
}
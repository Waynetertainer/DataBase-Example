using Common;
using Common.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class Service<S> : IService where S : Repository.Interfaces.ISessionScope, new()
    {
        private Controller mController = new Controller(() => new S());

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
            return mController.CreateEvent(name, sessionID).ToDTO();
        }

        /// <summary>
        /// Creates a Session
        /// </summary>
        /// <returns>
        /// The created Session
        /// </returns>
        public Session CreateSession()
        {
            return mController.CreateSession().ToDTO();
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
            return mController.GetSessionByID(id).ToDTO();
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
            return mController.GetEventByID(id).ToDTO();
        }

        /// <summary>
        /// Counts how often each Event occours
        /// </summary>
        /// <returns>
        /// Each Event withy the nuber of times it occours
        /// </returns>
        public IEnumerable<EventAmount> GetAllEventAmounts()
        {
            return mController.GetAllEventAmounts().Select(T => T.ToDTO());
        }

        /// <summary>
        /// Returns all Events
        /// </summary>
        /// <returns>
        /// All Events
        /// </returns>
        public IEnumerable<Event> GetAllEvents()
        {
            return mController.GetAllEvents().Select(T => T.ToDTO());
        }

        /// <summary>
        /// Returns all Sessions
        /// </summary>
        /// <returns>
        /// All Sessions
        /// </returns>
        public IEnumerable<Session> GetAllSessions()
        {
            return mController.GetAllSessions().Select(T => T.ToDTO());
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
            return mController.GetNextEvents(name).Select(T => T.ToDTO());
        }

        /// <summary>
        /// Finds every Event that is the last in its Session
        /// </summary>
        /// <returns>
        /// The last Event of every Session
        /// </returns>
        public IEnumerable<EventAmount> GetLastEvents()
        {
            return mController.GetLastEvents().Select(T => T.ToDTO());
        }
    }
}
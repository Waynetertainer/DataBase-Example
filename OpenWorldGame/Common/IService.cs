using Common.DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IService
    {
        /// <summary>
        /// Creates an Event
        /// </summary>
        /// <param name="name">The name of the Event</param>
        /// <param name="sessionID">The sessionID of the event</param>
        /// <returns>
        /// The Created Event
        /// </returns>
        [OperationContract]
        Event CreateEvent(string name, int sessionID);

        /// <summary>
        /// Creates a Session
        /// </summary>
        /// <returns>
        /// The created Session
        /// </returns>
        [OperationContract]
        Session CreateSession();

        /// <summary>
        /// Finds a Session by ID
        /// </summary>
        /// <param name="id">The ID of the Session</param>
        /// <returns>
        /// The Session with the given ID
        /// </returns>
        [OperationContract]
        Session GetSessionByID(int id);

        /// <summary>
        /// Finds an Event by ID
        /// </summary>
        /// <param name="id">The ID of the Event</param>
        /// <returns>
        /// The Event with the given ID
        /// </returns>
        [OperationContract]
        Event GetEventByID(int id);

        /// <summary>
        /// Counts how often each Event occours
        /// </summary>
        /// <returns>
        /// Each Event withy the nuber of times it occours
        /// </returns>
        [OperationContract]
        IEnumerable<EventAmount> GetAllEventAmounts();

        /// <summary>
        /// Returns all Events
        /// </summary>
        /// <returns>
        /// All Events
        /// </returns>
        [OperationContract]
        IEnumerable<Event> GetAllEvents();

        /// <summary>
        /// Returns all Sessions
        /// </summary>
        /// <returns>
        /// All Sessions
        /// </returns>
        [OperationContract]
        IEnumerable<Session> GetAllSessions();

        /// <summary>
        /// Finds every Event that follows after a given Event with the same Session
        /// </summary>
        /// <param name="name">The name of the given Event</param>
        /// <returns>
        /// Every Event that follows after a given Event with the same Session
        /// </returns>
        [OperationContract]
        IEnumerable<EventAmount> GetNextEvents(string name);

        /// <summary>
        /// Finds every Event that is the last in its Session
        /// </summary>
        /// <returns>
        /// The last Event of every Session
        /// </returns>
        [OperationContract]
        IEnumerable<EventAmount> GetLastEvents();
    }
}
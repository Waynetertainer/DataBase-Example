using Common;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace OpenWorldGame
{
    public class Consumer : IService, IDisposable
    {
        private ChannelFactory<IService> mFactory;


        public Consumer()
        {
            Uri baseAddress = new Uri("net.tcp://localhost:8009/OpenWorldGame");
            EndpointAddress address = new EndpointAddress(baseAddress);
            NetTcpBinding binding = new NetTcpBinding();
            mFactory = new ChannelFactory<IService>(binding, address);
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
            IService service = mFactory.CreateChannel();
            Event ev = service.CreateEvent(name, sessionID);

            (service as IChannel).Close();
            return ev;
        }

        /// <summary>
        /// Creates a Session
        /// </summary>
        /// <returns>
        /// The created Session
        /// </returns>
        public Session CreateSession()
        {
            IService service = mFactory.CreateChannel();
            Session session = service.CreateSession();

            (service as IChannel).Close();
            return session;
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
            IService service = mFactory.CreateChannel();
            Session session = service.GetSessionByID(id);
            (service as IChannel).Close();
            return session;
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
            IService service = mFactory.CreateChannel();
            Event ev = service.GetEventByID(id);
            (service as IChannel).Close();
            return ev;
        }

        /// <summary>
        /// Counts how often each Event occours
        /// </summary>
        /// <returns>
        /// Each Event withy the nuber of times it occours
        /// </returns>
        public IEnumerable<EventAmount> GetAllEventAmounts()
        {
            IService service = mFactory.CreateChannel();
            var result = service.GetAllEventAmounts();
            (service as IChannel).Close();
            return result;
        }

        /// <summary>
        /// Returns all Events
        /// </summary>
        /// <returns>
        /// All Events
        /// </returns>
        public IEnumerable<Event> GetAllEvents()
        {
            IService service = mFactory.CreateChannel();
            var result = service.GetAllEvents();
            (service as IChannel).Close();
            return result;
        }

        /// <summary>
        /// Returns all Sessions
        /// </summary>
        /// <returns>
        /// All Sessions
        /// </returns>
        public IEnumerable<Session> GetAllSessions()
        {
            IService service = mFactory.CreateChannel();
            var result = service.GetAllSessions();
            (service as IChannel).Close();
            return result;
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
            IService service = mFactory.CreateChannel();
            var result = service.GetNextEvents(name);
            (service as IChannel).Close();
            return result;
        }

        /// <summary>
        /// Finds every Event that is the last in its Session
        /// </summary>
        /// <returns>
        /// The last Event of every Session
        /// </returns>
        public IEnumerable<EventAmount> GetLastEvents()
        {
            IService service = mFactory.CreateChannel();
            var result = service.GetLastEvents();
            (service as IChannel).Close();
            return result;
        }

        #region IDisposable Support

        private bool mDisposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (mDisposedValue) return;
            if (disposing)
            {
                ((IDisposable)mFactory)?.Dispose();
            }
            mDisposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
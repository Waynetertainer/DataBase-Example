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

        public Event CreateEvent(string name, int sessionID)
        {
            IService service = mFactory.CreateChannel();
            Event ev = service.CreateEvent(name, sessionID);

            (service as IChannel).Close();
            return ev;
        }

        public Session CreateSession()
        {
            IService service = mFactory.CreateChannel();
            Session session = service.CreateSession();

            (service as IChannel).Close();
            return session;
        }

        public Session GetSessionByID(int id)
        {
            IService service = mFactory.CreateChannel();
            Session session = service.GetSessionByID(id);
            (service as IChannel).Close();
            return session;
        }

        public Event GetEventByID(int id)
        {
            IService service = mFactory.CreateChannel();
            Event ev = service.GetEventByID(id);
            (service as IChannel).Close();
            return ev;
        }

        public IEnumerable<EventAmount> GetAllEventAmounts()
        {
            IService service = mFactory.CreateChannel();
            var result = service.GetAllEventAmounts();
            (service as IChannel).Close();
            return result;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            IService service = mFactory.CreateChannel();
            var result = service.GetAllEvents();
            (service as IChannel).Close();
            return result;
        }

        public IEnumerable<Session> GetAllSessions()
        {
            IService service = mFactory.CreateChannel();
            var result = service.GetAllSessions();
            (service as IChannel).Close();
            return result;
        }

        public IEnumerable<EventAmount> GetNextEvents(string name)
        {
            IService service = mFactory.CreateChannel();
            var result = service.GetNextEvents(name);
            (service as IChannel).Close();
            return result;
        }

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
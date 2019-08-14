using System;
using System.ServiceModel;
using Common;
using Repository.Interfaces;

namespace Server
{
    public class Host<S> :IDisposable where S :ISessionScope, new()
    {
        private ServiceHost mHost =new ServiceHost(typeof(Service<S>));

        public void Open()
        {
            Uri baseAddress = new Uri("net.tcp://localhost:8009/OpenWorldGame");
            NetTcpBinding binding = new NetTcpBinding();
            mHost.AddServiceEndpoint(typeof(IService), binding, baseAddress);
            mHost.Open();
            Console.WriteLine("Server started");
        }

        public void Close()
        {
            mHost?.Close();
            Console.WriteLine("Server closed");
        }

        #region IDisposable Support

        private bool mDisposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (mDisposedValue) return;
            if (disposing)
            {
                ((IDisposable) mHost)?.Dispose();
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
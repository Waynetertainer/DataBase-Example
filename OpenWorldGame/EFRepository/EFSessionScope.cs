using Repository.Interfaces;
using System;

namespace EFRepository
{
    public class EFSessionScope : ISessionScope
    {
        private Lazy<Context> mContext = new Lazy<Context>(() => new Context(), false);
        public Context Context => mContext.Value;

        private Lazy<IEventRepository> mEventRepository;
        public IEventRepository EventRepository => mEventRepository.Value;

        private Lazy<ISessionRepository> mSessionRepository;
        public ISessionRepository SessionRepository => mSessionRepository.Value;

        public EFSessionScope()
        {
            mEventRepository = new Lazy<IEventRepository>(() => new EFEventRepository(Context), false);
            mSessionRepository = new Lazy<ISessionRepository>(() => new EFSessionRepository(Context), false);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }


        #region IDisposable Support

        private bool mDisposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (mDisposedValue) return;
            if (disposing)
            {
                if (mContext.IsValueCreated)
                {
                    mContext.Value.Dispose();
                }
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
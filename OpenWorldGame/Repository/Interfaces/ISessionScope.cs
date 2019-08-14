using System;

namespace Repository.Interfaces
{
    public interface ISessionScope:IDisposable
    {
        ISessionRepository SessionRepository { get; }
        IEventRepository EventRepository { get; }

        void SaveChanges();
    }
}
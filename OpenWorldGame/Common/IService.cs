using Common.DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Event CreateEvent(string name, int sessionID);

        [OperationContract]
        Session CreateSession();

        [OperationContract]
        Session GetSessionByID(int id);

        [OperationContract]
        Event GetEventByID(int id);

        [OperationContract]
        IEnumerable<EventAmount> GetAllEventAmounts();

        [OperationContract]
        IEnumerable<Event> GetAllEvents();

        [OperationContract]
        IEnumerable<Session> GetAllSessions();

        [OperationContract]
        IEnumerable<EventAmount> GetNextEvents(string name);

        [OperationContract]
        IEnumerable<EventAmount> GetLastEvents();
    }
}
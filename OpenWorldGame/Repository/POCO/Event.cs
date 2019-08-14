using System;

namespace Repository.POCO
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SessionID { get; set; }
        public Session Session { get; set; }
        public DateTime TimeStamp { get; set; }

        public Event()
        {
            
        }

        public Event( string name, int sessionID)
        {
            Name = name;
            SessionID = sessionID;
            TimeStamp=DateTime.Now;
        }
    }
}

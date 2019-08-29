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
        //Ticks were used because they are more precise than DateTime, which was kept for analytical reasons
        public long TimeStampTicks { get; set; }

        public Event()
        {

        }

        public Event(string name, int sessionID)
        {
            Name = name;
            SessionID = sessionID;
            TimeStamp = DateTime.Now;
            TimeStampTicks = TimeStamp.Ticks;
        }
    }
}

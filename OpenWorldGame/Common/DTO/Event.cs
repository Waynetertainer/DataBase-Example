using System;

namespace Common.DTO
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SessionID { get; set; }
        public DateTime TimeStamp { get; set; }
        public long TimeStampTicks { get; set; }
    }
}

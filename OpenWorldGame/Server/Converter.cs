namespace Server
{
    public static class Converter
    {
        public static Common.DTO.Session ToDTO(this Repository.POCO.Session session)
        {
            return new Common.DTO.Session()
            {
                ID = session.Id,
            };
        }

        public static Common.DTO.Event ToDTO(this Repository.POCO.Event ev)
        {
            return new Common.DTO.Event()
            {
                Name = ev.Name,
                SessionID = ev.SessionID,
                TimeStamp = ev.TimeStamp
            };
        }

        public static Common.DTO.EventAmount ToDTO(this Repository.POCO.EventAmount eventAmount)
        {
            return new Common.DTO.EventAmount()
            {
                Name = eventAmount.Name,
                Amount = eventAmount.Amount
            };
        }
    }
}

using Common.DTO;
using System;

namespace OpenWorldGame
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var consumer = new Consumer())
            {
                //Session session = consumer.CreateSession();
                //Event ev = consumer.CreateEvent("customEV", session.ID);
                //consumer.CreateEvent("customEV", session.ID);

                foreach (Event e in consumer.GetAllEvents())
                {
                    Console.WriteLine("Event name :{0}", e.Name);
                }

                var temp = consumer.GetAllSessions();
                foreach (Session s in consumer.GetAllSessions())
                {
                    Console.WriteLine("Session id :{0}", s.ID);
                }

                foreach (EventAmount amount in consumer.GetAllEventAmounts())
                {
                    Console.WriteLine("{0} {1}", amount.Name, amount.Amount);
                }
                Console.ReadKey();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFRepository;

namespace Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Test
            //Controller controller = new Controller(()=> new EFSessionScope());
            //Random rnd = new Random();

            //for (int i = 0; i < 25; i++)
            //{
            //    controller.CreateScore(rnd.Next(100), controller.CreateGame(rnd.Next(100000).ToString()).Id, controller.CreateUser(rnd.Next(100000).ToString()).Id);
            //}

            //foreach (var item in controller.GetGames())
            //{
            //    Console.WriteLine(item.Name);
            //} 
            #endregion

            using (Host<EFSessionScope> host = new Host<EFSessionScope>())
            {
                host.Open();
                Console.ReadLine();
                host.Close();
            }

        }
    }
}

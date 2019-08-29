using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using EFRepository;

namespace Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (Host<EFSessionScope> host = new Host<EFSessionScope>())
            {
                host.Open();
                Console.ReadLine();
                host.Close();
            }
        }
    }
}

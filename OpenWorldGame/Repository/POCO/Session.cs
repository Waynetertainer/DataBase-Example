using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.POCO
{
    public class Session
    {
        public int Id { get; set; }
        public ICollection<Event> Events { get; set; }

        public Session()
        {
        }
    }
}

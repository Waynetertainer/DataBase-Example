using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using Repository.POCO;


namespace EFRepository
{
    public class Context :DbContext
    {
        public Context() : base()
        {

        }

        static Context()
        {
            Database.SetInitializer<Context>(new Initializer());
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}

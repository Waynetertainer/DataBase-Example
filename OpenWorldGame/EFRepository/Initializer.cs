using System.Data.Entity;
using Repository.POCO;

namespace EFRepository
{
    public class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context ctx)
        {
            base.Seed(ctx);
        }
    }
}
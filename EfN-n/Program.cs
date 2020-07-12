using EfN_n.Data;
using Microsoft.EntityFrameworkCore;

namespace EfN_n
{
    class Program
    {
        static void Main(string[] args)
        {
            var applicationOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            applicationOptionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EfTestnn;Integrated Security=True");

            var context = new ApplicationDbContext(applicationOptionsBuilder.Options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            RoleSeed.Seed(context);
        }
    }
}

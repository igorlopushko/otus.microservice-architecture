using System.Linq;
using UserService.DataAccess.Data;
using UserService.DataAccess.Models;

namespace UserService.DataAccess.Migrations
{
    public class DbInitializer
    {
        public static void Initialize(UserContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var students = new User[]
            {
                new User {LastName = "Carson", FirstName = "Alexander", Email = "alexander.carson@gmail.com"},
                new User {LastName = "Meredith", FirstName = "Alonso", Email = "alonso.meredith@gmail.com"},
                new User {LastName = "Arturo", FirstName = "Anand", Email = "anand.arturo@gmail.com"},
                new User {LastName = "Gytis", FirstName = "Barzdukas", Email = "barzdukas.gytis@gmail.com"},
                new User {LastName = "Yan", FirstName = "Li", Email = "li.yan@gmail.com"},
                new User {LastName = "Peggy", FirstName = "Justice", Email = "justice.peggy@gmail.com"},
                new User {LastName = "Laura", FirstName = "Norman", Email = "norman.laura@gmail.com"},
                new User {LastName = "Nino", FirstName = "Olivetto", Email = "olivetto.nino@gmail.com"}
            };

            context.Users.AddRange(students);
            context.SaveChanges();
        }
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizCreation.Entities.Concrete;
using QuizCreation.Entities.Concrete.Identity;

namespace QuizCreation.DataAccess.Concrete.EntityFramework.Contexts
{
    public class QuizCreationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlite("Data Source=QuizCreation.db");
        public DbSet<Exam>? Exam { get; set; }
        public DbSet<Question>? Question { get; set; }
    }
}

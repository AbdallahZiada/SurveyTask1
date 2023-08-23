using DataAccessLayer.Models;
using System.Data.Entity;

namespace DataAccessLayer.Models
{
    public class AutomatedSurveysContext : DbContext
    {
        public AutomatedSurveysContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
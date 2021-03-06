using Microsoft.EntityFrameworkCore;
using RecruitmentExchange.Model;

namespace RecruitmentExchange.AppData
{
    class AppDBContext : DbContext 
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Deal> Deals { get; set; }

        public AppDBContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=REdata;Trusted_Connection=True;");
        }
    }
}

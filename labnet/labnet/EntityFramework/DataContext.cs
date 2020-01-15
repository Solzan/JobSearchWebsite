using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using labnet.Models;

namespace labnet.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobOffer> JobOfers { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
               
                new Company { Id = 11, Name = "Sharlotta" },
                new Company { Id = 12, Name = "Google" },
                new Company { Id = 13, Name = "Netflix"},
                new Company { Id = 14, Name = "Danone" }
            );
            modelBuilder.Entity<JobOffer>().HasData(

                new JobOffer { Id = 8, Company = "Sharlotta", JobDescription = "We are looking for cooker", JobTitle = "Cooker", EndDate = new DateTime(2020, 10, 01), StartDate = DateTime.Now, Location = "Warszaw", SalaryFrom = 8000, SalaryTo = 10000 },
             new JobOffer
             {
                 Id = 9,
                 Company = "Netflix",
                 JobDescription = "We are looking for Designer",
                 JobTitle = "Designer",
                 EndDate = new DateTime(2020, 10, 01),
                 StartDate = DateTime.Now,
                 Location = "New York",
                 SalaryFrom = 18000,
                 SalaryTo = 20000
            },
              new JobOffer
              {
                  Id = 10,
                  Company = "Netflix",
                  JobDescription = "We are looking for manager",
                  JobTitle = "Manager",
                  EndDate = new DateTime(2020, 10, 01),
                  StartDate = DateTime.Now,
                  Location = "New York",
                  SalaryFrom = 16000,
                  SalaryTo = 19000
              }

            );


        }


    }
}

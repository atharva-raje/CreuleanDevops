using DAL.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dbcontext
{
    public  class WorkItemsDbContext:DbContext

    {
        private readonly IConfiguration _config;

        public WorkItemsDbContext(IConfiguration configuration)
        {
            _config = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjectManagementDataBase;Trusted_Connection=True;TrustServerCertificate=True;");
            
        }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comments> Comments {  get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Iterations> Iterations { get; set; }
            
    }
}

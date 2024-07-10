/*using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL.Dbcontext
{
    public class WorkItemsDbContextFactory : IDesignTimeDbContextFactory<WorkItemsDbContext>
    {
        public WorkItemsDbContext CreateDbContext(string[] args)
        {
            // Create a configuration builder
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            // Add the appsettings.json file to the configuration
            configurationBuilder("D:\\adtechsource\\repos\\New_repository\\ceruleanDevops_a_projectManagement_tool\\WebApplication1\\appsettings.json", optional: false);

            // Build the configuration
            var configuration = configurationBuilder.Build();

            // Create options for DbContext
            var optionsBuilder = new DbContextOptionsBuilder<WorkItemsDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new WorkItemsDbContext(configuration);
        }
    }*//*
}*/
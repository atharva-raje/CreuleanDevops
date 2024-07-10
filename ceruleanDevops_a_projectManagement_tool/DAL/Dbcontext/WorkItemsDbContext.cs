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
        
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjectManagementDataBase;Trusted_Connection=True;TrustServerCertificate=True;");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkitemLink>()
                .HasOne(w => w.SourceWorkItem)
                .WithMany(w => w.SourceLinks)
                .HasForeignKey(w => w.SourceWorkItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkitemLink>()
                .HasOne(w => w.TargetWorkItem)
                .WithMany(w => w.TargetLinks)
                .HasForeignKey(w => w.TargetWorkItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.WorkItem)
                .WithMany(w => w.Comments)
                .HasForeignKey(c => c.WorkItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkItem>()
                .HasOne(w => w.Iteration)
                .WithMany(i => i.WorkItems)
                .HasForeignKey(w => w.IterationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WorkItem>()
                .HasOne(w => w.Status)
                .WithMany(s => s.WorkItems)
                .HasForeignKey(w => w.StatusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WorkItem>()
                .HasOne(w => w.Type)
                .WithMany(t => t.WorkItems)
                .HasForeignKey(w => w.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkItem>()
                .HasOne(w => w.Priority)
                .WithMany(p => p.WorkItems)
                .HasForeignKey(w => w.PriorityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WorkItem>()
                .HasOne(w => w.Area)
                .WithMany(a => a.WorkItems)
                .HasForeignKey(w => w.AreaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WorkItem>()
                .HasOne(w => w.Assignee)
                .WithMany(u => u.WorkItems)
                .HasForeignKey(w => w.AssigneeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FileUploads>()
                .HasOne(f => f.WorkItem)
                .WithMany(w => w.FileUploads)
                .HasForeignKey(f => f.WorkItemId)
                .OnDelete(DeleteBehavior.Cascade);


        }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comments> Comments {  get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Iterations> Iterations { get; set; }
        public DbSet<FileUploads> Files { get; set; }
        public DbSet<WorkitemLink> WorkitemLinks { get; set; }
        public DbSet<Types> Types{ get; set; }
        public DbSet<Priorities> Priorities { get; set; }
         
            
    }
}

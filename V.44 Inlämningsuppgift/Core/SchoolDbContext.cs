using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V._44_Inlämningsuppgift.Model;

namespace V._44_Inlämningsuppgift.Core
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Student>()
                //.ToTable("Students")
                .HasKey(x => x.StudentId);

            base.OnModelCreating(mb);
        }
    }
}

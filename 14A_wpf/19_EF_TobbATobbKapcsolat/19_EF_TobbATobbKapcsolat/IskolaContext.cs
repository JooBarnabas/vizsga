using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace _19_EF_TobbATobbKapcsolat
{
    public class IskolaContext : DbContext
    {
        public DbSet<Tanulo> Tanulo { get; set; }
        public DbSet<Teszt> Teszt { get; set; }
        public DbSet<TesztEredmenyek> TesztEredmenyek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=14a_IskolaDemo;Uid=root;Pwd=;",
                ServerVersion.AutoDetect("Server=localhost;Database=14a_IskolaDemo;Uid=root;Pwd=;"));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TesztEredmenyek>().HasKey(te => new { te.tanuloId, te.tesztId});
        //}
    }
}

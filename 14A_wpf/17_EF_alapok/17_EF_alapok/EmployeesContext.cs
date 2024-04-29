using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace _17_EF_alapok
{
    public class EmployeesContext : DbContext
    {
        public DbSet<People> People { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=14A_Employees;Uid=root;Pwd=;", 
                ServerVersion.AutoDetect("Server=localhost;Database=14A_Employees;Uid=root;Pwd=;"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().HasData(
                new People() { Id=1, Name="Béla", Job= "C# fejlesztő", Address = "Győr", Email = "bela@cegem.hu"},
                new People() { Id=2, Name="Józsi", Job= "Adatbázis fejlesztő", Address = "Győr", Email = "jozsi@cegem.hu"}
                );
        }



    }
}

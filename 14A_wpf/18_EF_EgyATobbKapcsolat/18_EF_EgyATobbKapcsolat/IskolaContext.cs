using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace _18_EF_EgyATobbKapcsolat
{
    public class IskolaContext :DbContext
    {
        public DbSet<Osztaly> Osztaly { get; set; }
        public DbSet<Tanulo> Tanulo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=IskolaDemo;Uid=root;Pwd=;",
                ServerVersion.AutoDetect("Server=localhost;Database=IskolaDemo;Uid=root;Pwd=;"));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilt
{
    public class AppDbContext:DbContext
    {
        public DbSet<Ora> Orak { get; set; }
        public DbSet<Diak> Diakok { get; set; }
        public DbSet<Kapcsolo> Kapcsolo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("server=localhost;database=nyiltnap;uid=root;password='';");
        }
    }
}

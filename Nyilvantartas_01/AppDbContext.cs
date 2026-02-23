using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantartas_01
{
    public class AppDbContext : DbContext
    {
        public DbSet<SzervezetiEgyseg> Szervezetiegysegek { get; set; }
        public DbSet<Dolgozo> Dolgozok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("server=localhost; database=dolgozonyilvantartas; uid=root;password='';");
        }

        // fel kell tölteni az elemeket a szervezeti egység táblába előre
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SzervezetiEgyseg>().HasData(
                new SzervezetiEgyseg() { Id = 1, Nev = "Igazgatóság" },
                new SzervezetiEgyseg() { Id = 2, Nev = "Értékesítés" },
                new SzervezetiEgyseg() { Id = 3, Nev = "Logisztika" },
                new SzervezetiEgyseg() { Id = 4, Nev = "Számlázás" },
                new SzervezetiEgyseg() { Id = 5, Nev = "Beszerzés" }
                );
        }
    }

}

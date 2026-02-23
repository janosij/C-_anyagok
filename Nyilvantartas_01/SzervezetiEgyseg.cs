using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantartas_01
{ // beállítjuk, hogy a Nev mező egyedi legyen, kell hozzá a EF Core, amit usingolunk is!
    // és fontos, hogy ezt az osztályra kell állítani és nem a propertyre!
    [Index(nameof(Nev), IsUnique = true)]
    public class SzervezetiEgyseg
    {
        // ennyi elég az elsődleges kulcshoz!
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nev { get; set; } = string.Empty;

        // navigációs property
        public ICollection<Dolgozo> Dolgozok1 { get; set; } = new List<Dolgozo>();
    }

}

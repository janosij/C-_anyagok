using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Nyilvantartas_01
{
    [Index(nameof(Adoazonositojel), IsUnique = true)]
    public class Dolgozo
    {
        public int Id { get; set; }

        [StringLength(10)]
        [Required]
        public string Adoazonositojel { get; set; } = string.Empty;

        [StringLength(200)]
        [Required]
        public string Nev { get; set; } = string.Empty;

        // Külső kulcs
        [ForeignKey("Szervezetiegyseg")]
        public int SzervezetiegysegId { get; set; }

        public int Evesszabadsag { get; set; }

        // navigációs tulajdonság
        public SzervezetiEgyseg Szervezetiegyseg { get; set; } = null!;

        [StringLength(100)]
        public string Beosztas { get; set; } = string.Empty;

        public DateTime Felveteldatuma { get; set; }
    }

}

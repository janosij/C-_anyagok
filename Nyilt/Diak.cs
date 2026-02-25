using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilt
{
    public class Ora
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Targy { get; set; } = string.Empty;
        public string Csoport { get; set; } = string.Empty;
        public string Terem { get; set; } = string.Empty;
        public string Tanar { get; set; } = string.Empty;
        public int Ferohely { get; set; }
        public int Orasorszam { get; set; }
        public ICollection<Kapcsolo> Kapcsolatok { get; set; } = new List<Kapcsolo>();
    }
    public class Diak
    {
        public int Id { get; set; }
        public string Nev { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Telepules { get; set; } = string.Empty;
        public ICollection<Kapcsolo> Kapcsolatok { get; set; } = new List<Kapcsolo>();
    }
    public class Kapcsolo
    {
        public int Id { get; set; }
        public int DiakId { get; set; }
        public int OraId { get; set; }
        public Diak Diak { get; set; } = null!;
        public Ora Ora { get; set; } = null!;
    }
}

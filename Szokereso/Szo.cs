using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szokereso
{
    public class Szo
    {
        public int Id { get; set; }
        public string Hu { get; set; } = string.Empty;
        public string Eng { get; set; } = string.Empty;
    }

    public class Kartya
    {
        public int SzoId { get; set; }
        public string Felirat { get; set; } = string.Empty; // Hu VAGY Eng
        public bool Paros { get; set; }
        public bool Felforditva { get; set; }
    }
}

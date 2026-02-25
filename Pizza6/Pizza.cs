using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza6
{
    internal class Pizza
    {
        public string Megrendelo { get; set; }
        public string Nev { get; set; } = string.Empty;
        public string Alap { get; set; } = string.Empty;
        public List<string> Extrak { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"{Megrendelo} {Nev} {Alap} {string.Join(" ", Extrak)}";
        }
    }
}

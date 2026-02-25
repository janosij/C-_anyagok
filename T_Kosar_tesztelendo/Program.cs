namespace T_Kosar_tesztelendo
{
    /*
    Készítünk egy Kosar osztályt (később ezt teszteljük), ami:

        - Tartalmaz termékeket(név, ár, darabszám)

        - Ki tudja számolni a végösszeget

        - 10% kedvezményt ad, ha az összeg meghaladja a 20 000 Ft-ot
    */

    public class Tetel
    {
        public string Nev { get; set; } = string.Empty;
        public int Ar { get; set; }
        public int Darab { get; set; }
    }

    public class Kosar
    {
        private List<Tetel> tetelek = new();

        public void Hozzaad(Tetel tetel)
        {
            tetelek.Add(tetel);
        }

        public int Vegosszeg()
        {
            var osszeg = tetelek.Sum(t => t.Ar * t.Darab);

            if (osszeg > 20000)
            {
                osszeg = (int)Math.Round(osszeg * 0.9,0);
            }
            return osszeg;
        }
    }

    /* 
     A következő dolgokat szeretnénk tesztelni:
        
        - Üres kosár → 0

        - Egy termék → helyes szorzás

        - Több termék → összeadás helyes

        - 20 000 alatt → nincs kedvezmény

        - 20 000 felett → 10% kedvezmény
    */

    // A teszthez létre kell hozni egy xUnit projektet és
    // referenciának meg kell adni ezt a projektet, hogy elérjük a Kosar osztályt.

    public class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}

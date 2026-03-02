namespace T_Bovitett_Kosar_Tesztelendo
{
    /*
    Az egyszerű kosár osztályt tovább bővítjük, 
    hogy többféle kedvezményt és szállítási költséget is kezelni tudjon, 
    így a tesztek összetettebbek lesznek, egyszerre mehet több feltétel is!

    Készítünk egy Kosar osztályt (később ezt teszteljük), ami:

        - Tartalmaz termékeket(név, ár, darabszám)

        - Kedvezményeket (10% kedvezmény 20 000 Ft felett)

        - Kuponkódokat: "Extra5000" → -5000 Ft "Tavaszi5" → -5%,
          de egyszerre csak egy kupon használható!

        - Szállítási költséget: 2000 Ft, 
          de ha a végösszeg (kedvezmények levonása után!) eléri a 40 000 Ft-ot, 
          akkor ingyenes a szállítás

        - Ki tudja számolni a végösszeget

        - A végösszeg nem lehet negatív, ha a kedvezmények miatt negatív lenne, akkor 0-ra kerekítjük
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
        private string? kupon;

        public void Hozzaad(Tetel tetel)
        {
            if (tetel.Darab <= 0)
                throw new ArgumentException("Darabszám nem lehet <= 0");

            tetelek.Add(tetel);
        }

        public void KuponBeallit(string k)
        {
            kupon = k;
        }

        public int Vegosszeg()
        {
            var osszeg = tetelek.Sum(t => t.Ar * t.Darab);
            
            // 10% kedvezmény 20000 felett
            if (osszeg > 20000)
            {
                osszeg = (int)Math.Round(osszeg * 0.9, 0);
            }

            // Kupon
            if (kupon == "Extra5000")
            {
                osszeg -= 5000;
            }
            else if (kupon == "Tavaszi5")
            {
                osszeg = (int)Math.Round(osszeg * 0.95, 0);
            }

            // Szállítás
            if (osszeg < 40000)
            {
                osszeg += 2000;
            }

            return Math.Max(0, osszeg);
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

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

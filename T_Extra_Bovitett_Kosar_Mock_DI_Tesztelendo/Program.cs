namespace T_Extra_Bovitett_Kosar_Mock_DI_Tesztelendo
{
    public class Tetel
    {
        public string Nev { get; set; } = string.Empty;
        public int Ar { get; set; }
        public int Darab { get; set; }
    }

    /*
       Létrehozunk egy külső dependencyt (függőséget), amit majd mockolni fogunk a tesztekben
       a mockolás segítségével szimulálni tudjuk a külső dependency viselkedését, 
       így tesztelhetjük a Kosár osztályt anélkül, hogy ténylegesen meghívnánk a külső szolgáltatást.      
       a külső dependency egy Interface lesz, amit majd a Kosár osztály használni fog, 
       és a tesztekben mockolni fogunk egy implementációt, hogy szimuláljuk a viselkedését.         
        */

    public interface IKuponService
    {
        int AlkalmazKedvezmeny(string kuponKod, int osszeg);
    }

    /*
    Ez az interface megtehetné például, hogy:
        - adatbázist hív

        - API-t hív

        - konfigurációból olvas stb.

    A lényeg, hogy a Kosar nem tudja hogyan működik, csak használja.  
     */

    // Jöjjön a kosár osztály, ami használja ezt a külső dependencyt (függőséget)
    public class Kosar
    {
        private List<Tetel> tetelek = new();
        private string? kupon;

        // Ez itt a Dependency Injection, a konstruktoron keresztül kapja meg a külső szolgáltatást
        // (dependencyt)
        private readonly IKuponService kuponService;

        public Kosar(IKuponService kuponServ)
        {
            kuponService = kuponServ;
        }
        // Eddig tart a DI 
        // A Kosar osztály (bár nem ő hozta létre, hanem kívülről kapja meg {injektálódik bele DI})
        // most már használja a kuponService-t a kedvezmény alkalmazásához
        public void Hozzaad(Tetel tetel)
        {
            tetelek.Add(tetel);
        }

        public void KuponBeallit(string k)
        {
            kupon = k;
        }

        public int Vegosszeg()
        {
            int osszeg = tetelek.Sum(t => t.Ar * t.Darab);

            if (kupon != null)
                osszeg = kuponService.AlkalmazKedvezmeny(kupon, osszeg);

            return osszeg;
        }

        public class Program
        {

            static void Main(string[] args)
            {

            }
        }
    }
}

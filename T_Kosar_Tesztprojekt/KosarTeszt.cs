using T_Kosar_tesztelendo;

namespace T_Kosar_Tesztprojekt
{
    public class KosarTeszt
    {
        // az üres kosár tesztje, 0-a forint
        [Fact]
        public void UresKosar_Vegosszeg_0()
        {
            var kosar = new Kosar();

            var result = kosar.Vegosszeg();

            Assert.Equal(0, result);
        }

        // egy termék tesztje, helyes-e a szorzás,
        // érdemes a határra választani, hogy a kedvezmény még pont ne legyen érvényes
        [Fact]
        public void EgyTermek_Vegosszeg_Helyes()
        {
            var kosar = new Kosar();
            kosar.Hozzaad(new Tetel { Nev = "Felmosóvödör", Ar = 10000, Darab = 2 });

            var result = kosar.Vegosszeg();

            Assert.Equal(20000, result);
        }

        // drága termék tesztje, jó lesz-e a kedvezményes ár?
        [Fact]
        public void OsszegFelett_KedvezmenyAlkalmazva()
        {
            var kosar = new Kosar();
            kosar.Hozzaad(new Tetel { Nev = "Gyémánt fokozatú felmosóvödör", Ar = 15000, Darab = 2 });

            var result = kosar.Vegosszeg();

            Assert.Equal(27000, result); // 30000 * 0.9
        }

        // több termék tesztje 20000 alatt, helyes-e az összeadás és a kedvezmény?
        [Fact]
        public void HaromTetel_Vegosszeg_Helyes()
        {
            var kosar = new Kosar();

            kosar.Hozzaad(new Tetel { Nev = "Füles", Ar = 10000, Darab = 1 }); // 10000
            kosar.Hozzaad(new Tetel { Nev = "Eger", Ar = 2000, Darab = 2 });    // 4000
            kosar.Hozzaad(new Tetel { Nev = "Billentyuzet", Ar = 3000, Darab = 1 }); // 3000

            var result = kosar.Vegosszeg();

            Assert.Equal(17000, result);
        }

        // több termék tesztje 20000 felett, helyes-e az összeadás és a kedvezmény?
        [Fact]
        public void HaromTetel_KedvezmenyAlkalmazva()
        {
            var kosar = new Kosar();

            kosar.Hozzaad(new Tetel { Ar = 10000, Darab = 1 }); // 10000
            kosar.Hozzaad(new Tetel { Ar = 8000, Darab = 1 });  // 8000
            kosar.Hozzaad(new Tetel { Ar = 5000, Darab = 1 });  // 5000

            var result = kosar.Vegosszeg();

            // 23000 → 10% kedvezmény → 20700
            Assert.Equal(20700, result);
        }

        //
        [Theory]        
        [InlineData(10000, 1, 2000, 2, 3000, 1, 17000)]
        [InlineData(10000, 1, 8000, 1, 5000, 1, 20700)]
        // és a határok tesztelése
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(1000, 1, 2000, 8, 3000, 1, 20000)]
        [InlineData(1001, 1, 2000, 8, 3000, 1, 18001)]

        public void HaromTetel_Teszt(
            int ar1, int db1,
            int ar2, int db2,
            int ar3, int db3,
            int expected)
        {
            var kosar = new Kosar();

            kosar.Hozzaad(new Tetel { Ar = ar1, Darab = db1 });
            kosar.Hozzaad(new Tetel { Ar = ar2, Darab = db2 });
            kosar.Hozzaad(new Tetel { Ar = ar3, Darab = db3 });

            var result = kosar.Vegosszeg();

            Assert.Equal(expected, result);
        }

    }
}
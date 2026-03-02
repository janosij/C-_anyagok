using T_Bovitett_Kosar_Tesztelendo;

namespace T_Bovitett_Kosar_Tesztprojekt
{
    public class UnitTest1
    {
        [Fact]
        public void KedvezmenyEsKupon_Egyutt()
        {
            var kosar = new Kosar();
            kosar.Hozzaad(new Tetel { Ar = 20000, Darab = 2 }); // 40000

            kosar.KuponBeallit("Extra5000");

            var result = kosar.Vegosszeg();

            // Van szállítási díj, mert a kedvezmények után nem éri el a 40000 Ft-ot
            // 40000 → 10% = 36000
            // -5000 = 31000
            // +2000 szállítás = 33000
            Assert.Equal(33000, result);
        }

        [Fact]
        public void VegeLegalabb40_IngyenesSzallitas()
        {
            var kosar = new Kosar();
            kosar.Hozzaad(new Tetel { Ar = 30000, Darab = 2 }); // 60000

            var result = kosar.Vegosszeg();

            // 60000 → 10% = 54000
            // nincs szállítási díj
            Assert.Equal(54000, result);
        }

        [Fact]
        public void Vegosszeg_NemLehetNegativ()
        {
            var kosar = new Kosar();
            kosar.Hozzaad(new Tetel { Ar = 1000, Darab = 1 }); //1000

            kosar.KuponBeallit("Extra5000"); // -4000

            var result = kosar.Vegosszeg();

            Assert.Equal(0, result);
        }

        [Fact]
        public void NullanalKisebbDarab_Exception()
        {
            var kosar = new Kosar();

            Assert.Throws<ArgumentException>(() =>
                kosar.Hozzaad(new Tetel { Ar = 1000, Darab = -2 })
            );
        }

        // Házi feladat: tesztelni az 5%-os kedvezményt!
    }
}
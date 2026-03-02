using Moq;
using T_Extra_Bovitett_Kosar_Mock_DI_Tesztelendo;

/*
        Most jön a Mockolás, a tesztekben létre fogunk hozni 
        egy mock implementációt az IKuponService-bõl. A Mock segítségével szimulálni tudjuk 
        a kupon szolgáltatás viselkedését. 
        A Mock => hamis, kontrollált helyettesítõ objektum
        Olyan objektum, ami úgy viselkedik, mint az igazi, de mi mondjuk meg, mit csináljon 
        és nem hív semmilyen külsõ rendszert! Akkor mondjuk meg, hogy mit csináljon.
        (nem kell várni adatbázisra, API-ra stb. könnyen tesztelhetõ!)
        */

// A mockhoz telepíteni kell egy NuGet csomagot, pl. Moq

namespace T_Extra_Bovitett_Kosar_Mock_DI_Teszt
{
    public class UnitTest1
    {
        [Fact]
        public void KuponService_MegHivodik()
        {
            var mock = new Mock<IKuponService>();

            // itt mondjuk meg, hogy ha a mockolt kupon szolgáltatás
            // AlkalmazKedvezmeny metódusát meghívják "TEST" kuponkóddal és 10000 összeggel,
            // akkor térjen vissza 8000-rel
            mock
                .Setup(k => k.AlkalmazKedvezmeny("TEST", 10000))
                .Returns(8000);

            var kosar = new Kosar(mock.Object);
            kosar.Hozzaad(new Tetel { Ar = 10000, Darab = 1 });
            kosar.KuponBeallit("TEST");

            var result = kosar.Vegosszeg();

            Assert.Equal(8000, result);
        }
    }
}
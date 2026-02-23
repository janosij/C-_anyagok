using Unit_teszt_01;

namespace SzamologepTeszt
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {         
            var sz = new Szamologep();

            var result = sz.Osszeadas(2, 3);

            Assert.Equal(5, result);
        }

        [Fact]
        public void Szorzas()
        {
            var sz = new Szamologep();

            var result = sz.Szorzas(5, 3);

            Assert.Equal(15, result);
        }

        [Fact]
        public void Osztas_nullaval()
        {
            var sz = new Szamologep();

            Assert.Throws<DivideByZeroException>(() => sz.Osztas(10, 0));
        }

    }
    
}
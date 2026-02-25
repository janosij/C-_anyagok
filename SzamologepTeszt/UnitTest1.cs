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

        // Egyszerre több érték tesztelése (paraméterezett teszt)
        [Theory]
        [InlineData(5, 3, 8)]
        [InlineData(-11, 11, 0)]
        [InlineData(-8, -14, -22)]
        public void OsszeadasTobbTesztesettel(int a, int b, int expected)
        {
            var sz = new Szamologep();

            var result = sz.Osszeadas(a, b);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { 2, 3, 5 },
                new object[] { 4, 6, 10 }
            };

        [Theory]
        [MemberData(nameof(TestData))]
        public void OsszeadasKomplex(int a, int b, int expected)
        {
            var sz = new Szamologep();
            var result = sz.Osszeadas(a, b);
            Assert.Equal(expected, result);
        }


        [ClassData]
    }

}
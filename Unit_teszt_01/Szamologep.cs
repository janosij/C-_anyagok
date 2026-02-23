using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_teszt_01
{
    public class Szamologep
    {
        public int Osszeadas(int a, int b)
        {
            return a + b;
        }

        public int Kivonas(int a, int b)
        {
            return a - b;
        }

        public int Szorzas(int a, int b)
        {
            return a * b;
        }

        public int Osztas(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return a / b;
        }
    }
}

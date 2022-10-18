using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.Models
{
    public static class GlobalRandom
    {
        public static Random random = new Random();

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue + 1);
        }
    }
}

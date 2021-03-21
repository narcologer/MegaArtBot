using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaArtBot
{
    partial class Functions
    {
        static Random rnd = new Random();
        public static int GetRandom(int m)
        {
            int value = rnd.Next(0, m);
            Console.WriteLine($"New random: {value}.");
            return value;
        }
    }
}

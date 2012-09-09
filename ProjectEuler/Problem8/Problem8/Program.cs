using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace Problem8
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution = 0;

            // Parse number from file
            string[] numarray = File.ReadAllLines("number.txt");
            string numstring = "";

            foreach (string line in numarray)
            {
                numstring += line;
            }

            Console.WriteLine("Number: {0}", numstring);
            
            BigInteger num = BigInteger.Zero;

            try
            {
                num = BigInteger.Parse(numstring);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}, ex");
            }

            int product = 0;

            for (int i = 5; i >= 1; i--)
            {
                product = i * (i + 1) * (i + 2) * (i + 3) * (i + 4);

                if (numstring.Contains(Convert.ToString(product)))
                {
                    solution = Convert.ToInt32(product);
                }
            }

            Console.WriteLine("Solution: {0}", solution);
            Console.ReadLine();
        }
    }
}

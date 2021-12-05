using System;
using System.Linq;
using System.Text;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = System.IO.File.ReadAllText("input.txt");
            string [] lines = output.Split(Environment.NewLine, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);

            string gammaRate = string.Empty;
            string epsilonRate = string.Empty;

            int [] count1 = new int []{0,0,0,0,0,0,0,0,0,0,0,0};
            int [] count0 = new int []{0,0,0,0,0,0,0,0,0,0,0,0};
            int noOfLines = lines.Length;

            for(int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                char[] chars = line.ToCharArray();
                for(int j = 0; j < chars.Length; j++)
                {
                    if(chars[j] == '1')
                    {
                        count1[j]++;
                    }
                    else
                    {
                        count0[j]++;
                    }
                }
            }

            Console.WriteLine("No. of 1 per collumn:");
            foreach(int c in count1)
            {
                Console.Write($"{c} ");
            }

            Console.WriteLine("\nNo. of 0 per collumn:");
            foreach(int c in count0)
            {
                Console.Write($"{c} ");
            }

            Console.WriteLine("\n\nGamma rate binary is:");
            for(int i = 0; i < 12; i++)
            {
                if(count1[i] > count0[i])
                {
                    gammaRate = gammaRate + "1";
                    epsilonRate = epsilonRate + "0";
                }
                else
                {
                    gammaRate = gammaRate + "0";
                    epsilonRate = epsilonRate + "1";
                }
            }
            Console.WriteLine($"{gammaRate} ({Convert.ToInt32(gammaRate,2)})");
            Console.WriteLine("Epsilon rate binary is:");
            Console.WriteLine($"{epsilonRate} ({Convert.ToInt32(epsilonRate,2)})");

            Console.WriteLine($"Power consumption: {Convert.ToInt32(gammaRate,2) * Convert.ToInt32(epsilonRate,2)}");
        }
    }
}
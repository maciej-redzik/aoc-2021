using System;
using System.Linq;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = System.IO.File.ReadAllText("input.txt");
            int []depths = output.Split(Environment.NewLine, int.MaxValue, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int a = 0;
            int b = 0;
            int totalIncreased = 0;
            for(int i = 1 ; i < depths.Length ; i++)
            {
                a = depths[i-1];
                b = depths[i];
                bool increased = b > a;
                if(increased)
                    totalIncreased++;

                Console.WriteLine($"{a} {b} {(increased ? "(increased)" : "(decreased)")}");
            }

            Console.Out.WriteLine($"Total increased: {totalIncreased}");
        }
    }
}

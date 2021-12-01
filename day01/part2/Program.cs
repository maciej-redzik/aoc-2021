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
            int c = 0;
            int totalIncreased = 0;
            int prevSum = 0;
            for(int i = 2 ; i < depths.Length ; i++)
            {
                a = depths[i-2];
                b = depths[i-1];
                c = depths[i];
                int sum = a + b + c;
                
                if(prevSum == 0) {
                    prevSum = sum;
                    Console.WriteLine($"{sum} (N/A - no previous sum)");
                    continue;
                    
                }
                bool increased = sum > prevSum;
                if(increased)
                {
                    totalIncreased++;
                }
                Console.WriteLine($"{sum} {(increased ? "(increased)" : "(decreased)")}");

                prevSum = sum;
            }

            Console.Out.WriteLine($"Total increased: {totalIncreased}");
        }
    }
}

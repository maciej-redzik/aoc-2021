using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = System.IO.File.ReadAllText("input.txt");
            string[] lines = output.Split(Environment.NewLine, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);

            string gammaRate = string.Empty;
            string epsilonRate = string.Empty;

            int[] count1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] count0 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int noOfLines = lines.Length;

            int[,] bits = GetBitArray(lines);

            int[,] oxygenArray = CalcRating(bits, 0, true);
            int[,] co2Array = CalcRating(bits, 0, false);

            Console.WriteLine(bits);

            Console.WriteLine("Oxygen generator rating code:");
            string oxygenCode = GetStringCodeFromBits(oxygenArray);
            string co2Code = GetStringCodeFromBits(co2Array);

            Console.WriteLine($"{oxygenCode} ({Convert.ToInt32(oxygenCode, 2)})");
            Console.WriteLine($"{co2Code} ({Convert.ToInt32(co2Code, 2)})");

            Console.WriteLine($"Life support rating: {(Convert.ToInt32(oxygenCode, 2) * Convert.ToInt32(co2Code, 2))}");
        }

        private static int[,] CalcRating(int[,] bits, int columnNo, bool isMost)
        {
            int[,] selectedArrays = bits;

            int commonNo = 0;
            if (isMost)
                commonNo = CalcMostCommonNo(bits, columnNo);
            else
                commonNo = CalcLeastCommonNo(bits, columnNo);

            selectedArrays = SelectArrays(bits, columnNo, commonNo);

            if (selectedArrays.GetLength(0) == 1)
            {
                return selectedArrays;
            }
            columnNo++;
            selectedArrays = CalcRating(selectedArrays, columnNo, isMost);

            return selectedArrays;
        }

        private static int CalcMostCommonNo(int[,] bits, int columnNo)
        {
            int count1 = 0;
            int count0 = 0;
            for (int i = 0; i < bits.GetLength(0); i++)
            {
                if (bits[i, columnNo] == 0)
                {
                    count0++;
                }
                else
                {
                    count1++;
                }
            }
            return count1 >= count0 ? 1 : 0;

        }

        private static int CalcLeastCommonNo(int[,] bits, int columnNo)
        {
            int count1 = 0;
            int count0 = 0;
            for (int i = 0; i < bits.GetLength(0); i++)
            {
                if (bits[i, columnNo] == 0)
                {
                    count0++;
                }
                else
                {
                    count1++;
                }
            }
            return count1 < count0 ? 1 : 0;
        }

        private static int[,] SelectArrays(int[,] bits, int columnNo, int mostCommonNo)
        {
            int noOfRows = 0;
            for (int i = 0; i < bits.GetLength(0); i++)
            {
                if (bits[i, columnNo] == mostCommonNo)
                {
                    noOfRows++;
                }
            }

            int[,] newArray = new int[noOfRows, 12];
            int newArrayIndex = 0;
            //Not performant
            for (int i = 0; i < bits.GetLength(0); i++)
            {
                if (bits[i, columnNo] == mostCommonNo)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        newArray[newArrayIndex, j] = bits[i, j];
                    }
                    newArrayIndex++;
                }
            }

            return newArray;
        }

        private static int[,] GetBitArray(string[] lines)
        {
            int[,] bits = new int[lines.Length, 12];
            for (int i = 0; i < lines.Length; i++)
            {
                char[] chars = lines[i].ToCharArray();
                for (int j = 0; j < 12; j++)
                {
                    bits[i, j] = chars[j] - '0';
                }
            }

            return bits;
        }

        private static string GetStringCodeFromBits(int[,] bits)
        {
            string code = string.Empty;
            for (int i = 0; i < 12; i++)
            {
                code = code + bits[0, i].ToString();
            }
            return code;
        }
    }
}
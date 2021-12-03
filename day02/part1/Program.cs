using System;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = System.IO.File.ReadAllText("input.txt");
            string [] commands = output.Split(Environment.NewLine, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);

            int xPos = 0; //horizontal position
            int yPos = 0; //depth

            for(int i = 0; i < commands.Length; i++)
            {
                string commandType = commands[i].Split(' ', StringSplitOptions.None)[0];
                int value = Convert.ToInt32(commands[i].Split(' ', StringSplitOptions.None)[1]);

                if(commandType == "forward")
                {
                    xPos += value;
                }
                if(commandType == "up")
                {
                    yPos -= value;
                }
                if(commandType == "down")
                {
                    yPos += value;
                }
            }

            Console.WriteLine($"Horizontal position: {xPos}");
            Console.WriteLine($"Depth: {yPos}");

            Console.WriteLine($"Depth x Horizontal position = {(xPos * yPos)}");
        }
    }
}

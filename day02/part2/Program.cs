using System;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = System.IO.File.ReadAllText("input.txt");
            string [] commands = output.Split(Environment.NewLine, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);

            int xPos = 0; //horizontal position
            int yPos = 0; //depth
            int aim = 0;  //aim

            for(int i = 0; i < commands.Length; i++)
            {
                string commandType = commands[i].Split(' ', StringSplitOptions.None)[0];
                int value = Convert.ToInt32(commands[i].Split(' ', StringSplitOptions.None)[1]);

                if (commandType == "forward")
                {
                    xPos += value;
                    yPos += value * aim;
                }
                if (commandType == "up")
                {
                    aim -= value;
                    if(aim < 0)
                        aim = 0;
                }
                if (commandType == "down")
                {
                    aim += value;
                }
            }

            Console.WriteLine($"Horizontal position: {xPos}");
            Console.WriteLine($"Depth: {yPos}");
            Console.WriteLine($"Aim: {aim}");

            Console.WriteLine($"Depth x Horizontal position = {(xPos * yPos)}");
        }
    }
}

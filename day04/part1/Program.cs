using System;
using System.Collections.Generic;
using System.Linq;

namespace part1
{
    class BoardField
    {
        public int number { get; set; }
        public bool isMarked { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string numbersStr = System.IO.File.ReadAllText("numbers.txt");
            string boardsStr = System.IO.File.ReadAllText("boards.txt");
            int[] selectedNumbers = numbersStr.Split(",", int.MaxValue, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<BoardField[,]> boards = LoadBoards(boardsStr);

            Console.WriteLine("Winning board number.");
        }

        static List<BoardField[,]> LoadBoards(string boardsStr)
        {
            List<string> boards = boardsStr.Split(Environment.NewLine + Environment.NewLine, int.MaxValue, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<BoardField[,]> boardsList = new List<BoardField[,]>();

            foreach (string board in boards)
            {
                List<string> numbersStr = board.Replace(Environment.NewLine, " ")
                .Replace("  ", " ")
                .Split(" ")
                .ToList();
                numbersStr.ForEach(x => x.TrimStart() );
                numbersStr.RemoveAll(x => string.IsNullOrWhiteSpace(x));

                List<int> numbers = numbersStr.Select(Int32.Parse).ToList();

                BoardField[,] boardObj = new BoardField[5, 5];
                int x = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        boardObj[i, j] = new BoardField() { number = numbers[x] };
                        x++;
                    }
                }
                boardsList.Add(boardObj);
            }

            return boardsList;
        }
    }
}

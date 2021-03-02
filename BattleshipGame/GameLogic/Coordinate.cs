using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BattleshipGame.GameLogic
{
    internal struct Coordinate
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Coordinate(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public static Coordinate Map(string input)
        {
            if (input is null || !Regex.IsMatch(input, "^[a-k][1-7]$"))
            {
                throw new ArgumentException("Congratulations! You've found a bug!");
            }
            var cols = new Dictionary<char, int>
            {
                {'a',0}, {'b',1}, {'c',2}, {'d',3}, {'e',4}, {'f',5}, {'g',6}, {'h',7}, {'i',8}, {'j',9}, {'k',10},
            };
            return new Coordinate(int.Parse(input[1].ToString()) - 1, cols[input[0]]);
        }
    }
}

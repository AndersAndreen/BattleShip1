using BattleshipGame.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.IO;

namespace BattleshipGame.Presentation
{

    internal class GameBoardFancy : IGameBoard
    {
        public string GameBoardName { get; } = "Fancy";
        private const int DisplayWidth = 35;
        private readonly string _emptyRow = $"\u2551{new string(' ', DisplayWidth)}\u2551";
        private int _inputVpos = 0;
        public void ClearScreen()
        {
            Console.Clear();
        }

        public void DisplayGameBoard(List<Coordinate> attackCoordinates, List<Battleship> battleships, Syntax syntax)
        {
            var battlegroundMatrix = new char[7][];
            battlegroundMatrix = battlegroundMatrix.Select(column => new char[11]).ToArray();
            attackCoordinates.ForEach(c => battlegroundMatrix[c.Row][c.Col] = '\u00b7');
            var sunken = battleships
                .Where(ship => ship.IsSunken)
                .ToList();
            sunken.ForEach(ship => ship.GetOccupiedCoordinates().ForEach(c => battlegroundMatrix[c.Row][c.Col] = 'X'));
            var gameField = battlegroundMatrix.Select(row => string.Join(' ', row)).ToList();
            var thickLine = new string('\u2550', DisplayWidth);
            var thinLine = new string('\u2500', 21);
            var topRowDivider = $"\u2554{thickLine}\u2557";
            var middleDivider = $"\u2560{thickLine}\u2563";
            var bottomDivider = $"\u255a{thickLine}\u255d";

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n     <<  B A T T L E S H I P  >>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(topRowDivider);
            Console.WriteLine("\u2551       a b c d e f g h i j k       \u2551");
            Console.WriteLine($"\u2551      \u250c{thinLine}\u2510      \u2551");
            using var helpTextEnumerator= Messages.GetHelpTexts(syntax).GetEnumerator();
            var i = 1;
            foreach (var row in gameField)
            {
                var helpTextLine = helpTextEnumerator.MoveNext() ? helpTextEnumerator.Current : "";
                Console.Write($"\u2551     {i}\u2502{row}\u2502{i++}     \u2551 ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(helpTextLine);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine($"\u2551      \u2514{thinLine}\u2518      \u2551");
            Console.WriteLine("\u2551       a b c d e f g h i j k       \u2551");
            Console.WriteLine(middleDivider);
            Console.WriteLine(_emptyRow);
            Console.WriteLine(_emptyRow);
            Console.WriteLine(_emptyRow);
            Console.WriteLine(bottomDivider);
            _inputVpos = Console.CursorTop;
        }

        public string DisplayUserInput(Func<string> inputFunction)
        {
            Console.SetCursorPosition(2, _inputVpos-4);
            var input = inputFunction();
            Console.SetCursorPosition(0, _inputVpos-4);
            Console.WriteLine(_emptyRow);
            return input;
        }


        public void ShowMessage(AppResult result)
            => ShowMessage(Messages.GetMessageString(result));


        public void ShowMessage(string message)
        {
            Console.SetCursorPosition(0, _inputVpos - 3);
            Console.WriteLine(_emptyRow);
            Console.WriteLine(_emptyRow);
            Console.SetCursorPosition(2, _inputVpos - 3);
            Console.WriteLine(message);
        }

        public AppResult GameCancelled()
        {
            ShowMessage("Game cancelled.");
            return WaitForConfirmation();
        }

        private AppResult WaitForConfirmation()
        {
            Console.WriteLine("\u2551 New game? Hit 'Y' or 'N'");
            Console.SetCursorPosition(1, _inputVpos - 4);
            ConsoleKeyInfo userInput;
            do
            {
                userInput = Console.ReadKey(true);
            } while (userInput.Key != ConsoleKey.Y && userInput.Key != ConsoleKey.N);

            return userInput.Key == ConsoleKey.Y
                ? new AppResult(Command.NewGame)
                : new AppResult(Command.Exit);
        }

        public AppResult GameWon()
        {
            ShowMessage("CONGRATULATIONS! YOU WON!");
            return WaitForConfirmation();
        }

        public void WaitForKeyStrokeThenEnd()
        {
            Console.SetCursorPosition(0, _inputVpos - 3);
            Console.WriteLine("\u2551 Press any key to end application.");
            Console.SetCursorPosition(1, _inputVpos-4);
            Console.ReadKey(true);
        }
    }
}

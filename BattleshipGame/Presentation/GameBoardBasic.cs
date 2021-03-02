using BattleshipGame.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.IO;

namespace BattleshipGame.Presentation
{

    internal class GameBoardBasic : IGameBoard
    {
        public string GameBoardName { get; } = "Basic";

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
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("   <<  BATTLESHIP  >>\n");
            Console.WriteLine("   a b c d e f g h i j k");
            using var helpTextEnumerator = Messages.GetHelpTexts(syntax).GetEnumerator();
            var i = 1;
            foreach (var row in gameField)
            {
                var helpTextLine = helpTextEnumerator.MoveNext() ? helpTextEnumerator.Current : "";
                Console.WriteLine($" {i} {row} {i++}   {helpTextLine}");
            }
            Console.WriteLine("   a b c d e f g h i j k\n");
            Console.SetCursorPosition(0, 13);
            Console.WriteLine(new string(' ', 80));
            Console.WriteLine(new string(' ', 80));
            Console.WriteLine(new string(' ', 80));
        }

        public string DisplayUserInput(Func<string> inputFunction)
        {
            Console.SetCursorPosition(1, 12);
            var input = inputFunction();
            Console.SetCursorPosition(0, 12);
            Console.WriteLine(new string(' ', 80));
            return input;
        }


        public void ShowMessage(AppResult result)
            => ShowMessage(Messages.GetMessageString(result));


        public void ShowMessage(string message)
        {
            Console.SetCursorPosition(0, 13);
            Console.WriteLine(message.PadRight(40, ' '));
        }

        public AppResult GameCancelled()
        {
            ShowMessage("Game cancelled.");
            return WaitForConfirmation();
        }

        public AppResult GameWon()
        {
            ShowMessage("CONGRATULATIONS! YOU WON!");
            return WaitForConfirmation();
        }

        private AppResult WaitForConfirmation()
        {
            Console.WriteLine("New game? Hit 'y' or 'n'");
            Console.SetCursorPosition(0,12);
            ConsoleKeyInfo userInput;
            do
            {
                userInput = Console.ReadKey(true);
            } while (userInput.Key != ConsoleKey.Y && userInput.Key != ConsoleKey.N);

            return userInput.Key == ConsoleKey.Y
                ? new AppResult(Command.NewGame)
                : new AppResult(Command.Exit);
        }

        public void WaitForKeyStrokeThenEnd()
        {
            Console.SetCursorPosition(0, 13);
            Console.WriteLine("Press any key to end application.");
            Console.SetCursorPosition(0, 12);
            Console.ReadKey(true);
        }
    }
}

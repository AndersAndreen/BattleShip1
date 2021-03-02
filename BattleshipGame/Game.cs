using BattleshipGame.GameLogic;
using BattleshipGame.IO;
using BattleshipGame.Presentation;
using System;

namespace BattleshipGame
{
    internal class Game
    {
        public void Start()
        {
            // Setup ----------------------------------------------------------------------

            // For demo purpose I'm setting up two different game board layouts
            var gameBoard1 = new GameBoardBasic();
            var gameBoard2 = new GameBoardFancy();
            IGameBoard gameBoard = gameBoard1;

            // And two different parsers with slightly different syntax
            Func<string, AppResult> parseCommandOriginal = InputParserOriginal.ParseCommand;
            Func<string, AppResult> parseCommandSimplified = InputParserSimplified.ParseCommand;
            var parseCommand = parseCommandOriginal;
            var syntax = Syntax.Original;
            
            Func<string> getKeyboardInput = KeyboardInput.ReadLine;

            // Battleground (together with the BattleShip objects) holds all game logic
            var battleground = new Battleground();


            // Run game -------------------------------------------------------------------
            battleground.Update(gameBoard.DisplayGameBoard, syntax);
            AppResult result;
            do
            {
                do
                {
                    result = parseCommand(gameBoard.DisplayUserInput(getKeyboardInput));
                    switch (result.Command)
                    {
                        case Command.SwitchGameDisplay:
                            gameBoard = gameBoard.GameBoardName == "Basic" ? (IGameBoard)gameBoard2 : gameBoard1;
                            gameBoard.ClearScreen();
                            break;
                        case Command.SwitchInputSyntax:
                            parseCommand = parseCommand == parseCommandOriginal ? parseCommandSimplified : parseCommandOriginal;
                            syntax = syntax == Syntax.Original ? Syntax.Simplified : Syntax.Original;
                            gameBoard.ClearScreen();
                            break;
                        case Command.Shoot:
                            result = battleground.Shoot(result.InputParameter);
                            break;
                    }
                    battleground.Update(gameBoard.DisplayGameBoard, syntax);
                    gameBoard.ShowMessage(result);
                } while (result.Command != Command.Exit
                         && result.Command != Command.CancelGame
                         && !battleground.GameWon());

                if (battleground.GameWon())
                {
                    result = gameBoard.GameWon();
                }

                if (result.Command == Command.CancelGame)
                {
                    battleground.Cancel(gameBoard.DisplayGameBoard, syntax);
                    result = gameBoard.GameCancelled();
                }

                if (result.Command == Command.NewGame)
                {
                    battleground = new Battleground();
                    battleground.Update(gameBoard.DisplayGameBoard, syntax);
                }
            } while (result.Command != Command.Exit);

            gameBoard.WaitForKeyStrokeThenEnd();
        }
    }
}

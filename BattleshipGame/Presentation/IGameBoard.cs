using System;
using System.Collections.Generic;
using BattleshipGame.GameLogic;
using BattleshipGame.IO;

namespace BattleshipGame.Presentation
{
    internal interface IGameBoard
    {
        string GameBoardName { get; }
        void ClearScreen();
        void DisplayGameBoard(List<Coordinate> attackCoordinates, List<Battleship> battleships, Syntax syntax);
        string DisplayUserInput(Func<string> inputFunction);
        void ShowMessage(AppResult result);
        void ShowMessage(string message);
        AppResult GameCancelled();
        AppResult GameWon();
        void WaitForKeyStrokeThenEnd();
    }
}
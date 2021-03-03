using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BattleshipGame.GameLogic;
using BattleshipGame.Input;

namespace BattleshipGame.Presentation
{
    internal class Messages
    {
        public static List<string> GetHelpTexts(Syntax syntax) => new List<string>
        {
            syntax == Syntax.Original
                ? "HELP (original syntax)"
                : "HELP (simplified syntax)",
            "",
            "e - Ends the application",
            "n - Ends current game, shows all ships and offers a New game",
            "d - Display (Switches between basic and fancy game display)",
            "s - Syntax (Switches between original & simplified input syntax)",
            syntax == Syntax.Original
                ? "b <coordinate> - Places a bomb at given coordinate. (ex: 'b a1')"
                : "<coordinate> - Places a bomb at given coordinate. (ex: 'a1')"
        };

        public static string GetMessageString(AppResult result)
        {
            return result.Command switch
            {
                Command.Error => $"ERROR {PascalCaseToWords(result.Message)}: '{result.InputParameter}'",
                Command.Shoot => $"SHOT - {PascalCaseToWords(result.Message)}: '{result.InputParameter}'",
                Command.CancelGame => $"Game Canceled.",
                Command.Exit => $"Good Game! Thank you an good bye!",
                Command.Miss => $"Miss at '{result.InputParameter}'",
                Command.None => $"",
                Command.SwitchGameDisplay => $"",
                Command.SwitchInputSyntax => $"Input syntax changed",
                Command.Hit => $"Hit at '{result.InputParameter}': One ship sunken!",
                Command.ShipAlreadySunken => $"Ship at '{result.InputParameter}' is already sunken",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static string PascalCaseToWords(Message message)
        {
            var words = string.Join(' ',
                Regex.Split(message.ToString(), "(?=[A-Z])")
                .Where(s => s != string.Empty)
                .Select(word => word.ToLower())
                .ToList());
            return words[0].ToString().ToUpper() + words[1..];
        }
    }
}

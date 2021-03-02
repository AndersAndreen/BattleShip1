using System.Text.RegularExpressions;
using BattleshipGame.GameLogic;
using BattleshipGame.Presentation;

namespace BattleshipGame.IO
{
    internal class InputParserOriginal
    {
        public static AppResult ParseCommand(string input)
        {
            if (input is null) { return new AppResult(Command.None, Message.None); }
            var trimmedInput = input.Trim().ToLower();
            if (trimmedInput.Length > 4) { return new AppResult(Command.Error, Message.InvalidCommand, trimmedInput); }
            switch (trimmedInput.Length)
            {
                case 0:
                    return new AppResult(Command.None);
                case 3:
                    return new AppResult(Command.Error, Message.InvalidCommand, trimmedInput);
                case 1:
                    return trimmedInput switch
                    {
                        "e" => new AppResult(Command.Exit),
                        "n" => new AppResult(Command.CancelGame),
                        "d" => new AppResult(Command.SwitchGameDisplay),
                        "s" => new AppResult(Command.SwitchInputSyntax),
                        _ => new AppResult(Command.Error, Message.InvalidCommand, trimmedInput)
                    };
            }

            if (trimmedInput[..2] != "b ") { return new AppResult(Command.Error, Message.InvalidCommand, trimmedInput);}
            if (!Regex.IsMatch(trimmedInput[2].ToString(), "[abcdefghijk]")) { return new AppResult(Command.Error, Message.InvalidColumnLetter, trimmedInput[2].ToString()); }
            if (!Regex.IsMatch(trimmedInput[3].ToString(), "[0-9]")) { return new AppResult(Command.Error, Message.NotANumber, trimmedInput[3].ToString()); }
            if (!Regex.IsMatch(trimmedInput[3].ToString(), "[1-7]")) { return new AppResult(Command.Error, Message.RowNumberOutOfRange, trimmedInput[3].ToString()); }
            return new AppResult(Command.Shoot, Message.None, trimmedInput[2..4]);
        }
    }
}

using System.Text.RegularExpressions;
using BattleshipGame.GameLogic;

namespace BattleshipGame.Input
{
    internal class InputParserSimplified
    {
        public static AppResult ParseCommand(string input)
        {
            if (input is null) { return new AppResult(Command.None, Message.None); }
            var trimmedInput = input.Trim().ToLower(); ;
            if (trimmedInput.Length > 2) { return new AppResult(Command.Error, Message.InvalidCommand, trimmedInput); }
            switch (trimmedInput.Length)
            {
                case 0:
                    return new AppResult(Command.None);
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

            if (!Regex.IsMatch(trimmedInput[0].ToString(), "[abcdefghijk]")) { return new AppResult(Command.Error, Message.InvalidColumnLetter, trimmedInput[0].ToString()); }
            if (!Regex.IsMatch(trimmedInput[1].ToString(), "[0-9]")) { return new AppResult(Command.Error, Message.NotANumber, trimmedInput[1].ToString()); }
            if (!Regex.IsMatch(trimmedInput[1].ToString(), "[1-7]")) { return new AppResult(Command.Error, Message.RowNumberOutOfRange, trimmedInput[1].ToString()); }
            return new AppResult(Command.Shoot, Message.None, trimmedInput);
        }
    }
}

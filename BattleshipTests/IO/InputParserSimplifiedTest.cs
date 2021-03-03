using BattleshipGame.GameLogic;
using BattleshipGame.Input;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.IO
{
    public class InputParserSimplifiedTest
    {
        [Theory]
        [InlineData(null, Command.None, Message.None, "")]
        [InlineData("", Command.None, Message.None, "")]
        [InlineData("abc", Command.Error, Message.InvalidCommand, "abc")]
        [InlineData("x", Command.Error, Message.InvalidCommand, "x")]
        [InlineData("e", Command.Exit, Message.None, "")]
        [InlineData("d", Command.SwitchGameDisplay, Message.None, "")]
        [InlineData("s", Command.SwitchInputSyntax, Message.None, "")]
        [InlineData("n", Command.CancelGame, Message.None, "")]
        [InlineData("l1", Command.Error, Message.InvalidColumnLetter, "l")]
        [InlineData("ab", Command.Error, Message.NotANumber, "b")]
        [InlineData("a0", Command.Error, Message.RowNumberOutOfRange, "0")]
        [InlineData("a8", Command.Error, Message.RowNumberOutOfRange, "8")]
        internal void ParseCommand_Errors(string input, Command command, Message message, string parameter)
        {
            // Arrange abcdefghijk

            // Act
            var result = InputParserSimplified.ParseCommand(input);

            // Assert
            result.Command.Should().Be(command);
            result.Message.Should().Be(message);
            result.InputParameter.Should().Be(parameter);
        }


        [Theory]
        [InlineData("a1", Command.Shoot, Message.None, "a1")]
        [InlineData("b1", Command.Shoot, Message.None, "b1")]
        [InlineData("c1", Command.Shoot, Message.None, "c1")]
        [InlineData("d1", Command.Shoot, Message.None, "d1")]
        [InlineData("e1", Command.Shoot, Message.None, "e1")]
        [InlineData("f1", Command.Shoot, Message.None, "f1")]
        [InlineData("g1", Command.Shoot, Message.None, "g1")]
        [InlineData("h1", Command.Shoot, Message.None, "h1")]
        [InlineData("i1", Command.Shoot, Message.None, "i1")]
        [InlineData("j1", Command.Shoot, Message.None, "j1")]
        [InlineData("k1", Command.Shoot, Message.None, "k1")]
        internal void ParseCommand_ColumnOk(string input, Command command, Message message, string parameter)
        {
            // Arrange abcdefghijk

            // Act
            var result = InputParserSimplified.ParseCommand(input);

            // Assert
            result.Command.Should().Be(command);
            result.Message.Should().Be(message);
            result.InputParameter.Should().Be(parameter);
        }


        [Theory]
        [InlineData("a1", Command.Shoot, Message.None, "a1")]
        [InlineData("a2", Command.Shoot, Message.None, "a2")]
        [InlineData("a3", Command.Shoot, Message.None, "a3")]
        [InlineData("a4", Command.Shoot, Message.None, "a4")]
        [InlineData("a5", Command.Shoot, Message.None, "a5")]
        [InlineData("a6", Command.Shoot, Message.None, "a6")]
        [InlineData("a7", Command.Shoot, Message.None, "a7")]
        internal void ParseCommand_RowOk(string input, Command command, Message message, string parameter)
        {
            // Arrange abcdefghijk

            // Act
            var result = InputParserSimplified.ParseCommand(input);

            // Assert
            result.Command.Should().Be(command);
            result.Message.Should().Be(message);
            result.InputParameter.Should().Be(parameter);
        }
    }
}

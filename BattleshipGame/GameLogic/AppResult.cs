namespace BattleshipGame.GameLogic
{
    internal class AppResult
    {
        public Command Command { get; private set; }
        public Message Message { get; private set; }
        public string InputParameter { get; private set; }

        public AppResult(Command command)
        {
            Command = command;
            Message = Message.None;
            InputParameter = string.Empty;
        }

        public AppResult(Command command, Message message)
        {
            Command = command;
            Message = message;
            InputParameter = string.Empty;
        }

        public AppResult(Command command, Message message, string inputParameter)
        {
            Command = command;
            Message = message;
            InputParameter = inputParameter;
        }
    }
}

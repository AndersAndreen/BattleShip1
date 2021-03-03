using System;

namespace BattleshipGame.Input
{
    class KeyboardInput
    {
        public static string ReadLine()
        {
            return Console.ReadLine() ?? "".ToLowerInvariant();
        }
    }
}

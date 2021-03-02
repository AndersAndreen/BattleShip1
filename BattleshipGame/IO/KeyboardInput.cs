using System;

namespace BattleshipGame.IO
{
    class KeyboardInput
    {
        public static string ReadLine()
        {
            return Console.ReadLine() ?? "".ToLowerInvariant();
        }
    }
}

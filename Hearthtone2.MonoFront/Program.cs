using System;

namespace Hearthtone2.MonoFront
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Hearthtone2Game())
                game.Run();
        }
    }
}

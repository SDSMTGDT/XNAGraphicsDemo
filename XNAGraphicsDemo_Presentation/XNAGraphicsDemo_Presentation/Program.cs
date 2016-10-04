using System;

namespace XNAGraphicsDemo_Presentation
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
            //using (var game = new DrawSprite_NoClass())
            //game.Run();
            //using (var game = new RotateSprite_NoClass())
            //game.Run();
            //using (var game = new MoveSprite_NoClass())
            //game.Run();
            //using (var game = new FullControlSprite_NoClass())
            //game.Run();
            //using (var game = new AnimatedSprite_NoClass())
            //game.Run();
            //using (var game = new FullControlAnimatedSprite_NoClass())
            //game.Run();
            using (var game = new WithClasses())
                game.Run();
        }
    }
}

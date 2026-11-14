/*
 * Bing Shaw Lim
 * CST-250
 * 11/14/2026
 * Whack-A-Mole
 * Activity 5
 * Resources: CST-250 Activity 5 Guide (Grand Canyon University, 2025)
 */

namespace WhackAMoleClassLibrary.Models
{
    /// <summary>
    /// The state of the game in progress. Holds data only; GameLogic changes it.
    /// </summary>
    public class GameStateModel
    {
        // Class level properties
        public int Score { get; set; }
        public int Lives { get; set; }
        public int Level { get; set; }
        public TimeSpan TimeElapsed { get; set; }
        public int MoveEverySeconds { get; set; }
        public int TargetSize { get; set; }
        public bool DecoyVisible { get; set; }
        public bool IsGameOver { get; set; }

        /// <summary>
        /// Default constructor that sets the values for a new game
        /// </summary>
        public GameStateModel()
        {
            Score = 0;
            Lives = 3;
            Level = 1;
            TimeElapsed = TimeSpan.Zero;
            MoveEverySeconds = 3;
            TargetSize = 80;
            DecoyVisible = false;
            IsGameOver = false;
        }
    }
}

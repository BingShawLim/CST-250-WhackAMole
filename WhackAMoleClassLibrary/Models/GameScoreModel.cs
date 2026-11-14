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
    /// One finished game in the High Score Hall of Fame. Holds data only.
    /// </summary>
    public class GameScoreModel
    {
        // Class level properties
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public int Level { get; set; }
        public DateTime GameDate { get; set; }
        public TimeSpan GameTime { get; set; }

        /// <summary>
        /// Default constructor that sets every property to a default value
        /// </summary>
        public GameScoreModel()
        {
            Id = 0;
            PlayerName = string.Empty;
            Score = 0;
            Level = 1;
            GameDate = DateTime.Now;
            GameTime = TimeSpan.Zero;
        }
    }
}

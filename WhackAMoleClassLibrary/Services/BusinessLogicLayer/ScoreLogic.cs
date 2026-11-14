/*
 * Bing Shaw Lim
 * CST-250
 * 11/14/2026
 * Whack-A-Mole
 * Activity 5
 * Resources: CST-250 Activity 5 Guide (Grand Canyon University, 2025)
 */

using WhackAMoleClassLibrary.Models;
using WhackAMoleClassLibrary.Services.DataAccessLayer;

namespace WhackAMoleClassLibrary.Services.BusinessLogicLayer
{
    /// <summary>
    /// Business logic for the High Score Hall of Fame. Ranks the scores with LINQ
    /// and passes the file work to ScoreDAO.
    /// </summary>
    public class ScoreLogic
    {
        // Class level variables
        private readonly ScoreDAO _scoreDAO;

        /// <summary>
        /// Default constructor that uses App_Data\HighScores.txt
        /// </summary>
        public ScoreLogic()
        {
            _scoreDAO = new ScoreDAO();
        }

        /// <summary>
        /// Constructor that uses a different file (the xUnit tests use a temporary file)
        /// </summary>
        /// <param name="filePath">Full path of the high score text file</param>
        public ScoreLogic(string filePath)
        {
            _scoreDAO = new ScoreDAO(filePath);
        }

        /// <summary>
        /// Add a finished game to the Hall of Fame
        /// </summary>
        /// <param name="score">The finished game</param>
        /// <returns>The id given to the score</returns>
        public int AddScore(GameScoreModel score)
        {
            return _scoreDAO.AddScore(score);
        }

        /// <summary>
        /// Get the best scores, highest first. On a tie the earlier game ranks first.
        /// </summary>
        /// <param name="count">How many scores to return</param>
        /// <returns>The top scores</returns>
        public List<GameScoreModel> GetHighScores(int count)
        {
            return _scoreDAO.GetAllScores()
                .OrderByDescending(score => score.Score)
                .ThenBy(score => score.GameDate)
                .Take(count)
                .ToList();
        } // End of GetHighScores method

        /// <summary>
        /// Save every score to the high score file
        /// </summary>
        /// <returns>True when the file was written</returns>
        public bool SaveScores()
        {
            return _scoreDAO.WriteScoresToFile();
        }

        /// <summary>
        /// Load the scores from the high score file
        /// </summary>
        /// <returns>True when the scores were read (or there was no file yet)</returns>
        public bool LoadScores()
        {
            return _scoreDAO.ReadScoresFromFile();
        }
    }
}

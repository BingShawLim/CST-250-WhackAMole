/*
 * Bing Shaw Lim
 * CST-250
 * 11/14/2026
 * Whack-A-Mole
 * Activity 5
 * Resources: CST-250 Activity 5 Guide (Grand Canyon University, 2025)
 */

using System.Globalization;
using WhackAMoleClassLibrary.Models;

namespace WhackAMoleClassLibrary.Services.DataAccessLayer
{
    /// <summary>
    /// Data access object for the High Score Hall of Fame. Keeps the scores in a list
    /// and writes them to App_Data\HighScores.txt so future players can see them.
    /// </summary>
    public class ScoreDAO
    {
        // Separator between the values on one line of the text file
        private const string Separator = " * ";
        // Date format used in the file so it reads the same on any computer
        private const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        // Class level variables
        private readonly List<GameScoreModel> _scores;
        private readonly string _filePath;

        /// <summary>
        /// Default constructor that stores the scores in App_Data\HighScores.txt next to the program
        /// </summary>
        public ScoreDAO() : this(Path.Combine(AppContext.BaseDirectory, "App_Data", "HighScores.txt"))
        {
        }

        /// <summary>
        /// Constructor that uses a different file (the xUnit tests use a temporary file)
        /// </summary>
        /// <param name="filePath">Full path of the high score text file</param>
        public ScoreDAO(string filePath)
        {
            _scores = new List<GameScoreModel>();
            _filePath = filePath;
        }

        /// <summary>
        /// Add a score to the list and give it the next id
        /// </summary>
        /// <param name="score">The finished game</param>
        /// <returns>The id given to the score</returns>
        public int AddScore(GameScoreModel score)
        {
            score.Id = _scores.Count + 1;
            _scores.Add(score);
            return score.Id;
        } // End of AddScore method

        /// <summary>
        /// Get every stored score
        /// </summary>
        /// <returns>A copy of the score list</returns>
        public List<GameScoreModel> GetAllScores()
        {
            return new List<GameScoreModel>(_scores);
        }

        /// <summary>
        /// Write every score to the text file, one game per line
        /// </summary>
        /// <returns>True when the file was written</returns>
        public bool WriteScoresToFile()
        {
            try
            {
                // Create the App_Data folder the first time
                string? folder = Path.GetDirectoryName(_filePath);
                if (!string.IsNullOrEmpty(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    foreach (GameScoreModel score in _scores)
                    {
                        writer.WriteLine(string.Join(Separator,
                            score.PlayerName,
                            score.Score.ToString(CultureInfo.InvariantCulture),
                            score.Level.ToString(CultureInfo.InvariantCulture),
                            score.GameDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                            ((int)score.GameTime.TotalSeconds).ToString(CultureInfo.InvariantCulture)));
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        } // End of WriteScoresToFile method

        /// <summary>
        /// Read the scores from the text file. A missing file means no games have been
        /// saved yet, so the list is left empty. Damaged lines are skipped.
        /// </summary>
        /// <returns>True when the scores were read (or there was no file yet)</returns>
        public bool ReadScoresFromFile()
        {
            _scores.Clear();
            if (!File.Exists(_filePath))
            {
                return true;
            }
            try
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(Separator);
                        if (values.Length != 5)
                        {
                            continue;
                        }
                        bool valid = int.TryParse(values[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int points)
                            & int.TryParse(values[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int level)
                            & DateTime.TryParseExact(values[3], DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date)
                            & int.TryParse(values[4], NumberStyles.Integer, CultureInfo.InvariantCulture, out int seconds);
                        if (!valid)
                        {
                            continue;
                        }
                        GameScoreModel score = new GameScoreModel();
                        score.PlayerName = values[0];
                        score.Score = points;
                        score.Level = level;
                        score.GameDate = date;
                        score.GameTime = TimeSpan.FromSeconds(seconds);
                        AddScore(score);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        } // End of ReadScoresFromFile method
    }
}

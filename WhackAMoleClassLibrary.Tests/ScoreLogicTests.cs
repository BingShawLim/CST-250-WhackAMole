/*
 * Bing Shaw Lim
 * CST-250
 * 11/14/2026
 * Whack-A-Mole - Activity 5 xUnit Tests
 * Resources: CST-250 Activity 5 Guide (Grand Canyon University, 2025)
 */

using WhackAMoleClassLibrary.Models;
using WhackAMoleClassLibrary.Services.BusinessLogicLayer;

namespace WhackAMoleClassLibrary.Tests
{
    /// <summary>
    /// xUnit tests for the High Score Hall of Fame (ScoreLogic and ScoreDAO)
    /// </summary>
    public class ScoreLogicTests : IDisposable
    {
        // Each test uses its own temporary high score file
        private readonly string _filePath;

        /// <summary>
        /// Create a unique temporary file path for this test
        /// </summary>
        public ScoreLogicTests()
        {
            _filePath = Path.Combine(Path.GetTempPath(), $"WhackAMole_{Guid.NewGuid():N}", "HighScores.txt");
        }

        /// <summary>
        /// Delete the temporary folder after the test
        /// </summary>
        public void Dispose()
        {
            string? folder = Path.GetDirectoryName(_filePath);
            if (folder != null && Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }
        }

        // Helper: build a finished game
        private static GameScoreModel MakeScore(string name, int score, int level, DateTime date, int seconds)
        {
            GameScoreModel model = new GameScoreModel();
            model.PlayerName = name;
            model.Score = score;
            model.Level = level;
            model.GameDate = date;
            model.GameTime = TimeSpan.FromSeconds(seconds);
            return model;
        }

        // GameScoreModel's default constructor sets the default values
        [Fact]
        public void GameScoreModel_DefaultConstructor_ShouldSetDefaults()
        {
            // Arrange and Act
            GameScoreModel score = new GameScoreModel();

            // Assert
            Assert.Equal(0, score.Id);
            Assert.Equal(string.Empty, score.PlayerName);
            Assert.Equal(0, score.Score);
            Assert.Equal(1, score.Level);
        }

        // AddScore gives ids 1, 2, 3 in order
        [Fact]
        public void AddScore_ShouldAssignIdsInOrder()
        {
            // Arrange
            ScoreLogic logic = new ScoreLogic(_filePath);

            // Act
            int first = logic.AddScore(MakeScore("Bing", 12, 3, DateTime.Now, 60));
            int second = logic.AddScore(MakeScore("Jason", 8, 2, DateTime.Now, 60));

            // Assert
            Assert.Equal(1, first);
            Assert.Equal(2, second);
        }

        // C3 Hall of Fame: highest score first, only the number asked for
        [Fact]
        public void GetHighScores_ShouldSortHighestFirstAndLimitCount()
        {
            // Arrange
            ScoreLogic logic = new ScoreLogic(_filePath);
            logic.AddScore(MakeScore("Ann", 4, 1, new DateTime(2026, 11, 14, 10, 0, 0), 60));
            logic.AddScore(MakeScore("Ben", 15, 4, new DateTime(2026, 11, 14, 11, 0, 0), 60));
            logic.AddScore(MakeScore("Cal", 9, 2, new DateTime(2026, 11, 14, 12, 0, 0), 60));

            // Act
            List<GameScoreModel> top = logic.GetHighScores(2);

            // Assert
            Assert.Equal(2, top.Count);
            Assert.Equal("Ben", top[0].PlayerName);
            Assert.Equal("Cal", top[1].PlayerName);
        }

        // C3 Hall of Fame: on a tie the earlier game ranks first
        [Fact]
        public void GetHighScores_Tie_ShouldPutEarlierGameFirst()
        {
            // Arrange
            ScoreLogic logic = new ScoreLogic(_filePath);
            logic.AddScore(MakeScore("Later", 10, 3, new DateTime(2026, 11, 14, 12, 0, 0), 60));
            logic.AddScore(MakeScore("Earlier", 10, 3, new DateTime(2026, 11, 13, 9, 0, 0), 60));

            // Act
            List<GameScoreModel> top = logic.GetHighScores(10);

            // Assert
            Assert.Equal("Earlier", top[0].PlayerName);
        }

        // C3 Hall of Fame: scores written to the file come back the same when loaded
        [Fact]
        public void SaveScores_ThenLoadScores_ShouldRoundTrip()
        {
            // Arrange
            ScoreLogic writer = new ScoreLogic(_filePath);
            writer.AddScore(MakeScore("Bing", 14, 3, new DateTime(2026, 11, 14, 15, 30, 5), 60));
            writer.AddScore(MakeScore("Jason", 6, 2, new DateTime(2026, 11, 14, 16, 0, 0), 41));

            // Act
            bool saved = writer.SaveScores();
            ScoreLogic reader = new ScoreLogic(_filePath);
            bool loaded = reader.LoadScores();
            List<GameScoreModel> scores = reader.GetHighScores(10);

            // Assert
            Assert.True(saved);
            Assert.True(loaded);
            Assert.Equal(2, scores.Count);
            Assert.Equal("Bing", scores[0].PlayerName);
            Assert.Equal(14, scores[0].Score);
            Assert.Equal(3, scores[0].Level);
            Assert.Equal(new DateTime(2026, 11, 14, 15, 30, 5), scores[0].GameDate);
            Assert.Equal(TimeSpan.FromSeconds(41), scores[1].GameTime);
        }

        // Loading when no file exists yet means an empty Hall of Fame, not an error
        [Fact]
        public void LoadScores_WithNoFile_ShouldReturnTrueAndEmpty()
        {
            // Arrange
            ScoreLogic logic = new ScoreLogic(_filePath);

            // Act
            bool loaded = logic.LoadScores();

            // Assert
            Assert.True(loaded);
            Assert.Empty(logic.GetHighScores(10));
        }

        // A damaged line in the file is skipped instead of crashing the game
        [Fact]
        public void LoadScores_WithDamagedLine_ShouldSkipIt()
        {
            // Arrange
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
            File.WriteAllLines(_filePath, new[]
            {
                "Bing * 12 * 3 * 2026-11-14 15:00:00 * 60",
                "this line is damaged"
            });
            ScoreLogic logic = new ScoreLogic(_filePath);

            // Act
            bool loaded = logic.LoadScores();

            // Assert
            Assert.True(loaded);
            Assert.Single(logic.GetHighScores(10));
        }
    }
}

/*
 * Bing Shaw Lim
 * CST-250
 * 11/14/2026
 * Whack-A-Mole
 * Activity 5
 * Resources: CST-250 Activity 5 Guide (Grand Canyon University, 2025)
 */

using WhackAMoleClassLibrary.Models;
using WhackAMoleClassLibrary.Services.BusinessLogicLayer;

namespace WhackAMole.PresentationLayer
{
    /// <summary>
    /// C3 High Score Hall of Fame: shows the top 10 games from the score file
    /// </summary>
    public partial class FrmHighScores : Form
    {
        // Class level variables (the same ScoreLogic object used by FrmStopwatch)
        private readonly ScoreLogic _scoreLogic;

        /// <summary>
        /// Constructor that keeps the shared ScoreLogic and fills the grid
        /// </summary>
        /// <param name="scoreLogic">Business logic that ranks the scores</param>
        public FrmHighScores(ScoreLogic scoreLogic)
        {
            InitializeComponent();
            _scoreLogic = scoreLogic;
            DisplayScores();
        }

        /// <summary>
        /// Fill the data grid view with the top 10 scores, highest first
        /// </summary>
        private void DisplayScores()
        {
            List<GameScoreModel> topScores = _scoreLogic.GetHighScores(10);
            dgvHighScores.Rows.Clear();
            for (int i = 0; i < topScores.Count; i++)
            {
                GameScoreModel score = topScores[i];
                dgvHighScores.Rows.Add(i + 1, score.PlayerName, score.Score, score.Level,
                    score.GameDate.ToString("MM/dd/yyyy h:mm tt"), $"{(int)score.GameTime.TotalSeconds}s");
            }
            dgvHighScores.ClearSelection();
        } // End of DisplayScores method

        /// <summary>
        /// Click Event Handler for btnClose
        /// Closes the Hall of Fame and returns to the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCloseClickEH(object sender, EventArgs e)
        {
            Close();
        }
    }
}

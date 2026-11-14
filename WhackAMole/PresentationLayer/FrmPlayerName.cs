/*
 * Bing Shaw Lim
 * CST-250
 * 11/14/2026
 * Whack-A-Mole
 * Activity 5
 * Resources: CST-250 Activity 5 Guide (Grand Canyon University, 2025)
 */

using System.Text.RegularExpressions;

namespace WhackAMole.PresentationLayer
{
    /// <summary>
    /// C3 High Score Hall of Fame: asks the player for a name when the game ends
    /// </summary>
    public partial class FrmPlayerName : Form
    {
        // The name typed by the player, read by FrmStopwatch after the dialog closes
        public string PlayerName { get; private set; }

        /// <summary>
        /// Constructor that shows the final score
        /// </summary>
        /// <param name="score">The player's final score</param>
        public FrmPlayerName(int score)
        {
            InitializeComponent();
            PlayerName = string.Empty;
            lblFinalScore.Text = $"Game over! Final score: {score}";
        }

        /// <summary>
        /// Click Event Handler for btnOk
        /// Checks the name with a regular expression (1 to 20 letters, digits, or spaces)
        /// and closes the form when it is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOkClickEH(object sender, EventArgs e)
        {
            string name = txtPlayerName.Text.Trim();
            if (!Regex.IsMatch(name, @"^[A-Za-z0-9 ]{1,20}$"))
            {
                MessageBox.Show("Please enter 1 to 20 letters, digits, or spaces.", "Player Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlayerName.Focus();
                return;
            }
            PlayerName = name;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

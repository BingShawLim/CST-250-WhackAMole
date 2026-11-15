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
    public partial class FrmStopwatch : Form
    {
        // Space between the controls and the edges of the form
        private const int EdgeMargin = 12;

        // Class level variable to hold the timers time
        private TimeSpan _timeElapsed = new TimeSpan();
        // Create a new Random object to generate numbers
        private Random _random = new Random();
        // Business logic objects (the form never changes the game data directly)
        private readonly GameLogic _gameLogic = new GameLogic();
        private readonly ScoreLogic _scoreLogic = new ScoreLogic();

        /// <summary>
        /// Default constructor for the stopwatch form.
        /// Loads the Hall of Fame and sets up the custom graphics for level 1.
        /// </summary>
        public FrmStopwatch()
        {
            InitializeComponent();
            // Read past high scores from App_Data\HighScores.txt
            _scoreLogic.LoadScores();
            // Custom graphics: repeating grass background
            BackgroundImage = GameGraphics.CreateGrassTile();
            BackgroundImageLayout = ImageLayout.Tile;
            // Size and draw the target and decoy for level 1, hidden until Start
            ApplyLevelSettings();
            btnTarget.Visible = false;
            btnDecoy.Visible = false;
            UpdateLabels();
        }

        /// <summary>
        /// Click Event Handler for btnStart
        /// Starts a new game if the last one is over, then starts (or resumes) the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClickEH(object sender, EventArgs e)
        {
            // Start a new game if none is running
            if (_gameLogic.IsGameOver())
            {
                _gameLogic.StartNewGame();
                _timeElapsed = new TimeSpan();
                lblTimeElapsed.Text = _timeElapsed.ToString();
                ApplyLevelSettings();
                UpdateLabels();
            }
            // Show the target right away if none is showing; a paused target stays where it was
            if (!btnTarget.Visible)
            {
                MoveButton(btnTarget);
            }
            tmrStopwatch.Start();
        }

        /// <summary>
        /// Click Event Handler for btnStop
        /// Stops the timer (pauses the game)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopClickEH(object sender, EventArgs e)
        {
            // Stop the timer
            tmrStopwatch.Stop();
        }

        /// <summary>
        /// Tick Event Handler for tmrStopwatch
        /// Updates the _timeElapsed variable and the label,
        /// ends the game when it is over, and moves the buttons when it is time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrStopwatchTickEH(object sender, EventArgs e)
        {
            // Get the interval from tmrStopwatch
            int interval = tmrStopwatch.Interval;
            // Add the timers interval to _timeElapsed
            _timeElapsed = _timeElapsed.Add(TimeSpan.FromMilliseconds(interval));
            // Show the elapsedTime on the label
            lblTimeElapsed.Text = _timeElapsed.ToString();
            // Let the business layer count the game time
            bool timeToMove = _gameLogic.Tick(TimeSpan.FromMilliseconds(interval));
            // C2: the game ends after 60 seconds
            if (_gameLogic.IsGameOver())
            {
                EndGame();
                return;
            }
            // Check if it is time to move the target button
            if (timeToMove)
            {
                MoveButton(btnTarget);
                // C8: the decoy bomb moves too from level 2
                if (_gameLogic.GetState().DecoyVisible)
                {
                    MoveButton(btnDecoy);
                }
            }
        } // End of TmrStopwatchTickEH

        /// <summary>
        /// Click Event Handler for btnReset
        /// Reset the timer and related variables, and start over with a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetClickEH(object sender, EventArgs e)
        {
            // Stop the timer
            tmrStopwatch.Stop();
            // Reset elapsedTime
            _timeElapsed = new TimeSpan();
            // Show the reset time on the label
            lblTimeElapsed.Text = _timeElapsed.ToString();
            // Start over with a fresh game state
            _gameLogic.StartNewGame();
            ApplyLevelSettings();
            btnTarget.Visible = false;
            btnDecoy.Visible = false;
            UpdateLabels();
        }

        /// <summary>
        /// Click Event Handler for btnTarget
        /// C1: hides the target and scores a point. C5/C9: applies the next level when reached.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTargetClickEH(object sender, EventArgs e)
        {
            // Clicks only count while the game is running
            if (!tmrStopwatch.Enabled)
            {
                return;
            }
            // Hide the target
            btnTarget.Visible = false;
            int levelBefore = _gameLogic.GetState().Level;
            _gameLogic.RegisterHit();
            // Make the game harder when a new level is reached
            if (_gameLogic.GetState().Level > levelBefore)
            {
                ApplyLevelSettings();
            }
            UpdateLabels();
        }

        /// <summary>
        /// Click Event Handler for btnDecoy
        /// C8: clicking the bomb costs a life; losing the last life ends the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDecoyClickEH(object sender, EventArgs e)
        {
            if (!tmrStopwatch.Enabled)
            {
                return;
            }
            btnDecoy.Visible = false;
            _gameLogic.RegisterDecoyHit();
            UpdateLabels();
            if (_gameLogic.IsGameOver())
            {
                EndGame();
            }
        }

        /// <summary>
        /// Click Event Handler for FrmStopwatch (a click on the grass instead of the target)
        /// C4: a missed click costs 1 point and 1 life
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStopwatchClickEH(object sender, EventArgs e)
        {
            if (!tmrStopwatch.Enabled)
            {
                return;
            }
            _gameLogic.RegisterMiss();
            UpdateLabels();
            if (_gameLogic.IsGameOver())
            {
                EndGame();
            }
        }

        /// <summary>
        /// Resize Event Handler for FrmStopwatch
        /// Extra challenge (Account for Form Resize): keeps the controls in place when the window changes size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStopwatchResizeEH(object sender, EventArgs e)
        {
            ArrangeControls();
        }

        /// <summary>
        /// Move a button to a random spot inside the play area with a random back color, and show it
        /// </summary>
        /// <param name="button">btnTarget or btnDecoy</param>
        private void MoveButton(Button button)
        {
            Rectangle area = GetPlayArea();
            // Try a few spots so the bomb never covers the target
            for (int attempt = 0; attempt < 10; attempt++)
            {
                Point location = _gameLogic.GetRandomLocation(area.Width, area.Height, button.Width);
                button.Location = new Point(area.Left + location.X, area.Top + location.Y);
                if (button == btnTarget || !btnTarget.Visible || !button.Bounds.IntersectsWith(btnTarget.Bounds))
                {
                    break;
                }
            }
            // Get random light colors for the button so the drawing stays easy to see
            button.BackColor = Color.FromArgb(_random.Next(150, 256), _random.Next(150, 256), _random.Next(150, 256));
            // Set the button to be visible
            button.Visible = true;
        } // End of MoveButton method

        /// <summary>
        /// C5/C9: resize the target and decoy for the current level and redraw their custom graphics
        /// </summary>
        private void ApplyLevelSettings()
        {
            GameStateModel state = _gameLogic.GetState();
            btnTarget.Size = new Size(state.TargetSize, state.TargetSize);
            btnDecoy.Size = new Size(state.TargetSize, state.TargetSize);
            // Custom graphics drawn at the new size
            btnTarget.BackgroundImage?.Dispose();
            btnTarget.BackgroundImage = GameGraphics.CreateMoleImage(state.TargetSize);
            btnDecoy.BackgroundImage?.Dispose();
            btnDecoy.BackgroundImage = GameGraphics.CreateBombImage(state.TargetSize);
            // The decoy only plays from level 2
            if (!state.DecoyVisible)
            {
                btnDecoy.Visible = false;
            }
        } // End of ApplyLevelSettings method

        /// <summary>
        /// Show the score, lives (as hearts), and level from the business layer
        /// </summary>
        private void UpdateLabels()
        {
            GameStateModel state = _gameLogic.GetState();
            lblScore.Text = $"Score: {state.Score}";
            lblLives.Text = $"Lives: {new string('♥', state.Lives)}";
            lblLevel.Text = $"Level: {state.Level}";
            ArrangeControls();
        } // End of UpdateLabels method

        /// <summary>
        /// C2: stop the game, ask for the player's name, save the score, and show the Hall of Fame (C3)
        /// </summary>
        private void EndGame()
        {
            // Stop the timer and hide the buttons
            tmrStopwatch.Stop();
            btnTarget.Visible = false;
            btnDecoy.Visible = false;
            UpdateLabels();
            GameStateModel state = _gameLogic.GetState();
            using (FrmPlayerName frmPlayerName = new FrmPlayerName(state.Score))
            {
                if (frmPlayerName.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                // Build the score for this game and add it to the Hall of Fame
                GameScoreModel score = new GameScoreModel();
                score.PlayerName = frmPlayerName.PlayerName;
                score.Score = state.Score;
                score.Level = state.Level;
                score.GameDate = DateTime.Now;
                score.GameTime = state.TimeElapsed;
                _scoreLogic.AddScore(score);
                if (!_scoreLogic.SaveScores())
                {
                    MessageBox.Show("The high scores could not be saved.", "Hall of Fame",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            using (FrmHighScores frmHighScores = new FrmHighScores(_scoreLogic))
            {
                frmHighScores.ShowDialog(this);
            }
        } // End of EndGame method

        /// <summary>
        /// The space between the labels at the top and the buttons at the bottom.
        /// Measured from the controls themselves so it works at any display scaling.
        /// </summary>
        /// <returns>The play area rectangle</returns>
        private Rectangle GetPlayArea()
        {
            int top = EdgeMargin + lblTimeElapsed.Height + EdgeMargin;
            int bottom = ClientSize.Height - EdgeMargin - btnStart.Height - EdgeMargin;
            int width = Math.Max(1, ClientSize.Width - (2 * EdgeMargin));
            int height = Math.Max(1, bottom - top);
            return new Rectangle(EdgeMargin, top, width, height);
        }

        /// <summary>
        /// Extra challenge (Account for Form Resize): labels along the top, buttons along the
        /// bottom edge, and the target and decoy pulled back inside the play area
        /// </summary>
        private void ArrangeControls()
        {
            // Labels across the top
            lblTimeElapsed.Location = new Point(EdgeMargin, EdgeMargin);
            lblScore.Location = new Point(lblTimeElapsed.Right + 24, EdgeMargin);
            lblLevel.Location = new Point(lblScore.Right + 24, EdgeMargin);
            lblLives.Location = new Point(lblLevel.Right + 24, EdgeMargin);
            // Buttons along the bottom edge
            int buttonTop = ClientSize.Height - btnStart.Height - EdgeMargin;
            btnStart.Location = new Point(EdgeMargin, buttonTop);
            btnStop.Location = new Point(btnStart.Right + 8, buttonTop);
            btnReset.Location = new Point(btnStop.Right + 8, buttonTop);
            // Keep the target and decoy inside the play area
            Rectangle area = GetPlayArea();
            foreach (Button button in new[] { btnTarget, btnDecoy })
            {
                int left = Math.Min(Math.Max(button.Left, area.Left), Math.Max(area.Left, area.Right - button.Width));
                int top = Math.Min(Math.Max(button.Top, area.Top), Math.Max(area.Top, area.Bottom - button.Height));
                button.Location = new Point(left, top);
            }
        } // End of ArrangeControls method
    }
}

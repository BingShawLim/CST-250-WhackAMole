/*
 * Bing Shaw Lim
 * CST-250
 * 11/02/2026
 * Whack-A-Mole
 * Activity 5
 * Resources: CST-250 Activity 5 Guide (Grand Canyon University, 2025)
 */

namespace WhackAMole.PresentationLayer
{
    public partial class FrmStopwatch : Form
    {
        // Class level variable to hold the timers time
        private TimeSpan _timeElapsed = new TimeSpan();
        // Create a new Random object to generate numbers
        private Random _random = new Random();

        /// <summary>
        /// Default constructor for the stopwatch form
        /// </summary>
        public FrmStopwatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click Event Handler for btnStart
        /// Starts the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClickEH(object sender, EventArgs e)
        {
            // Start the timer
            tmrStopwatch.Start();
        }

        /// <summary>
        /// Click Event Handler for btnStop
        /// Stops the timer
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
        /// Updates the _timeElapsed variable and the label
        /// Moves btnTarget every three seconds
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
            // Check if it is time to move the target button
            if (_timeElapsed.Seconds % 3 == 0)
            {
                // Select a new location for the top of btnTarget
                // Randomly generate a location for the top of the button
                // between 0 and the form height minus the button height
                btnTarget.Top = _random.Next(0, this.Height - btnTarget.Height);
                // Select a new location for the left side of btnTarget
                btnTarget.Left = _random.Next(0, this.Width - btnTarget.Width);
                // Get random numbers for the RGB color for the button
                btnTarget.BackColor = Color.FromArgb(_random.Next(0, 256), _random.Next(0, 256), _random.Next(0, 256));
                // Set the target to be visible
                btnTarget.Visible = true;
            }
        } // End of TmrStopwatchTickEH

        /// <summary>
        /// Click Event Handler for btnReset
        /// Reset the timer and related variables
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
        }

        /// <summary>
        /// Click Event Handler for btnTarget to hide the target
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTargetClickEH(object sender, EventArgs e)
        {
            // Hide the target
            btnTarget.Visible = false;
        }
    }
}

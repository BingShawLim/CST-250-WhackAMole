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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrStopwatchTickEH(object sender, EventArgs e)
        {
            // Get the interval from tmrStopwatch
            int interval = tmrStopwatch.Interval;
            // Add the timers interval to _timeElapsed
            _timeElapsed = _timeElapsed.Add(TimeSpan.FromMilliseconds(interval));
            // Show the _timeElapsed on the label
            lblTimeElapsed.Text = _timeElapsed.ToString();
        }

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
    }
}

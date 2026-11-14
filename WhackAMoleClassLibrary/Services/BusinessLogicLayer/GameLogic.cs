/*
 * Bing Shaw Lim
 * CST-250
 * 11/14/2026
 * Whack-A-Mole
 * Activity 5
 * Resources: CST-250 Activity 5 Guide (Grand Canyon University, 2025)
 */

using System.Drawing;
using WhackAMoleClassLibrary.Models;

namespace WhackAMoleClassLibrary.Services.BusinessLogicLayer
{
    /// <summary>
    /// Game rules for Whack-A-Mole: score, penalty clicks, lives, levels, increasing
    /// difficulty, the end of the game, and where the target moves.
    /// The form only calls these methods and shows the results.
    /// </summary>
    public class GameLogic
    {
        // Game rule constants
        public const int PointsPerHit = 1;
        public const int MissPenalty = 1;
        public const int StartingLives = 3;
        public const int GameLengthSeconds = 60;
        public const int PointsPerLevel = 5;

        // Class level variables
        private GameStateModel _state;
        private readonly Random _random;

        /// <summary>
        /// Default constructor that starts a new game
        /// </summary>
        public GameLogic()
        {
            _random = new Random();
            _state = new GameStateModel();
            StartNewGame();
        }

        /// <summary>
        /// Start a new game: score 0, 3 lives, level 1, move every 3 seconds, target size 80
        /// </summary>
        /// <returns>The state of the new game</returns>
        public GameStateModel StartNewGame()
        {
            _state = new GameStateModel();
            _state.Lives = StartingLives;
            UpdateLevel();
            return _state;
        } // End of StartNewGame method

        /// <summary>
        /// Add one timer interval to the game time. Ends the game after 60 seconds.
        /// </summary>
        /// <param name="interval">Time since the last tick</param>
        /// <returns>True when it is time to move the target</returns>
        public bool Tick(TimeSpan interval)
        {
            if (_state.IsGameOver)
            {
                return false;
            }
            _state.TimeElapsed = _state.TimeElapsed.Add(interval);
            // End the game when the time runs out
            if (_state.TimeElapsed.TotalSeconds >= GameLengthSeconds)
            {
                _state.IsGameOver = true;
                return false;
            }
            // Move the target every MoveEverySeconds seconds
            int seconds = (int)_state.TimeElapsed.TotalSeconds;
            return seconds % _state.MoveEverySeconds == 0;
        } // End of Tick method

        /// <summary>
        /// Score a hit on the target: +1 point, and a new level every 5 points
        /// </summary>
        public void RegisterHit()
        {
            if (_state.IsGameOver)
            {
                return;
            }
            _state.Score += PointsPerHit;
            UpdateLevel();
        } // End of RegisterHit method

        /// <summary>
        /// Penalty click: the player clicked the form instead of the target.
        /// Takes away 1 point (never below zero) and 1 life.
        /// </summary>
        public void RegisterMiss()
        {
            if (_state.IsGameOver)
            {
                return;
            }
            _state.Score = Math.Max(0, _state.Score - MissPenalty);
            _state.Lives = Math.Max(0, _state.Lives - 1);
            _state.IsGameOver = _state.Lives == 0;
        } // End of RegisterMiss method

        /// <summary>
        /// Decoy: the player clicked the bomb. Takes away 1 life; the game ends at 0 lives.
        /// </summary>
        public void RegisterDecoyHit()
        {
            if (_state.IsGameOver)
            {
                return;
            }
            _state.Lives = Math.Max(0, _state.Lives - 1);
            _state.IsGameOver = _state.Lives == 0;
        } // End of RegisterDecoyHit method

        /// <summary>
        /// Check whether the game has ended (60 seconds or 0 lives)
        /// </summary>
        /// <returns>True when the game is over</returns>
        public bool IsGameOver()
        {
            return _state.IsGameOver;
        }

        /// <summary>
        /// Levels and increasing difficulty: a new level every 5 points (a penalty never
        /// takes a level away). Each level
        /// makes the target smaller, from level 3 it moves every 2 seconds and from
        /// level 5 every second, and the decoy bomb appears from level 2.
        /// </summary>
        private void UpdateLevel()
        {
            _state.Level = Math.Max(_state.Level, 1 + (_state.Score / PointsPerLevel));
            if (_state.Level >= 5)
            {
                _state.MoveEverySeconds = 1;
            }
            else if (_state.Level >= 3)
            {
                _state.MoveEverySeconds = 2;
            }
            else
            {
                _state.MoveEverySeconds = 3;
            }
            _state.TargetSize = Math.Max(40, 80 - ((_state.Level - 1) * 8));
            _state.DecoyVisible = _state.Level >= 2;
        } // End of UpdateLevel method

        /// <summary>
        /// Pick a random location that keeps the whole target inside an area
        /// </summary>
        /// <param name="width">Width of the area</param>
        /// <param name="height">Height of the area</param>
        /// <param name="size">Width and height of the target</param>
        /// <returns>The top-left corner, measured from the top-left of the area</returns>
        public Point GetRandomLocation(int width, int height, int size)
        {
            int maxLeft = Math.Max(0, width - size);
            int maxTop = Math.Max(0, height - size);
            return new Point(_random.Next(0, maxLeft + 1), _random.Next(0, maxTop + 1));
        } // End of GetRandomLocation method

        /// <summary>
        /// Get the state of the game in progress
        /// </summary>
        /// <returns>The current GameStateModel</returns>
        public GameStateModel GetState()
        {
            return _state;
        }
    }
}

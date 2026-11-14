/*
 * Bing Shaw Lim
 * CST-250
 * 11/14/2026
 * Whack-A-Mole - Activity 5 xUnit Tests
 * Resources: CST-250 Activity 5 Guide (Grand Canyon University, 2025)
 */

using System.Drawing;
using WhackAMoleClassLibrary.Models;
using WhackAMoleClassLibrary.Services.BusinessLogicLayer;

namespace WhackAMoleClassLibrary.Tests
{
    /// <summary>
    /// xUnit tests for the game rules in GameLogic
    /// </summary>
    public class GameLogicTests
    {
        // Helper: score a number of hits in a row
        private static void Hit(GameLogic logic, int times)
        {
            for (int i = 0; i < times; i++)
            {
                logic.RegisterHit();
            }
        }

        // A new game starts with score 0, 3 lives, level 1, moves every 3 seconds, target size 80
        [Fact]
        public void StartNewGame_ShouldResetTheState()
        {
            // Arrange
            GameLogic logic = new GameLogic();
            Hit(logic, 7);
            logic.RegisterDecoyHit();

            // Act
            GameStateModel state = logic.StartNewGame();

            // Assert
            Assert.Equal(0, state.Score);
            Assert.Equal(GameLogic.StartingLives, state.Lives);
            Assert.Equal(1, state.Level);
            Assert.Equal(TimeSpan.Zero, state.TimeElapsed);
            Assert.Equal(3, state.MoveEverySeconds);
            Assert.Equal(80, state.TargetSize);
            Assert.False(state.DecoyVisible);
            Assert.False(logic.IsGameOver());
            Assert.Same(state, logic.GetState());
        }

        // C1 Score: each hit is worth 1 point
        [Fact]
        public void RegisterHit_ShouldAddOnePoint()
        {
            // Arrange
            GameLogic logic = new GameLogic();

            // Act
            logic.RegisterHit();

            // Assert
            Assert.Equal(GameLogic.PointsPerHit, logic.GetState().Score);
        }

        // C5 Levels and C9 Increasing Difficulty: 5 points reaches level 2, the target shrinks and the decoy appears
        [Fact]
        public void RegisterHit_FivePoints_ShouldReachLevelTwo()
        {
            // Arrange
            GameLogic logic = new GameLogic();

            // Act
            Hit(logic, 5);
            GameStateModel state = logic.GetState();

            // Assert
            Assert.Equal(2, state.Level);
            Assert.Equal(72, state.TargetSize);
            Assert.True(state.DecoyVisible);
            Assert.Equal(3, state.MoveEverySeconds);
        }

        // C9 Increasing Difficulty: the target moves sooner at levels 3 and 5 and never gets smaller than 40
        [Theory]
        [InlineData(10, 3, 2, 64)]
        [InlineData(20, 5, 1, 48)]
        [InlineData(60, 13, 1, 40)]
        public void RegisterHit_HigherLevels_ShouldBeHarder(int hits, int level, int moveEvery, int size)
        {
            // Arrange
            GameLogic logic = new GameLogic();

            // Act
            Hit(logic, hits);
            GameStateModel state = logic.GetState();

            // Assert
            Assert.Equal(level, state.Level);
            Assert.Equal(moveEvery, state.MoveEverySeconds);
            Assert.Equal(size, state.TargetSize);
        }

        // C4 Penalty Click: a missed click takes 1 point and 1 life
        [Fact]
        public void RegisterMiss_ShouldTakeAPointAndALife()
        {
            // Arrange
            GameLogic logic = new GameLogic();
            Hit(logic, 3);

            // Act
            logic.RegisterMiss();

            // Assert
            Assert.Equal(2, logic.GetState().Score);
            Assert.Equal(2, logic.GetState().Lives);
        }

        // C4 Penalty Click: the score never goes below zero
        [Fact]
        public void RegisterMiss_WithZeroScore_ShouldNotGoNegative()
        {
            // Arrange
            GameLogic logic = new GameLogic();

            // Act
            logic.RegisterMiss();

            // Assert
            Assert.Equal(0, logic.GetState().Score);
        }

        // C5 Levels: a penalty never takes a level away
        [Fact]
        public void RegisterMiss_AfterLevelUp_ShouldKeepTheLevel()
        {
            // Arrange
            GameLogic logic = new GameLogic();
            Hit(logic, 5);

            // Act
            logic.RegisterMiss();

            // Assert
            Assert.Equal(4, logic.GetState().Score);
            Assert.Equal(2, logic.GetState().Level);
        }

        // C8 Decoy and C2 End the Game: three bomb clicks use up every life and end the game
        [Fact]
        public void RegisterDecoyHit_ThreeTimes_ShouldEndTheGame()
        {
            // Arrange
            GameLogic logic = new GameLogic();

            // Act
            logic.RegisterDecoyHit();
            logic.RegisterDecoyHit();
            bool overAfterTwo = logic.IsGameOver();
            logic.RegisterDecoyHit();

            // Assert
            Assert.False(overAfterTwo);
            Assert.Equal(0, logic.GetState().Lives);
            Assert.True(logic.IsGameOver());
        }

        // C2 End the Game: no points are scored after the game is over
        [Fact]
        public void RegisterHit_AfterGameOver_ShouldScoreNothing()
        {
            // Arrange
            GameLogic logic = new GameLogic();
            logic.RegisterMiss();
            logic.RegisterMiss();
            logic.RegisterMiss();

            // Act
            logic.RegisterHit();

            // Assert
            Assert.True(logic.IsGameOver());
            Assert.Equal(0, logic.GetState().Score);
        }

        // Tick: at level 1 the target moves every 3 seconds
        [Fact]
        public void Tick_LevelOne_ShouldMoveEveryThreeSeconds()
        {
            // Arrange
            GameLogic logic = new GameLogic();
            TimeSpan second = TimeSpan.FromSeconds(1);

            // Act
            bool first = logic.Tick(second);
            bool secondTick = logic.Tick(second);
            bool third = logic.Tick(second);

            // Assert
            Assert.False(first);
            Assert.False(secondTick);
            Assert.True(third);
            Assert.Equal(TimeSpan.FromSeconds(3), logic.GetState().TimeElapsed);
        }

        // C2 End the Game: the game ends after 60 seconds
        [Fact]
        public void Tick_SixtySeconds_ShouldEndTheGame()
        {
            // Arrange
            GameLogic logic = new GameLogic();

            // Act
            logic.Tick(TimeSpan.FromSeconds(59));
            bool overAt59 = logic.IsGameOver();
            logic.Tick(TimeSpan.FromSeconds(1));

            // Assert
            Assert.False(overAt59);
            Assert.True(logic.IsGameOver());
        }

        // Moving the target: every random location keeps the whole target inside the area
        [Fact]
        public void GetRandomLocation_ShouldStayInsideTheArea()
        {
            // Arrange
            GameLogic logic = new GameLogic();

            // Act and Assert
            for (int i = 0; i < 500; i++)
            {
                Point location = logic.GetRandomLocation(700, 300, 80);
                Assert.InRange(location.X, 0, 620);
                Assert.InRange(location.Y, 0, 220);
            }
        }

        // Models hold data only: the default constructor sets the starting values
        [Fact]
        public void GameStateModel_DefaultConstructor_ShouldSetDefaults()
        {
            // Arrange and Act
            GameStateModel state = new GameStateModel();

            // Assert
            Assert.Equal(0, state.Score);
            Assert.Equal(3, state.Lives);
            Assert.Equal(1, state.Level);
            Assert.False(state.IsGameOver);
        }
    }
}

# CST-250 Activity 5: Whack-A-Mole

Bing Shaw Lim, CST-250, Grand Canyon University

A WinForms stopwatch (Part 1) that becomes a timer-driven Whack-A-Mole game (Part 2 and the challenges),
built from the CST-250 Activity 5 Guide with an N-layer design:

- **WhackAMole** (PresentationLayer): `FrmStopwatch` (game), `FrmPlayerName`, `FrmHighScores`, `GameGraphics`
- **WhackAMoleClassLibrary**: Models (`GameStateModel`, `GameScoreModel`), BusinessLogicLayer (`GameLogic`, `ScoreLogic`), DataAccessLayer (`ScoreDAO`)
- **WhackAMoleClassLibrary.Tests**: xUnit tests for the business logic and data access

Challenges: Score, End the Game (60 s or 0 lives), High Score Hall of Fame (`App_Data\HighScores.txt`),
Penalty Click, Levels, Decoy, Increasing Difficulty, Custom Graphics, Account for Form Resize.

Run: open `WhackAMole.sln` in Visual Studio 2022, set **WhackAMole** as the startup project, press F5.

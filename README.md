# MindSweeperAnalytics P v.s NP

On October 2000, Scientific America published an article titled "Million-Dollar Minesweeper", the article suggested that Minesweeper was one of the NP-complete problems based on a paper published by R. Kaye, "Minesweeper is NP-complete," Mathematical Intelligencer volume 22 number 4, 9-15 (Spring 2000). They also suggested that there could be a monetary gain by doing so.

The idea of solving this problem haunted me for several years until I finally set about solving the puzzle.

This repository contains a set of programs that both play the game as well as record the run time complexity of the game. There’s an unplublished article explaining the solution and my findings.  

The application is written in C# so you will need a copy of Visual Studio 2017 community edition.

Note: You will need to create a folder C:\minesweeper (this is where the application logs all the results of each iteration of the game).

MindSwpSolution - Has a runable Form PlayerLogicAndPlayerForm
MineSweepAnalytics - Has a runable Form GameProgressionConsole

Start up both Forms 
Select the Start Button on both forms (establishing a connection between the two components)

Pressing Play on the PlayerLogicAndPlayerForm will launch one iteration of the game.

The PlayerLogicAndPlayerForm has the Number of iterations (or the number of consecutive games to play, the X and Y Origins specify the starting game board dimensions, the X and Y step (how much increase of board dimensions), Bomb Ratio (density of bombs as a percentage of the board)

Please see the documents in the Docs folder for more details and my finding.









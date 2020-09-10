﻿using Minesweeper_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Diagnostics;
using System.Linq.Expressions;
using Minesweeper_Web_Application.Services.Business;

namespace Minesweeper_Web_Application.Controllers
{
    
    public class GameController : Controller
    {
        public static int row = 12;
        public static int col = 12;
        public static int numofBombs = 12;
        public static int safeSquares = (row * col - numofBombs);
        public static GameBoardModel board = null;
        public static List<GameSquareModel> squares = null;
        public static DateTime startTime;

        public ActionResult Index()
        {
            startTime = DateTime.Now;
            squares = new List<GameSquareModel>();
            board = new GameBoardModel(squares, row, col);
            board.PlaceBombs(squares, numofBombs);
            board.BombToString(squares);
<<<<<<< HEAD
            return View("Game", squares);
=======
            Debug.WriteLine(startTime);
            return View("Game");
>>>>>>> origin/Security&DatabaseChanges
        }
        [HttpPost]
        public PartialViewResult OnButtonClick(string mine)
        {
            int value = Int32.Parse(mine);
            int index = value - 1;
            int r = index / row;
            int c = index % col;
            int squaresRemaining = 0;
            
            if (squares[index].Bomb == 9)
            {
                EndGame("Lose");
            }
            else
            {
                board.ViewChoice(squares, r, c);
                ViewBag.squares = squares;
            }
            
            for (int i = 0; i < row * col; i++)
            {
                if (!squares[i].Visited)
                { 
                    squaresRemaining++;
                    Debug.WriteLine("Squares remaining: " + squaresRemaining);
                }
            }

            if(squaresRemaining == numofBombs)
            {
<<<<<<< HEAD
                EndGame("Win");
=======
                TimeSpan elapsed = (DateTime.Now - startTime);
                decimal finalTime = Math.Round((decimal)elapsed.TotalSeconds, 2);

                Debug.WriteLine(String.Format("{0} start time, {1] end time", startTime, DateTime.Now));
                Debug.WriteLine("Difference in time.");
                Debug.WriteLine(String.Format("{0} days, {1} hours, {2} minutes, {3} seconds", elapsed.Days, elapsed.Hours, elapsed.Minutes, elapsed.Seconds));

                LeaderBoardService service = new LeaderBoardService();
                service.InsertHighScore(UserManagement.Instance._loggedUser, finalTime);

                ViewBag.squares = squares;
                return View("Winner");
>>>>>>> origin/Security&DatabaseChanges
            }

            return PartialView("_UpdateGame", squares);
        }
        public ActionResult EndGame(string finish)
        {
            if (finish == "Win")
            {
                return View("Winner");
            }
            else {
                return View("Loser");
            }
        }

<<<<<<< HEAD
=======
        //Added this so we have it to post a flag on a right-click of an open space
        public ActionResult OnButtonRightClick(string flagSpace)
        {
            return View("Game");
        }
>>>>>>> origin/Security&DatabaseChanges
    }
}
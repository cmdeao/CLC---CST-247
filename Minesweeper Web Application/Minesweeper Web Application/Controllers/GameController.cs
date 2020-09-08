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
<<<<<<< .merge_file_a03584
            return View("Game", squares);
=======
            Debug.WriteLine(startTime);
            return View("Game");
>>>>>>> .merge_file_a05104
        }
        [HttpPost]
        public ActionResult OnButtonClick(string mine)
        {
            int value = Int32.Parse(mine);
            int index = value - 1;
            int r = index / row;
            int c = index % col;
            int squaresRemaining = 0;
            
            if (squares[index].Bomb == 9)
            {
                ViewBag.squares = squares;
                Debug.WriteLine("GAME OVER");
                return View("Loser");
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
                TimeSpan elapsed = (DateTime.Now - startTime);
                decimal finalTime = Math.Round((decimal)elapsed.TotalSeconds, 2);

                Debug.WriteLine(String.Format("{0} start time, {1] end time", startTime, DateTime.Now));
                Debug.WriteLine("Difference in time.");
                Debug.WriteLine(String.Format("{0} days, {1} hours, {2} minutes, {3} seconds", elapsed.Days, elapsed.Hours, elapsed.Minutes, elapsed.Seconds));

                LeaderBoardService service = new LeaderBoardService();
                service.InsertHighScore(UserManagement.Instance._loggedUser, finalTime);

                ViewBag.squares = squares;
                return View("Winner");
            }

            Debug.WriteLine("RETURNING PARTIAL VIEW");
            //return PartialView("_UpdateGame", squares);
            return PartialView("TestingGame", squares);
        }
<<<<<<< HEAD

<<<<<<< .merge_file_a03584
=======
        //Added this so we have it to post a flag on a right-click of an open space
        public ActionResult OnButtonRightClick(string flagSpace)
        {
            return View("Game");
        }
>>>>>>> .merge_file_a05104
=======
>>>>>>> ce2cdd48838af9f1214b3b9a27f90acb04c11a7f
    }
}
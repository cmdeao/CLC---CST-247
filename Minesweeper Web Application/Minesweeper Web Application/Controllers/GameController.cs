﻿using Minesweeper_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Diagnostics;

namespace Minesweeper_Web_Application.Controllers
{
    
    public class GameController : Controller
    {
        public static int row = 12;
        public static int col = 12;
        public static int numofBombs = 24;
        public static List<GameSquareModel> squares = new List<GameSquareModel>();
        public static GameBoardModel board = new GameBoardModel(squares, row, col);
        public ActionResult Index()
        {
            board.PlaceBombs(squares, numofBombs);
            ViewBag.squares = squares;
            board.BombToString(squares);
            return View("Game");
        }
        public ActionResult OnButtonClick(string mine)
        {

            int value = Int32.Parse(mine);
            int index = value - 1;
            int r = index / row;
            int c = index % col;

            Debug.WriteLine("index value row column");
            Debug.WriteLine(index + " "+ value+ " "+ r + " "+ c);

            board.ViewChoice(squares, r, c);
            ViewBag.squares = squares;
            return View("Game");

        }

    }
}
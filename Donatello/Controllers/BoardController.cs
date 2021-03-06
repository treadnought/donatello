﻿using Donatello.Services;
using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatello.Controllers
{
    public class BoardController : Controller
    {
        private readonly BoardService boardService;

        public BoardController(BoardService boardService)
        {
            this.boardService = boardService;
        }

        public IActionResult Index(int id)
        {
            BoardView model = boardService.GetBoard(id);

            return View(model);
        }

        public IActionResult AddCard(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCard(NewCard vm)
        {
            if (ModelState.IsValid)
            {
                boardService.AddCard(vm);
                return RedirectToAction(nameof(Index), new { id = vm.Id });
            }
            return View(vm);
        }
    }
}

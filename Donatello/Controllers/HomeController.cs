﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello.Services;
using Donatello.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly BoardService boardService;

        public HomeController(BoardService boardService)
        {
            this.boardService = boardService;
        }
        public IActionResult Index()
        {
            BoardList model = boardService.ListBoards();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewBoard vm)
        {
            if (ModelState.IsValid)
            {
                boardService.AddBoard(vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
    }
}
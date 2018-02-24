using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello.Services;
using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
    public class CardController : Controller
    {
        private readonly CardService _cardService;

        public CardController(CardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            CardDetails vm = _cardService.GetCardDetails(id);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(CardDetails details)
        {
            if (ModelState.IsValid)
            {
                _cardService.Update(details);
                TempData["Message"] = "Card saved";
                return RedirectToAction(nameof(Details), new { id = details.Id });
            }
            return View();
        }
    }
}
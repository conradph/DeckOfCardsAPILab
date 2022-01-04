using DeckOfCardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        CardsDAL cdl = new CardsDAL();

        public IActionResult Index()
        {
            Deck d = cdl.GenerateDeck();
            return View(d);
        }
        public IActionResult Draw(string deckid)
        {
            CardDraw card = cdl.DrawCards(deckid, 5);
            return View(card);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

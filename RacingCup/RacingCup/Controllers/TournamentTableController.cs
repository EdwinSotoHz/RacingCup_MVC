using Microsoft.AspNetCore.Mvc;
using RacingCup.Models;

namespace RacingCup.Controllers
{
    public class TournamentTableController : Controller
    {
        public static TournamentTable tournamentTable = new TournamentTable();

        /***************** Registro ******************/
        public IActionResult Register()
        {
            return View("~/Views/Register/Register.cshtml", tournamentTable);
        }

        [HttpPost]
        public IActionResult RegisterParticipant(string Name, string Elements, string School, string Category, float BestTime)
        {
            var newTeam = new Team(true, Name, Elements, School, Category, BestTime);
            tournamentTable.AddWinnerToNextRow(0, newTeam, Category);

            return View("~/Views/Register/Register.cshtml", tournamentTable);
        }

        /***************** Tabla Junior ******************/
        public ActionResult JuniorBracket()
        {
            return View("~/Views/TournamentTable/JuniorBracket.cshtml", tournamentTable);
        }

        /***************** Tabla Senior ******************/
        public ActionResult SeniorBracket()
        {
            return View("~/Views/TournamentTable/SeniorBracket.cshtml", tournamentTable);
        }

        [HttpPost]
        public ActionResult Update(int row, int col, string category)
        {
            tournamentTable.SetWinnerOfThisRound(row, col, category);
            return RedirectToAction(category + "Bracket");
        }

        [HttpPost]
        public ActionResult SetLoser(int row, int col, string category)
        {
            tournamentTable.SetLoser(row, col, category);
            return RedirectToAction(category + "Bracket");
        }

        [HttpPost]
        public ActionResult UpdateBestTime(int row, int col, string category, float bestTime)
        {
            tournamentTable.UpdateBestTime(row, col, category, bestTime);
            return RedirectToAction(category + "Bracket");
        }
    }
}
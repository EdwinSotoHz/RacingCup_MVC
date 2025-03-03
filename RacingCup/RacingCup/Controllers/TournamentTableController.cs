using Microsoft.AspNetCore.Http;
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
            tournamentTable.AddWinnerToNextRow(0, newTeam);

            return View("~/Views/Register/Register.cshtml", tournamentTable);
        }

        /***************** Tabla ******************/
        public ActionResult TournamentTable()
        {
            return View("TournamentTable", tournamentTable);
        }

        [HttpPost]
        public ActionResult Update(int row, int col)
        {
            tournamentTable.SetWinnerOfThisRound(row, col);
            int nextRow = row + 1;
            tournamentTable.AddWinnerToNextRow(nextRow, tournamentTable.teams[row][col]);
            return View("TournamentTable", tournamentTable);
        }
    }
}

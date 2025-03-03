namespace RacingCup.Models
{
    public class TournamentTable
    {
        public List<List<Team>> JuniorTeams = new List<List<Team>>();
        public List<List<Team>> SeniorTeams = new List<List<Team>>();

        public void AddWinnerToNextRow(int row, Team team, string category)
        {
            var targetList = (category == "Junior") ? JuniorTeams : SeniorTeams;

            if ((targetList.Count == 0) || (targetList.Count < row + 1))
            {
                targetList.Add(new List<Team>());
            }

            if ((row == 0))
            {
                // Solo agregar equipos de ejemplo si la lista está vacía
                if (targetList[0].Count == 0)
                {
                    targetList[0].Add(new Team(true, "Equipo01", "Integrante1, Integrante2, Integrante3, Integrante4", "Escuela A", category, 12.5f));
                    targetList[0].Add(new Team(true, "Equipo02", "Integrante5, Integrante6, Integrante7, Integrante8", "Escuela B", category, 11.8f));
                    targetList[0].Add(new Team(true, "Equipo03", "Integrante9, Integrante10, Integrante11, Integrante12", "Escuela C", category, 13.2f));
                    targetList[0].Add(new Team(true, "Equipo04", "Integrante13, Integrante14, Integrante15, Integrante16", "Escuela D", category, 10.9f));
                }
            }

            targetList[row].Add(team);
        }

        public void SetWinnerOfThisRound(int row, int col, string category)
        {
            var targetList = (category == "Junior") ? JuniorTeams : SeniorTeams;

            if (targetList[row].Count % 2 != 0 && col == targetList[row].Count - 1)
            {
                // Si el número de equipos es impar y estamos en el último equipo, avanzamos automáticamente
                targetList[row][col].Status = true;
            }
            else
            {
                if (col % 2 == 0)
                {
                    targetList[row][col].Status = true;
                    targetList[row][col + 1].Status = false;
                }
                else
                {
                    targetList[row][col].Status = true;
                    targetList[row][col - 1].Status = false;
                }
            }

            // Añadir el ganador a la siguiente ronda
            if (targetList.Count <= row + 1)
            {
                targetList.Add(new List<Team>());
            }
            targetList[row + 1].Add(targetList[row][col]);
        }

        public void SetLoser(int row, int col, string category)
        {
            var targetList = (category == "Junior") ? JuniorTeams : SeniorTeams;
            targetList[row][col].Status = false;
        }

        public void UpdateBestTime(int row, int col, string category, float bestTime)
        {
            var targetList = (category == "Junior") ? JuniorTeams : SeniorTeams;
            targetList[row][col].BestTime = bestTime;
        }
    }
}
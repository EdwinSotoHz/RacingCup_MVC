namespace RacingCup.Models
{
    public class TournamentTable
    {
        public List<List<Team>> teams = new List<List<Team>>();

        public void AddWinnerToNextRow(int row, Team team)
        {
            if ((teams.Count == 0) || (teams.Count < row + 1))
            {
                teams.Add(new List<Team>());
            }
            if ((row == 0))
            {
                teams[0].Add(new Team(true, "Equipo01", "Integrante1, Integrante2, Integrante3, Integrante4", "Escuela A", "Junior", 12.5f));
                teams[0].Add(new Team(true, "Equipo02", "Integrante5, Integrante6, Integrante7, Integrante8", "Escuela B", "Junior", 11.8f));
                teams[0].Add(new Team(true, "Equipo03", "Integrante9, Integrante10, Integrante11, Integrante12", "Escuela C", "Junior", 13.2f));
                teams[0].Add(new Team(true, "Equipo04", "Integrante13, Integrante14, Integrante15, Integrante16", "Escuela D", "Junior", 10.9f));
                teams[0].Add(new Team(true, "Equipo05", "Integrante17, Integrante18, Integrante19, Integrante20", "Escuela E", "Junior", 14.3f));
                teams[0].Add(new Team(true, "Equipo06", "Integrante21, Integrante22, Integrante23, Integrante24", "Escuela F", "Junior", 9.7f));
                teams[0].Add(new Team(true, "Equipo07", "Integrante25, Integrante26, Integrante27, Integrante28", "Escuela G", "Junior", 12.0f));
                // teams[0].Add(new Team(true, "Equipo08", "Integrante29, Integrante30, Integrante31, Integrante32", "Escuela H", "Junior", 10.5f));
            }

            teams[row].Add(team);
        }


        public void SetWinnerOfThisRound(int row, int col)
        {
            //Esto funciona pero para 1 2 4 8 16 .. 
            /*
             * por lo que debe haber una validacion si es que el número de elementos en su fila es impar 
             * en dado caso evaluar los ultimos 3 elementos si pertenece a uno de los 3 ultimos elementos para que de ellos solo pase 1
             * 
             * otra solucion sería duplicar registros pero que no mame
             * 
             */
            //Validar si el siguiente existe o no
            if (col % 2 == 0)
            {
                teams[row][col].Status = true;
                teams[row][col + 1].Status = false;
            }
            else
            {
                teams[row][col].Status = true;
                teams[row][col - 1].Status = false;
            }
        }

        /*Metodo para borrar un elemento de su lista en la que está y regresar el estado de los participantes*/

        /*Metodo para borrar un elemento de su lista en la que está*/
    }
}

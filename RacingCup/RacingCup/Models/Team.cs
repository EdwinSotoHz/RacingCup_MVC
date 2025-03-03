namespace RacingCup.Models
{
    public class Team
    {
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Elements { get; set; }
        public string School { get; set; }
        public string Category { get; set; }
        public float BestTime { get; set; }

        public Team(bool status, string name, string elements, string school, string category, float bestTime)
        {
            Status = status;
            Name = name;
            Elements = elements;
            School = school;
            Category = category;
            BestTime = bestTime;
        }
    }
}

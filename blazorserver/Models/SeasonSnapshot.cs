namespace blazorserver.Models
{
    public class SeasonSnapshot
    {
        public int SeasonId { get; set; }
        public int LeagueId { get; set; }
        public int CupId { get; set; }
        public int LeaguePlacing { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
        public string Sponsor { get; set; }
        public int Rating { get; set; }
    }
}
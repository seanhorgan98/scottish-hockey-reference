using WebScraper.Interfaces;

namespace WebScraper
{
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class WebScraper : IWebScraper
    {
        private readonly ILogger<WebScraper> _log;
        private readonly ILeagueScraper _leagueScraper;
        private readonly ITeamScraper _teamScraper;
        private readonly IPointsScraper _pointsScraper;

        public WebScraper
        (
            ILogger<WebScraper> log,
            ILeagueScraper leagueScraper, 
            ITeamScraper teamScraper,
            IPointsScraper pointsScraper
        )
        {
            _log = log;
            _leagueScraper = leagueScraper;
            _teamScraper = teamScraper;
            _pointsScraper = pointsScraper;
        }

        public async Task Run()
        {
            _log.LogInformation("Entered Web Scraper class");
            
            // Scrape Leagues
            var leagueList = await _leagueScraper.Scrape();
            foreach (var league in leagueList)
            {
                _log.LogInformation("Scraped League: {League}", league.Name);
            }
            
            
            // Scrape Teams
            var teamList = await _teamScraper.Scrape();
            foreach (var team in teamList)
            {
                _log.LogInformation("Scraped Team: {Team}", team.TeamName);
            }
            
            
            // Scrape Results
            
            
            // Scrape Points
            var pointsList = await _pointsScraper.Scrape();
            foreach (var team in pointsList)
            {
                    _log.LogInformation("Team: {Teamname}, Points: {SeasonPoints}", team.TeamName, team.SeasonPoints);
            }
            // foreach team in points list, call updatepoints
        }
    }
}

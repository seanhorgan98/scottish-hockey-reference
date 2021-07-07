namespace WebScraper
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class WebScraper : IWebScraper
    {
        private readonly ILogger<WebScraper> _log;
        private readonly IConfiguration _config;

        public WebScraper(ILogger<WebScraper> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public async Task Run()
        {
            _log.LogInformation("Entered Web Scraper class.");

            var leagueList = await ScrapeLeagues.Scrape();
            _log.LogInformation("Leagues: {leagueList}", leagueList);
        }
    }
}

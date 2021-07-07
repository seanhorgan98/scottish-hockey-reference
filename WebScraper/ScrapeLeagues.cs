namespace WebScraper
{
    using AngleSharp;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;
    using AngleSharp.Dom;

    public class ScrapeLeagues
    {
        private const string LeagueUrl = "https://www.scottish-hockey.org.uk/league-standings/";

        public static async Task<List<string>> Scrape()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(LeagueUrl);
            var allLeagues = document.QuerySelectorAll("h2.text-uppercase");

            var leagueList = new List<string>();

            foreach (var item in allLeagues)
            {
                if (item.TextContent.Contains("Conference") || item.TextContent.Contains("Super"))
                {
                    System.Console.WriteLine("Skipped non-standard league: " + item.TextContent);
                    continue;
                }
                // SaveLeagueSql(item.TextContent, GetLeagueHockeyCategoryByName(item.TextContent));
                leagueList.Add(item.Text());
            }

            return leagueList;
        }
    }
}

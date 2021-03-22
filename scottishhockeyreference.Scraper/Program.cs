using System;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace scottishhockeyreference.Scraper
{
    class Program
    {
        private static readonly string leagueURL = "https://www.scottish-hockey.org.uk/league-standings/";
        static async Task Main(string[] args)
        {
            await PrintLeagues();
        }

        static async Task PrintLeagues()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(leagueURL);
            var AllLeagues = document.QuerySelectorAll("h2.text-uppercase");
            List<string> result = new List<string>();

            foreach (var item in AllLeagues)
            {
                Console.WriteLine(item.TextContent);
            }
        }
    }
}

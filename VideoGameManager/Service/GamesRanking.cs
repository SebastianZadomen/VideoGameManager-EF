using System.Xml.Linq;
using VideoGameManager.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VideoGameManager.Service
{
    public class GamesRanking
    {
        public string _Path = @".\wwwroot\Data\games_ranking.xml";

        public void Export(List<Game> games)
        {
            string? folder = Path.GetDirectoryName(_Path);
            if (folder != null && !Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var gameXml = games.OrderByDescending(g => g.Score).ToList();

            var elements = gameXml.Select(item =>
                new XElement("Game",
                    new XElement("Id", item.Id),
                    new XElement("Title", item.Title),
                    new XElement("Genre", item.Genre),
                    new XElement("Year", item.Year),
                    new XElement("Score", item.Score),
                    new XElement("Description", item.Description)
                )
            );
            XDocument doc = new XDocument(
                new XElement("GamesRanking", elements)
            );

            doc.Save(_Path);
        }

        

    }
}

using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;
using VideoGameManager.Models;

namespace VideoGameManager.Service
{
    public class GamesExporter
    {
        public string Path = @".\wwwroot\Data\games.csv";

        public void ExportToCsv(IEnumerable<Game> games)
        {
            using (var writer = new StreamWriter(Path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(games);
            }
        }
        public List<Game> ImportFromCsv()
        {
            List<Game> listGame = new List<Game>();

            using (var reader = new StreamReader(Path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var registros = csv.GetRecords<Game>().ToList();
                listGame = registros;
            }
            return listGame;

        }
    }
}

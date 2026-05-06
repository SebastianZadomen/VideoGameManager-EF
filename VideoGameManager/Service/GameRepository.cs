using System.Collections;
using System.Text.Json;
using VideoGameManager.Models;

namespace VideoGameManager.Service
{
    public class GameRepository
    {
        public string Path = @".\wwwroot\Data\games.json";


        public List<Game> LoadAll()
        {
            if (File.Exists(Path))
            {
                string json = File.ReadAllText(Path);
                List<Game> gamesList = JsonSerializer.Deserialize<List<Game>>(json) ?? new List<Game>(); ;
                return gamesList;
            }
            return new List<Game>();
        }
        public void SaveAll(IEnumerable<Game> games)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(games, options);
            File.WriteAllText(Path, jsonString);
        }
    }
}

using System.Text;
using System.Timers;
using System.IO;
using VideoGameManager.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VideoGameManager.Service
{
    public class GameService
    {
        private  List<Game> Games { get; set; }
        public string Path = @".\wwwroot\Data\activity_log.txt";
        public GameRepository GameRepository;
        public GamesExporter GamesExporter;
        public GamesRanking GamesRanking;

        public GameService()
        {
            GameRepository = new GameRepository();
            GamesExporter = new GamesExporter();
            GamesRanking = new GamesRanking();
            Games = GameRepository.LoadAll() ?? GamesExporter.ImportFromCsv();
        }

        public List<Game> GetAll()
        {
            return Games;
        }
        public Game GetById(int id)
        {
           Game searchId = Games.Find(x => x.Id == id);
            return searchId;
        }
        public void Add(Game newGame)
        {
            AddDataToFile("Add",newGame.Title);
            Games.Add(newGame);
        }
        public void Update(Game newGame)
        {
            if (newGame != null)
            {
                foreach (var item in Games)
                {
                    if (item.Id == newGame.Id)
                    {
                        item.Title = newGame.Title;
                        item.Genre = newGame.Genre;
                        item.Year = newGame.Year;
                        item.Score = newGame.Score;
                        item.Description = newGame.Description;
                        AddDataToFile("Update", newGame.Title);
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("El elemento que tratas de actualizar no existe");
            }
        }
        public void Delete(int id)
        {
            var gameDelete = GetById(id);
            if (gameDelete != null)
            {
                AddDataToFile("Delete", gameDelete.Title);
                Games.Remove(gameDelete);

            }
        }

        public int LastIdGame()
        {
            int numberLast = Games.Any() ? Games.Max(x => x.Id) : 0;
            return numberLast + 1;
        }
        public void AddDataToFile(string action, string title)
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Dispose(); 
            }
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.WriteLine($"[Date : {DateTime.Now}]");
                sw.WriteLine($"[{action}]");
                sw.WriteLine($"Game Tittle : {title}");
            }
        }
    }
}

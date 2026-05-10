using Microsoft.EntityFrameworkCore;
using VideoGameManager.Models;

namespace VideoGameManager.Data
{
    public class GameStoreContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options) { }

        public List<Developer> GetAllDeveloper()
        {
            return Developers.Include(d => d.Games).ToList();
        }
        public Developer GetByIdDeveloper(int id)
        {
            return Developers.Include(g => g.Games).FirstOrDefault(x => x.Id == id);
        }
        public void AddDeveloper(Developer newDeveloper)
        {
            Developers.Add(newDeveloper);
            SaveChanges();
        }
        public void UpdateDeveloper(Developer newDeveloper)
        {
            Developers.Update(newDeveloper);
            SaveChanges();
        }
        public void DeleteDeveloper(int id)
        {
            var developer = Developers.Find(id);
            if (developer != null)
            {
                Developers.Remove(developer);
                SaveChanges();
            }

        }



        public List<Game> GetAllGames()
        {
            return Games.Include(g => g.Developer).ToList();
        }
        public Game GetByIdGame(int id)
        {
            return Games.Include(g => g.Developer).FirstOrDefault(x => x.Id == id);
        }
        public void AddGame(Game newGame)
        {
            Games.Add(newGame);
            SaveChanges();
        }
        public void UpdateGame(Game newGame)
        {
            Games.Update(newGame);
            SaveChanges();
        }
        public void DeleteGame(int id)
        {
            var game = Games.Find(id);
            if (game != null)
            {
                Games.Remove(game);
                SaveChanges(); 
            }
            
        }
 
    }

}

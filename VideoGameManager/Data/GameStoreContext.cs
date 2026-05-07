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


        public List<Game> GetAll()
        {
            return Games.Include(g => g.Developer).ToList();
        }
        public Game GetById(int id)
        {
            return Games.Include(g => g.Developer).FirstOrDefault(x => x.Id == id);
        }
        public void Add(Game newGame)
        {
            Games.Add(newGame);
            SaveChanges();
        }
        public void Update(Game newGame)
        {
            Games.Update(newGame);
            SaveChanges();
        }
        public void Delete(int id)
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

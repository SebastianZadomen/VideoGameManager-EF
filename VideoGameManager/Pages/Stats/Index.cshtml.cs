using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoGameManager.Data;
using VideoGameManager.Models;

namespace VideoGameManager.Pages.Stats
{
    public class IndexModel : PageModel
    {
        private readonly GameStoreContext _context;
        public List<Game> RpgGames { get; set; } = new();
        public List<Game> Top5Games { get; set; } = new();

        public List<DecadeStat> ByDecade { get; set; } = new();
        public List<string> Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedGenre { get; set; }

        public IndexModel(GameStoreContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Genres = await _context.Games
             .Select(g => g.Genre)
             .Distinct()
             .ToListAsync();

            if (!string.IsNullOrEmpty(SelectedGenre))
            {
                RpgGames = await _context.Games
            .Where(g => g.Genre == SelectedGenre)
            .OrderByDescending(g => g.Score)
             .ToListAsync();
            }

             Top5Games = await _context.Games
            .Include(g => g.Developer)
            .OrderByDescending(g => g.Score)
            .Take(5)
            .ToListAsync();

              
            ByDecade = await _context.Games
            .GroupBy(g => (g.Year / 10) * 10)
            .Select(grp => new DecadeStat
            {
                Decade = grp.Key,
                Count = grp.Count()
            })
            .OrderBy(x => x.Decade)
            .ToListAsync();

        }
        public class DecadeStat
        {
            public int Decade { get; set; }
            public int Count { get; set; }
        }

    }
}

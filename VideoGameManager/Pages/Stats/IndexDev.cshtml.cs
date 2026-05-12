using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoGameManager.Data;
using VideoGameManager.Models;

namespace VideoGameManager.Pages.Stats
{
    public class IndexDevModel : PageModel
    {
        private readonly GameStoreContext _context;
        public List<Game> Results { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public string TitleFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GenreFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? MinYear { get; set; }



        public List<DevStat> AvgByDev { get; set; } = new();



        public List<Developer> ProductiveDevs { get; set; } = new();
        [BindProperty(SupportsGet = true)] 
        public int Threshold { get; set; } = 0;

        public IndexDevModel(GameStoreContext context) 
        { 
            _context = context; 
        }


        public async Task OnGetAsync()
        {
            AvgByDev = await _context.Developers
              .Include(d => d.Games)
              .Where(d => d.Games.Any())
              .Select(d => new DevStat
              {
                  Name = d.Name,
                  GameCount = d.Games.Count,
                  AvgScore = d.Games.Average(g => g.Score)
              })
              .OrderByDescending(x => x.AvgScore)
              .ToListAsync();


            var query = _context.Games.Include(g => g.Developer).AsQueryable();

            if (!string.IsNullOrEmpty(TitleFilter))
                query = query.Where(g => g.Title.Contains(TitleFilter));

            if (!string.IsNullOrEmpty(GenreFilter))
                query = query.Where(g => g.Genre == GenreFilter);

            if (MinYear.HasValue)
                query = query.Where(g => g.Year >= MinYear.Value);

            Results = await query.OrderBy(g => g.Title).ToListAsync();

            ProductiveDevs = await _context.Developers
            .Include(d => d.Games)
            .Where(d => d.Games.Count >= Threshold)
            .OrderByDescending(d => d.Games.Count)
            .ToListAsync();

        }
    }
    public class DevStat
    {
        public string Name { get; set; }
        public int GameCount { get; set; }
        public double AvgScore { get; set; }
    }

}

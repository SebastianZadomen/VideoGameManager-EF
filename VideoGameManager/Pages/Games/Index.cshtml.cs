 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoGameManager.Data;
using VideoGameManager.Models;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly GameStoreContext _context;

        public List<Game> Games { get; set; } = new();

        public IndexModel(GameStoreContext context )
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {

          

        }

    }
}

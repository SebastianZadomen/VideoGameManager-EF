using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Models;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly GameService GameService;

        public List<Game> Games { get; set; } = new();

        public IndexModel(GameService gameService)
        {
            GameService = gameService;
        }
        public void OnGet()
        {
            Games = GameService.GetAll();

        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Models;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly GameService GameService;
        public Game GameSelected { get; set; }
        public DetailsModel(GameService gameService)
        {
            GameService = gameService;
        }

        public void OnGet(int id)
        {
            GameSelected = GameService.GetById(id);
        }
        
    }
}

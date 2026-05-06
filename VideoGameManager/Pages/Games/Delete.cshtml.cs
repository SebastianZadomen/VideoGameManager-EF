using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Models;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly GameService GameService;
        public Game GameDelete { get; set; }

        public DeleteModel(GameService gameService)
        {
            GameService = gameService;
        }

        public void OnGet(int id)
        {
            GameDelete = GameService.GetById(id);
        }
        public IActionResult OnPostDelete(int id)
        {
            GameService.Delete(id);
            return RedirectToPage("/Games/Index");
        }
    }
}

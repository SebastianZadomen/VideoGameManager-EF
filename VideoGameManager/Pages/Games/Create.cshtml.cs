using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Models;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly GameService GameService;

        [BindProperty]
        public Game GameCreated { get; set; } = new Game();

        public CreateModel(GameService gameService)
        {
            GameService = gameService;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            GameCreated.Id = GameService.LastIdGame();
            GameService.Add(GameCreated);
            return RedirectToPage("/Games/Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Models;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly GameService GameService;
        [BindProperty]
        public Game GameEdit { get; set; }

        public EditModel(GameService gameService)
        {
            GameService = gameService;
        }

        public void OnGet(int id)
        {
            GameEdit = GameService.GetById(id);

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            GameService.Update(GameEdit);
            return RedirectToPage("/Games/Index");
        }
    }
}

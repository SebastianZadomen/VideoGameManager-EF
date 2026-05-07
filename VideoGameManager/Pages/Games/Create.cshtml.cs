using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Data;
using VideoGameManager.Models;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly GameStoreContext _context;
        [BindProperty]
        public Game GameCreated { get; set; } = new Game();
        public List<Developer> DeveloperList { get; set; } = new ();

        public CreateModel(GameStoreContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            DeveloperList = _context.GetAllDeveloper();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.Add(GameCreated);
            return RedirectToPage("/Games/Index");
        }
    }
}

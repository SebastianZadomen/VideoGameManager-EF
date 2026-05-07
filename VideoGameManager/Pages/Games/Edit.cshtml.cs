using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoGameManager.Data;
using VideoGameManager.Models;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly GameStoreContext _context;
        [BindProperty]
        public Game GameEdit { get; set; }

        public List<Developer> DeveloperList { get; set; }

        public EditModel(GameStoreContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            GameEdit = _context.GetById(id);

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Update(GameEdit);
            return RedirectToPage("/Games/Index");
        }
    }
}

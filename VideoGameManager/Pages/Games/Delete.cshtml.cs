using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Data;
using VideoGameManager.Models;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly GameStoreContext _context;
        public Game GameDelete { get; set; }

        public DeleteModel(GameStoreContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            GameDelete = _context.GetById(id);
        }
        public IActionResult OnPostDelete(int id)
        {
            _context.Delete(id);
            return RedirectToPage("/Games/Index");
        }
    }
}

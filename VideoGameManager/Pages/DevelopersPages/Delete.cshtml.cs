using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoGameManager.Data;
using VideoGameManager.Models;

namespace VideoGameManager.Pages.DevelopersPages
{
    public class DeleteModel : PageModel
    {
        private readonly GameStoreContext _context;
        public Developer DeveloperDelete { get; set; }
        public DeleteModel(GameStoreContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            DeveloperDelete = _context.GetByIdDeveloper(id);
        }
        public IActionResult OnPostDelete(int id)
        {
            _context.DeleteDeveloper(id);
            return RedirectToPage("/DevelopersPages/Index");
        }

    }
}

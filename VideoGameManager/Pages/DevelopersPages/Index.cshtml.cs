using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Data;
using VideoGameManager.Models;

namespace VideoGameManager.Pages.DevelopersPages
{
    public class IndexModel : PageModel
    {
        public readonly GameStoreContext _context;
        public List<Developer> Developers { get; set; } = new();

        public IndexModel(GameStoreContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Developers = _context.GetAllDeveloper();
        }
    }
}

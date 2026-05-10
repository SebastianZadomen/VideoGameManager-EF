using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Data;
using VideoGameManager.Models;

namespace VideoGameManager.Pages.DevelopersPages
{
    public class DetailsModel : PageModel
    {
        private readonly GameStoreContext _context;
        public Developer DeveloperSelect {get; set;}
        public DetailsModel(GameStoreContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            DeveloperSelect = _context.GetByIdDeveloper(id);
        }
    }
}

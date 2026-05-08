using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Data;
using VideoGameManager.Models;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly GameStoreContext _context;
        public Game GameSelected { get; set; }
        public DetailsModel(GameStoreContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            GameSelected = _context.GetById(id);
        }
        
    }
}

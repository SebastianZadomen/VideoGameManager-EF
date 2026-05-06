using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Files
{
    public class IndexModel : PageModel
    {
        public readonly GameService GameService;

        [BindProperty]
        public string Type { get; set; }
        public IndexModel(GameService gameService)
        {
            GameService = gameService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostDownloadFile()
        {

            switch (Type)
            {
                case "Txt":
                    byte[] fileBytesTxt = System.IO.File.ReadAllBytes(GameService.Path);
                    string fileNameTxt = "activity_log.txt";
                    return File(fileBytesTxt, "application/octet-stream", fileNameTxt);
                    break;
                case "Json":
                    GameService.GameRepository.SaveAll(GameService.GetAll());
                    byte[] fileBytesJson = System.IO.File.ReadAllBytes(GameService.GameRepository.Path);
                    string fileNameJson = "games.json";
                    return File(fileBytesJson, "application/octet-stream", fileNameJson);
                    break;
                case "Csv":
                    GameService.GamesExporter.ExportToCsv(GameService.GetAll());
                    byte[] fileBytesCsv = System.IO.File.ReadAllBytes(GameService.GamesExporter.Path);
                    string fileNameCsv = "games.csv";
                    return File(fileBytesCsv, "text/csv", fileNameCsv);
                    break;
                case "Xml":
                    GameService.GamesRanking.Export(GameService.GetAll());
                    byte[] fileBytesXml = System.IO.File.ReadAllBytes(GameService.GamesRanking._Path);
                    string fileNameXml = "games_ranking.xml";
                    return File(fileBytesXml, "application/xml", fileNameXml);
                    break;
            }
            return null;
        }
    }
}

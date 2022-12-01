using Microsoft.AspNetCore.Authorization;   //add this
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace RolesForAssessment.Pages
{
    [Authorize] //add this
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
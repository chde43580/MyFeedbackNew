using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Infrastructure; // ONLY FOR CREATING DUMMY DATA

namespace MyFeedback.Frontend.Pages
{
    [Authorize("IsLoggedIn")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

      //  private readonly MyFeedbackContext _dbContext;    ONLY FOR CREATING DUMMY DATA
       

        public IndexModel(ILogger<IndexModel> logger, MyFeedbackContext myFeedbackContext)
        {
            _logger = logger;

      //    _dbContext = myFeedbackContext;               ONLY FOR CREATING DUMMY DATA
        }

        public void OnGet()
        {
          
            
        }
    }
}

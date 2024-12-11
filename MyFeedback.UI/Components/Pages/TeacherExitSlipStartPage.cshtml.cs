using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared;
using System.Net.Mail;
using MyFeedback.UI.TypedClients.Interfaces;

namespace MyFeedback.Login.Pages
{

    [Authorize("IsLoggedIn")]
    public class TeacherExitSlipStartPageModel : PageModel
    {
        private readonly IExitSlipClient _exitSlipClient;
        public List<ExitSlipResultDto> ExitSlipDtoList { get; set; }

        public TeacherExitSlipStartPageModel(IExitSlipClient exitSlipClient)
        {
            this._exitSlipClient = exitSlipClient;
        }

        public async Task<IActionResult> OnGet()
        {
            if (User.HasClaim("IsStudent", "1"))
            {
                return RedirectToPage("/StudentExitSlipStartPage");
            }

           ExitSlipDtoList = await _exitSlipClient.GetAllExitSlips();

            



            return Page();

        }

        [Authorize("IsAdmin")]
        public async Task<IActionResult> OnPostDeleteExitSlip()
        {
            var formKeyList = Request.Form.Keys.ToList();

            await _exitSlipClient.DeleteExitSlip(Guid.Parse(formKeyList[0]));

            ExitSlipDtoList = await _exitSlipClient.GetAllExitSlips();



            return Page();
        }
    }
}

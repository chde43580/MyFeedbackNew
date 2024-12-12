using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.UI.Components.Pages.Model;
using MyFeedback.UI.Components.Pages.Model;
using MyFeedback.UI.TypedClients.Interfaces;
using Newtonsoft.Json;
using Shared;

namespace MyFeedback.UI.Pages
{
    public class EditExitSlipModel : PageModel
    {
        private readonly IExitSlipClient _exitSlipClient;

        public EditExitSlipModel(IExitSlipClient exitSlipClient)
        {
            this._exitSlipClient = exitSlipClient;
        }

        [BindProperty]
        public ExitSlipViewModel ExitSlipViewModel { get; set; }

        [BindProperty]
        public string EditStatus { get; set; }


        public async Task<IActionResult> OnGet(Guid? id)
        {
            if (id == null)
            { 
                return RedirectToPage("NotFound");
            }
            else
            {
                EditStatus = "";

               ExitSlipResultDto resultDto = await _exitSlipClient.GetExitSlip(id);

                ExitSlipViewModel = new ExitSlipViewModel
                {
                    Id = resultDto.Id,
                    LessonId = resultDto.LessonId,
                    IsPublished = resultDto.IsPublished,
                    RowVersion = resultDto.RowVersion,
                    QuestionList = resultDto.QuestionList
                };




                return Page();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            ExitSlipViewModel.RowVersion = Convert.FromBase64String(Request.Form["ExitSlipViewModel.RowVersion"]);

             var clientResult = await _exitSlipClient.UpdateExitSlip(ExitSlipViewModel);

             var resultDeserialized = JsonConvert.DeserializeObject<UpdateResult>(clientResult.JsonResponse);

             EditStatus = resultDeserialized.message;



            if (EditStatus == "Update successful")
            {
                return RedirectToPage("TeacherExitSlipStartPage");
            }
            else
            {
                return Page();
            }




            UpdateExitSlipDto updateExitSlipDto = new UpdateExitSlipDto();

            updateExitSlipDto.Id = ExitSlipDto.Id;
            updateExitSlipDto.RowVersion = ExitSlipDto.RowVersion;
            updateExitSlipDto.LessonId = ExitSlipDto.LessonId;
            updateExitSlipDto.QuestionList = ExitSlipDto.QuestionList;

            if (ExitSlipDto.IsPublished == false)
            {
                updateExitSlipDto.IsPublished = IsChecked;
            }
            else
            {
                updateExitSlipDto.IsPublished = ExitSlipDto.IsPublished; // I dette tilf�lde tilsvarer dette altid, at s�tte updateDto'ens IsPublished til true
            }


            this._exitSlipCommand.UpdateExitSlip(updateExitSlipDto);

            if (User.HasClaim("IsTeacher", "1"))
            {
                return RedirectToPage("TeacherExitSlipStartPage"); // Underviseren �nsker nok komme tilbage til sin exit slip-startside, s� de kan f� vist deres nyopdaterede exit slip
            }

            else if (User.HasClaim("IsStudent", "1"))
            {
                return RedirectToPage("StudentForumStartpage"); // PO �nskede man som studerende skulle sendes tilbage til deres forums startside
            }

            else
            {
                return Page();
            }
        }
    }
}

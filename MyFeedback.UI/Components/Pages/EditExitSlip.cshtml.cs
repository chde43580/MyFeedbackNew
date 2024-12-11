using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.UI.Pages.Model;
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
            if (id == null) // Hvis man har navigeret til denne side UDEN / MED ET TOMT id-parameter i URL'en, skal man blot sendes til en NotFound-side
            {
                //return Results.Problem(
                //    statusCode: StatusCodes.Status404NotFound,
                //    title: "Error 404 Exit Slip with that ID not found",
                //    type: "https://tools.ietf.org/html/rfc7231#section-6.5.1", // Skal v�re en anden RFC (denne er for fejl 400)
                //    extensions: new Dictionary<string, object>
                //    {
                //        { "errors", new[] {Error.NotFound } }
                //    });

                return RedirectToPage("NotFound");

            }
            else
            {
                EditStatus = "";

               ExitSlipResultDto resultDto = await _exitSlipClient.GetExitSlip(id); // Her kunne man evt. k�re noget validering p� id-variablen fra URL'et; for hvad hvis brugeren inputter et ugyldigt id

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
            //   Request.Form("CreateQuestionRequestDto");

            //    ExitSlipViewModel.QuestionList.Add(CreateQuestionRequestDto);

            //var testMe = ExitSlipViewModel;

            //var testMeAsWell = Request.Form;


            //return Page();

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




            // UpdateExitSlipDto updateExitSlipDto = new UpdateExitSlipDto();

            // updateExitSlipDto.Id = ExitSlipDto.Id;
            // updateExitSlipDto.RowVersion = ExitSlipDto.RowVersion;
            // updateExitSlipDto.LessonId = ExitSlipDto.LessonId;
            // updateExitSlipDto.QuestionList = ExitSlipDto.QuestionList;

            // if (ExitSlipDto.IsPublished == false)
            // {
            //     updateExitSlipDto.IsPublished = IsChecked;
            // }
            // else
            // {
            //     updateExitSlipDto.IsPublished = ExitSlipDto.IsPublished; // I dette tilf�lde tilsvarer dette altid, at s�tte updateDto'ens IsPublished til true
            // }


            //this._exitSlipCommand.UpdateExitSlip(updateExitSlipDto);

            // if (User.HasClaim("IsTeacher", "1"))
            // {
            //     return RedirectToPage("TeacherExitSlipStartPage"); // Underviseren �nsker nok komme tilbage til sin exit slip-startside, s� de kan f� vist deres nyopdaterede exit slip
            // }

            // else if (User.HasClaim("IsStudent", "1"))
            // {
            //     return RedirectToPage("StudentForumStartpage"); // PO �nskede man som studerende skulle sendes tilbage til deres forums startside
            // }

            // else 
            // {
            //     return Page();
            // }
        }
    }
}

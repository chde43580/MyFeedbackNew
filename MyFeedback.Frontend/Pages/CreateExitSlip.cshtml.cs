using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Frontend.TypedClients.Interfaces;
using Shared;
using System.Linq;

namespace MyFeedback.Frontend.Pages
{
    [Authorize("IsLoggedIn")]
    public class ExitSlipModel : PageModel
    {

        // Injecter IExitSlipClient, så man kan kalde dens metoder mod REST-API'en
        private readonly IExitSlipClient _exitSlipClient;

        private readonly ILessonClient _lessonClient;



        [BindProperty]
        public CreateExitSlipRequestDto createExitSlipRequestDto { get; set; } // Binder så brugerens tekst kan trackes og sendes videre til API'en

        [BindProperty]
        public List<Guid> lessonIdList { get; set; }


        public ExitSlipModel(IExitSlipClient exitSlipClient, ILessonClient lessonClient)
        {

            _exitSlipClient = exitSlipClient; // Constructor injection
            _lessonClient = lessonClient;
        }

        public async Task<IActionResult> OnGet()
        {
          
                var tempDtoList = await _lessonClient.GetAllLessons();

                lessonIdList = tempDtoList.Select(e => e.Id).ToList();

      
            if (createExitSlipRequestDto == null)
            {
                createExitSlipRequestDto = new CreateExitSlipRequestDto();

                createExitSlipRequestDto.QuestionList = new List<CreateQuestionRequestDto>();

                createExitSlipRequestDto.QuestionList.Add(new CreateQuestionRequestDto(){ QuestionNumber = 1, QuestionText = "" });

            }

            return Page();
        }

        public IActionResult OnPostCreateExitSlip()
        {

        //    createExitSlipRequestDto.LessonId = new Guid(); // NEEDS TO BE THE ACTUAL LESSON ID LATER ON

          

            _exitSlipClient.CreateExitSlip(createExitSlipRequestDto);

            return RedirectToPage("TeacherExitSlipStartPage");

        }

        public IActionResult OnPostAddQuestion()
        {
            createExitSlipRequestDto.QuestionList.Add(new CreateQuestionRequestDto());

            return Page();
        }
    }
}

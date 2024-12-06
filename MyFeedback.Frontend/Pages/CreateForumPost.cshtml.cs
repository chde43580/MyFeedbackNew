using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Application.Command;
using MyFeedback.Application.Command.CommandDto.ForumPost;
using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;

namespace MyFeedback.Frontend.Pages
{
    public class CreateForumPostModel : PageModel
    {
        private readonly IForumPostCommand _forumPostCommand;

        private readonly ICategoryQuery _categoryQuery;

        public CreateForumPostModel(IForumPostCommand forumPostCommand, ICategoryQuery categoryQuery)
        {
            this._forumPostCommand = forumPostCommand;

            this._categoryQuery = categoryQuery;
        }

        [BindProperty]
        public ForumPostQueryDto ForumPostDto { get; set; }

        [BindProperty]
        public IEnumerable<CategoryQueryDto> CategoryDtoList { get; set; }

        public void OnGet()
        {
            CategoryDtoList = _categoryQuery.GetAll();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            else
            {

                CreateForumPostDto createForumPostDto = new CreateForumPostDto
                {
                    ProblemText = ForumPostDto.ProblemText,
                    SolutionText = ForumPostDto.SolutionText,
                    CategoryId = Guid.Parse(Request.Form["Category"])
                };
                   

                _forumPostCommand.CreateForumPost(createForumPostDto);

                return RedirectToPage("StudentForumStartpage"); // Kunne man måske bruge CategoryId ovenfor til sende til rette forum-underside?
            }
        }
    }
}

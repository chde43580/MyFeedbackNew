using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command.CommandDto.ForumPost
{
    public record CreateForumPostDto
    {
        public string ProblemText { get; set; }
        public string SolutionText { get; set; }

        public Guid CategoryId { get; set; }
    }
}

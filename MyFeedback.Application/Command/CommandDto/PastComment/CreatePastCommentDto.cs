using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command.CommandDto.PastComment
{
    public record CreatePastCommentDto
    {
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}

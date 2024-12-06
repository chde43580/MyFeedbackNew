using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command.CommandDto.Comment
{
    public record CreateCommentDto
    {
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid IdentityUserId { get; set; }
    }
}

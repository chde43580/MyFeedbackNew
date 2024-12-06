using MyFeedback.Application.Command.CommandDto.PastComment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command.CommandDto.Comment
{
    public record UpdateCommentDto
    {
        public Guid Id { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }

        public List<CreatePastCommentDto> PastComments { get; set; }
        public Guid IdentityUserId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

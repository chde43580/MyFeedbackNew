using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command.CommandDto.ForumPost
{
    public record DeleteForumPostDto
    {
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

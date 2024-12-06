using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Query.QueryDto
{
    public record CommentQueryDto
    {
        public Guid Id { get; set; }
        public Guid IdentityUserId { get; set; }
        public List<PastComment> PastComments { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Query.QueryDto
{
    public record AnswerQueryDto
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Guid IdentityUserId { get; set; }
        public string AnswerText { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

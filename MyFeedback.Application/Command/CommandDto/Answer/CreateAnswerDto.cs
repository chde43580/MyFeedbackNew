using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command.CommandDto.Answer
{
    public record CreateAnswerDto
    {
        public Guid QuestionId { get; set; }
        public Guid IdentityUserId { get; set; }
        public string AnswerText { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command.CommandDto.Answer
{
    public record UpdateAnswerDto
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Guid IdentityUserId { get; set; }
        public string AnswerText { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

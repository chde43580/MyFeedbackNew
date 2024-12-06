using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command.CommandDto.Question
{
    public record CreateQuestionDto
    {
        public string QuestionText { get; set; }
        public int QuestionNumber { get; set; }
    }
}

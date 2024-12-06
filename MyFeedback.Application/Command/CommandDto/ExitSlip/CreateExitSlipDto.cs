using MyFeedback.Application.Command.CommandDto.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command.CommandDto.ExitSlip
{
    public record CreateExitSlipDto
    {
        public Guid LessonId { get; set; }

        public List<CreateQuestionDto> QuestionList { get; set; } = null!;

        public bool IsPublished { get; set; }

    }
}

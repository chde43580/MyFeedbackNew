using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record CreateExitSlipRequestDto
    {
        public Guid LessonId { get; set; }

        public List<CreateQuestionRequestDto> QuestionList { get; set; } // = null!;

        public bool IsPublished { get; set; }
    }

   
}

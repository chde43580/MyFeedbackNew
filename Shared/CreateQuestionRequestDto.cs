using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record CreateQuestionRequestDto
    {
        public string QuestionText { get; set; }
        public int QuestionNumber { get; set; }
    }
}

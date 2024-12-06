using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Frontend.Pages.Model
{
    public record ExitSlipViewModel
    {
        public Guid Id { get; set; }

        public Guid LessonId { get; set; }

        public List<CreateQuestionRequestDto> QuestionList { get; set; } // Skal det blive til en anden slags question-dto

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public bool IsPublished { get; set; }
    }
}

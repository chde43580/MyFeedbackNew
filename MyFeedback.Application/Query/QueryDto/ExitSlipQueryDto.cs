using MyFeedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Query.QueryDto
{
    public record ExitSlipQueryDto
    {
        public Guid Id { get; set; }

        public Guid LessonId { get; set; }

        public List<Question> QuestionList { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public bool IsPublished { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Query.QueryDto
{
    public record LessonQueryDto
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public Guid CourseId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

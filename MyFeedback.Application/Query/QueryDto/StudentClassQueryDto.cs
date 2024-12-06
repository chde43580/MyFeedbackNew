using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Query.QueryDto
{
    public record StudentClassQueryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> StudentIds { get; set; }
        public DateOnly GraduationDate { get; set; }
        public Guid CourseId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

}

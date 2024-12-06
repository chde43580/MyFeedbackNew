using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Query.QueryDto
{
    public record CourseQueryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> StudentClassIds { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Guid SchoolId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

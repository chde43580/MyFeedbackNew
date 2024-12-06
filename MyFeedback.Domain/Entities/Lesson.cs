using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class Lesson : DomainEntity
    {
        public DateTime StartDate { get; protected set; }
        public Guid CourseId { get; protected set; }

        public Lesson() { }

        public Lesson(DateTime startDate, Guid courseId)
        {
            StartDate = startDate;
            CourseId = courseId;
        }

    }
}

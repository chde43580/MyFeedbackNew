using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class Course : DomainEntity
    {
        public string Name { get; protected set; }
        public List<Guid> StudentClassIds { get; protected set; }
        public DateOnly StartDate { get; protected set; }
        public DateOnly EndDate { get; protected set; }
        public Guid SchoolId { get; protected set; }

        public Course()
        {
            
        }

        public Course(string name, List<Guid> studentclassIds, DateOnly startDate, DateOnly endDate, Guid schoolId)
        {
            Name = name;
            StudentClassIds = studentclassIds;
            StartDate = startDate;
            EndDate = endDate;
            SchoolId = schoolId;
        }
    }
}

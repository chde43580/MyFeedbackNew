using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class StudentClass : DomainEntity
    {
        public string Name { get; protected set; }
        public List<Guid> StudentIds { get; protected set; }
        public DateOnly GraduationDate { get; protected set; }
        public Guid CourseId { get; protected set; }

        public StudentClass()
        {
            
        }

        public StudentClass(string name, List<Guid> studenIds, DateOnly graduationDate, Guid courseId)
        {
            Name = name;
            StudentIds = studenIds;
            GraduationDate = graduationDate;
            CourseId = courseId;
        }
    }
}

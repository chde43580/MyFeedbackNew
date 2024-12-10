using Microsoft.EntityFrameworkCore;
using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFeedback.Domain.Entities;

namespace MyFeedback.Infrastructure.Query
{
    public class CourseQuery : ICourseQuery
    {
        private readonly MyFeedbackContext _dbContext;

        public CourseQuery(MyFeedbackContext dbContext)
        {
            _dbContext = dbContext;
        }

        CourseQueryDto ICourseQuery.Get(Guid? id)
        {
            Course domainCourse = _dbContext.Courses.AsNoTracking().Include(e => e.StudentClassIds).Single(e => e.Id == id);

            CourseQueryDto dtoReturn = new CourseQueryDto()
            {
                Id = domainCourse.Id,
                Name = domainCourse.Name,
                StudentClassIds = domainCourse.StudentClassIds,
                StartDate = domainCourse.StartDate,
                EndDate = domainCourse.EndDate,
                SchoolId = domainCourse.SchoolId,
                RowVersion = domainCourse.RowVersion,
            };

            return dtoReturn;
        }

        IEnumerable<CourseQueryDto> ICourseQuery.GetAll()
        {
            var listOfDtos = _dbContext.Courses.AsNoTracking().Select(e => new CourseQueryDto
            {
                Id = e.Id,
                Name = e.Name,
                StudentClassIds = e.StudentClassIds,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                SchoolId= e.SchoolId,
                RowVersion = e.RowVersion,
            });

            return listOfDtos;
        }
    }
}

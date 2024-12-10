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
    public class LessonQuery : ILessonQuery
    {
        private readonly MyFeedbackContext _dbContext;

        public LessonQuery(MyFeedbackContext dbContext)
        {
            _dbContext = dbContext;
        }

        LessonQueryDto ILessonQuery.Get(Guid? id)
        {
            Lesson domainLesson = _dbContext.Lessons.AsNoTracking().Single(e => e.Id == id);

            LessonQueryDto dtoReturn = new LessonQueryDto
            {
                Id = domainLesson.Id,
                StartDate = domainLesson.StartDate,
                CourseId = domainLesson.CourseId,
                RowVersion = domainLesson.RowVersion,
            };

            return dtoReturn;
        }

        IEnumerable<LessonQueryDto> ILessonQuery.GetAll()
        {
            var listOfDtos = _dbContext.Lessons.AsNoTracking().Select(e => new LessonQueryDto
            {
                Id = e.Id,
                StartDate = e.StartDate,
                CourseId = e.CourseId,
                RowVersion = e.RowVersion,
            });

            return listOfDtos;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Infrastructure.Query
{
    public class ExitSlipQuery : IExitSlipQuery
    {
        private readonly MyFeedbackContext _dbContext;

         public ExitSlipQuery(MyFeedbackContext dbContext)
        {
            this._dbContext = dbContext;
        }

        IEnumerable<ExitSlipQueryDto> IExitSlipQuery.GetAll()
        {
         
            var listOfDtos = _dbContext.ExitSlips.AsNoTracking().Select(e => new ExitSlipQueryDto
            {
                Id = e.Id,
                LessonId = e.LessonId,
                QuestionList = e.QuestionList,
                RowVersion = e.RowVersion,
                IsPublished = e.IsPublished,
            });

             

            return listOfDtos;
        }

        ExitSlipQueryDto IExitSlipQuery.Get(Guid? id)
        {
            var domainExitSlip = _dbContext.ExitSlips.AsNoTracking().Include(e => e.QuestionList).Single(e => e.Id == id);



            ExitSlipQueryDto dtoToReturn = new ExitSlipQueryDto
            {
                Id = domainExitSlip.Id,
                LessonId = domainExitSlip.LessonId,
                QuestionList = domainExitSlip.QuestionList,
                 RowVersion = domainExitSlip.RowVersion,
                IsPublished = domainExitSlip.IsPublished
            };

            return dtoToReturn;

        }

        bool IExitSlipQuery.GetReadonly(bool publishStatus)
        {
            var exitSlip = _dbContext.ExitSlips.AsNoTracking().First();

            return exitSlip.AssureUpdateImpossibleIfPublished(publishStatus);
        }
    }
}

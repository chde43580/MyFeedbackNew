using Microsoft.EntityFrameworkCore;
using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Infrastructure.Query
{
    public class AnswerQuery : IAnswerQuery
    {
        private readonly MyFeedbackContext _dbContext;

        public AnswerQuery(MyFeedbackContext dbContext)
        {
            _dbContext = dbContext;
        }

        AnswerQueryDto IAnswerQuery.Get(Guid id)
        {
            var domainAnswer = _dbContext.Answers.AsNoTracking().Single(c => c.Id == id);

            AnswerQueryDto dtoToReturn = new AnswerQueryDto
            {
                Id = domainAnswer.Id,
                IdentityUserId = domainAnswer.IdentityUserId,
                QuestionId = domainAnswer.QuestionId,
                AnswerText = domainAnswer.AnswerText,
                RowVersion = domainAnswer.RowVersion,
            };

            return dtoToReturn;
        }

        IEnumerable<AnswerQueryDto> IAnswerQuery.GetAll()
        {
            var listOfDto = _dbContext.Answers.AsNoTracking().Select(c => new AnswerQueryDto()
            {
                Id = c.Id,
                QuestionId = c.QuestionId,
                IdentityUserId = c.IdentityUserId,
                AnswerText = c.AnswerText,
                RowVersion = c.RowVersion,
            });

            return listOfDto;
        }
    }
}

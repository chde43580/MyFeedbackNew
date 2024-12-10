using MyFeedback.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFeedback.Domain.Entities;

namespace MyFeedback.Infrastructure.Repositories
{
    public class AnswerRepo : IAnswerRepo
    {
        private readonly MyFeedbackContext _dbContext;

        public AnswerRepo(MyFeedbackContext dbContext)
        {
            _dbContext = dbContext;
        }

        void IAnswerRepo.AddAnswer(Answer answer)
        {
            _dbContext.Answers.Add(answer);
            _dbContext.SaveChanges();
        }

        Answer IAnswerRepo.GetAnswer(Guid id)
        {
            return _dbContext.Answers.Single(b => b.Id == id);
        }

        void IAnswerRepo.UpdateAnswer(Answer answer, byte[] rowVersion)
        {
            _dbContext.Entry(answer).Property(nameof(answer.RowVersion)).OriginalValue = rowVersion;
            _dbContext.Answers.Update(answer);
            _dbContext.SaveChanges();
        }
    }

}


using MyFeedback.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFeedback.Domain.Entities;

namespace MyFeedback.Infrastructure.Repositories
{
    public class PastCommentRepo : IPastCommentRepo
    {
        private readonly MyFeedbackContext _dbContext;

        public PastCommentRepo(MyFeedbackContext dbContext)
        {
            this._dbContext = dbContext;
        }

        void IPastCommentRepo.AddPastComment(PastComment pastComment)
        {
            _dbContext.PastComments.Add(pastComment);

            _dbContext.SaveChanges();
        }
    }
}

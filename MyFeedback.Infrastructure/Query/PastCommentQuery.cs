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
    public class PastCommentQuery : IPastCommentQuery
    {
        private readonly MyFeedbackContext _dbContext;

        public PastCommentQuery(MyFeedbackContext dbContext)
        {
            this._dbContext = dbContext;
        }

        IEnumerable<PastCommentQueryDto> IPastCommentQuery.GetAll()
        {

            var listOfDtos = _dbContext.PastComments.AsNoTracking().Select(e => new PastCommentQueryDto
            {
                Id = e.Id,
                CommentDate = e.CommentDate,
                CommentText = e.CommentText,
                RowVersion = e.RowVersion,
            });

            return listOfDtos;
        }

        PastCommentQueryDto IPastCommentQuery.Get(Guid id)
        {
            PastComment domainComment = _dbContext.PastComments.AsNoTracking().Single(e => e.Id == id);

            PastCommentQueryDto dtoToReturn = new PastCommentQueryDto
            {
                Id = domainComment.Id,
                CommentDate = domainComment.CommentDate,
                CommentText = domainComment.CommentText,
                RowVersion = domainComment.RowVersion,
            };

            return dtoToReturn; 
        }
    }
}

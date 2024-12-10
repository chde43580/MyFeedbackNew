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
    public class CommentQuery : ICommentQuery
    {
        private readonly MyFeedbackContext _dbContext;

        public CommentQuery(MyFeedbackContext dbContext)
        {
            _dbContext = dbContext;
        }

        CommentQueryDto ICommentQuery.Get(Guid? id)
        {
            Comment domainComment = _dbContext.Comments.AsNoTracking().Include(c => c.PastComments).Single(c => c.Id == id);

            CommentQueryDto dtoToReturn = new CommentQueryDto
            {
                Id = domainComment.Id,
                CommentDate = domainComment.CommentDate,
                CommentText = domainComment.CommentText,
                PastComments = domainComment.PastComments,
                IdentityUserId = domainComment.IdentityUserId,
                RowVersion = domainComment.RowVersion,
            };

            return dtoToReturn;
        }

        IEnumerable<CommentQueryDto> ICommentQuery.GetAll()
        {
            var listOfDto = _dbContext.Comments.AsNoTracking().Select(c => new CommentQueryDto()
            {
                Id = c.Id,
                CommentDate = c.CommentDate,
                CommentText = c.CommentText,
                PastComments = c.PastComments,
                IdentityUserId = c.IdentityUserId,
                RowVersion = c.RowVersion,
            });

            return listOfDto;
        }
    }
}

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
    public class ForumPostQuery : IForumPostQuery
    {
        private readonly MyFeedbackContext _dbContext;

        public ForumPostQuery(MyFeedbackContext dbContext)
        {
            this._dbContext = dbContext;
        }

        ForumPostQueryDto IForumPostQuery.Get(Guid? id)
        {
            ForumPost domainForumPost = _dbContext.ForumPosts.AsNoTracking().Include(f => f.Comments).Single(f => f.Id == id);

            ForumPostQueryDto dtoToReturn = new ForumPostQueryDto
            {
                Id = domainForumPost.Id,
                PostDate = domainForumPost.PostDate,
                CommentList = domainForumPost.Comments,
                CategoryId = domainForumPost.CategoryId,
                ProblemText = domainForumPost.ProblemText,
                SolutionText = domainForumPost.SolutionText,
                UpVotes = domainForumPost.UpVotes,
                DownVotes = domainForumPost.DownVotes,
                IsLocked = domainForumPost.IsLocked
            };

            return dtoToReturn;

        }

        IEnumerable<ForumPostQueryDto> IForumPostQuery.GetAll()
        {
            IEnumerable<ForumPostQueryDto> listOfDtos = _dbContext.ForumPosts.AsNoTracking().Select(f => new ForumPostQueryDto
            {
                Id = f.Id,
                PostDate = f.PostDate,
                CommentList = f.Comments,
                CategoryId = f.CategoryId,
                ProblemText = f.ProblemText,
                SolutionText = f.SolutionText,
                UpVotes = f.UpVotes,
                DownVotes = f.DownVotes,
                IsLocked = f.IsLocked
            });

            return listOfDtos;
        }
    }
}

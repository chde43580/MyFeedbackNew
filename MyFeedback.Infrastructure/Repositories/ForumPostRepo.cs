using MyFeedback.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Infrastructure.Repositories
{
    public class ForumPostRepo : IForumPostRepo
    {
        private readonly MyFeedbackContext _dbContext;

        public ForumPostRepo(MyFeedbackContext myFeedbackContext)
        {
            this._dbContext = myFeedbackContext;
        }

        void IForumPostRepo.AddForumPost(ForumPost forumPost)
        {
            _dbContext.ForumPosts.Add(forumPost);

            _dbContext.SaveChanges();
        }

        void IForumPostRepo.DeleteForumPost(ForumPost forumPost, byte[] rowVersion)
        {
            _dbContext.Entry(forumPost).Property(nameof(forumPost.RowVersion)).OriginalValue = rowVersion;

            _dbContext.ForumPosts.Remove(forumPost);

            _dbContext.SaveChanges();
        }

        ForumPost IForumPostRepo.GetForumPost(Guid id)
        {
            return _dbContext.ForumPosts.Single(f => f.Id == id);
        }
    }
}

using MyFeedback.Application.Repositories;
using MyFeedback.Domain.Entities;

namespace MyFeedback.Infrastructure.Repositories
{
    public class CommentRepo : ICommentRepo
    {
        private readonly MyFeedbackContext _dbContext;

        public CommentRepo(MyFeedbackContext dbContext)
        {
            _dbContext = dbContext;
        }

        void ICommentRepo.AddComment(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }

        Comment ICommentRepo.GetComment(Guid id)
        {
            return _dbContext.Comments.Single(b => b.Id == id);
        }

        void ICommentRepo.UpdateComment(Comment comment, byte[] rowVersion)
        {
            _dbContext.Entry(comment).Property(nameof(comment.RowVersion)).OriginalValue = rowVersion;
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
        }
    }
}

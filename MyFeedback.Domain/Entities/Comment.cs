using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class Comment : DomainEntity
    {
        public string CommentText { get; protected set; }
        public DateTime CommentDate { get; protected set; }
        public List<PastComment> PastComments { get; protected set; }
        public Guid IdentityUserId { get; protected set; }

        public Comment()
        {
            
        }

        public Comment(string commentText, DateTime commentDate, List<PastComment> pastComments, Guid identityUserId)
        {
            CommentText = commentText;
            CommentDate = commentDate;
            PastComments = pastComments;
            IdentityUserId = identityUserId;
        }

        public static Comment Create(string commentText, DateTime commentDate, List<PastComment> pastComments, Guid identityUserId)
        {
            Comment newComment = new Comment(commentText, commentDate, pastComments, identityUserId);
            return newComment;
        }

        public void Update(string commentText, DateTime commentDate, List<PastComment> pastComments, Guid identityUserId)
        {
            CommentText = commentText;
            CommentDate = commentDate;
            PastComments = pastComments;
            IdentityUserId = identityUserId;
        }
    }
}

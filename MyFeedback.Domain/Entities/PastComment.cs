using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class PastComment : DomainEntity
    {
        public string CommentText { get; protected set; }
        public DateTime CommentDate { get; protected set; }

        public PastComment()
        {
            
        }

        public PastComment(string commentText, DateTime commentDate)
        {
            CommentText = commentText;
            CommentDate = commentDate;
        }

        public static PastComment Create(string commentText, DateTime commentDate)
        {
            PastComment newPastCommet = new PastComment(commentText, commentDate);

            return newPastCommet;
        }
    }
}

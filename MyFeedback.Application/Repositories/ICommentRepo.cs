using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Repositories
{
    public interface ICommentRepo
    {
        Comment GetComment(Guid id);

        void AddComment(Comment comment);

        void UpdateComment(Comment comment, byte[] rowVersion);
    }
}

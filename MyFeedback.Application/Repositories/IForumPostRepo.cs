using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFeedback.Domain.Entities;

namespace MyFeedback.Application.Repositories
{
    public interface IForumPostRepo
    {
        ForumPost GetForumPost(Guid id);

        void AddForumPost(ForumPost forumPost);

        void DeleteForumPost(ForumPost forumPost, byte[] rowVersion);
    }
}

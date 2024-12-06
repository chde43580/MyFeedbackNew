using MyFeedback.Application.Command.CommandDto.ExitSlip;
using MyFeedback.Application.Command.CommandDto.ForumPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command
{
    public interface IForumPostCommand
    {
        void CreateForumPost(CreateForumPostDto createForumPostDto);
        void DeleteForumPost(DeleteForumPostDto deleteForumPostDto);
    }
}

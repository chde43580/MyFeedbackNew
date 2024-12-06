using MyFeedback.Application.Command.CommandDto.PastComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command
{
    public interface IPastCommentCommand
    {
        void CreatePastComment(CreatePastCommentDto createPastCommentDto);
    }
}

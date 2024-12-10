using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFeedback.Domain.Entities;

namespace MyFeedback.Application.Repositories
{
    public interface IPastCommentRepo
    {
        void AddPastComment(PastComment pastcomment);
    }
}

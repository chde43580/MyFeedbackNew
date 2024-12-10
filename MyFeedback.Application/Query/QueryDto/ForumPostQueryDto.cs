using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFeedback.Domain.Entities;

namespace MyFeedback.Application.Query.QueryDto
{
    public record ForumPostQueryDto
    {
        public Guid Id { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        public DateTime PostDate { get; set; }

        public List<Comment> CommentList { get; set; }

        public Guid CategoryId { get; set; }
        [MaxLength(200)]
        public string ProblemText { get; set; }
        [MaxLength(200)]
        public string SolutionText { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public bool IsLocked { get; set; }

        public int TimesReported { get; set; }
    }
}

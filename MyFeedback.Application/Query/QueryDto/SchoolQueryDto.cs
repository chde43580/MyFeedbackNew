using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Query.QueryDto
{
    public record SchoolQueryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

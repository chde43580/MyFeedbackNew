using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Query.QueryDto
{
    public class CategoryQueryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

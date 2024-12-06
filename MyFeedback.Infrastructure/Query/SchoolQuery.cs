using Microsoft.EntityFrameworkCore;
using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Infrastructure.Query
{
    public class SchoolQuery : ISchoolQuery
    {
        private readonly MyFeedbackContext _dbContext;

        public SchoolQuery(MyFeedbackContext dbContext)
        {
            _dbContext = dbContext;
        }

        SchoolQueryDto ISchoolQuery.Get(Guid id)
        {
            School domainSchool = _dbContext.Schools.AsNoTracking().Single(c => c.Id == id);

            SchoolQueryDto dtoToReturn = new SchoolQueryDto
            {
                Id = domainSchool.Id,
                Name = domainSchool.Name,
                Address = domainSchool.Address,
                RowVersion = domainSchool.RowVersion,
            };

            return dtoToReturn;
        }

        IEnumerable<SchoolQueryDto> ISchoolQuery.GetAll()
        {
            var listOfDto = _dbContext.Schools.AsNoTracking().Select(c => new SchoolQueryDto()
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                RowVersion = c.RowVersion,
            });

            return listOfDto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record LessonResultDto
    {
        public Guid Id { get; set; }

        // Der kunne være flere properties her, men indtil videre har vi kun haft brug for Id-property'en
    }
}

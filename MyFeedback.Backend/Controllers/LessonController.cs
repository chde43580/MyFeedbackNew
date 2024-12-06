using Microsoft.AspNetCore.Mvc;
using MyFeedback.Application.Command;
using MyFeedback.Application.Query.QueryDto;
using MyFeedback.Application.Query;
using Shared;

namespace MyFeedback.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {

        private readonly ILessonQuery _lessonQuery;


        public LessonController(ILessonQuery lessonQuery)
        {
            _lessonQuery = lessonQuery;
        }

        // GET ALL: <LessonController>
        [HttpGet]
        public IEnumerable<LessonQueryDto> GetAll()
        {
            IEnumerable<LessonQueryDto> lessonResultDtos = _lessonQuery.GetAll();

            return lessonResultDtos;
        }
    }
}

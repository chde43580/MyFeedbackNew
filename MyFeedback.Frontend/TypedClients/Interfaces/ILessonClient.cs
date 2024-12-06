using Shared;

namespace MyFeedback.Frontend.TypedClients.Interfaces
{
    public interface ILessonClient
    {
        public Task<List<LessonResultDto>> GetAllLessons();
    }
}

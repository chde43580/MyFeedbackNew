using Shared;

namespace MyFeedback.Login.TypedClients.Interfaces
{
    public interface ILessonClient
    {
        public Task<List<LessonResultDto>> GetAllLessons();
    }
}

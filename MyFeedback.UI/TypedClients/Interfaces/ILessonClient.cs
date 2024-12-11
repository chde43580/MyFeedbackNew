using Shared;

namespace MyFeedback.UI.TypedClients.Interfaces
{
    public interface ILessonClient
    {
        public Task<List<LessonResultDto>> GetAllLessons();
    }
}

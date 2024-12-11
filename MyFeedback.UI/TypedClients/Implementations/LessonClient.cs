using MyFeedback.UI.TypedClients.Interfaces;
using Shared;

namespace MyFeedback.UI.TypedClients.Implementations
{
    public class LessonClient : ILessonClient
    {
        private readonly HttpClient _client;

        public LessonClient(HttpClient client)
        {
            this._client = client;
        }
       async Task<List<LessonResultDto>> ILessonClient.GetAllLessons()
        {
            return await _client.GetFromJsonAsync<List<LessonResultDto>>("/Lesson");
        }
    }
}

using MyFeedback.Frontend.Pages.Model;
using MyFeedback.Frontend.TypedClients.Interfaces;
using MyFeedback.Application.Query.QueryDto;
using Shared;
using Microsoft.AspNetCore.Authorization;
using Azure.Core;

namespace MyFeedback.Frontend.TypedClients.Implementations
{
    public class ExitSlipClient : IExitSlipClient
    {
        private readonly HttpClient _client;
        public ExitSlipClient(HttpClient client)
        {
            _client = client;
        }

        async Task IExitSlipClient.CreateExitSlip(CreateExitSlipRequestDto createExitSlipRequestDto)
        {
            await _client.PostAsJsonAsync<CreateExitSlipRequestDto>("ExitSlip", createExitSlipRequestDto);
        }

        async Task IExitSlipClient.DeleteExitSlip(Guid id)
        {
            await _client.DeleteAsync($"/ExitSlip/{id}");
        }

        async Task<List<ExitSlipResultDto>> IExitSlipClient.GetAllExitSlips()
        {
            return await _client.GetFromJsonAsync<List<ExitSlipResultDto>>("/ExitSlip");
        }
        
        async Task<ExitSlipResultDto> IExitSlipClient.GetExitSlip(Guid? id) 
        {
            return await _client.GetFromJsonAsync<ExitSlipResultDto>($"/ExitSlip/{id}");

            // getResponse.EnsureSuccessStatusCode();
        }

       

        async Task<ReturnModel> IExitSlipClient.UpdateExitSlip(ExitSlipViewModel exitSlipViewModel)
        {
            var updateExitSlipRequestDto = new UpdateExitSlipRequestDto { Id = exitSlipViewModel.Id, IsPublished = exitSlipViewModel.IsPublished, LessonId = exitSlipViewModel.LessonId, QuestionList = exitSlipViewModel.QuestionList, RowVersion = exitSlipViewModel.RowVersion };

            var postResponse = await _client.PutAsJsonAsync<UpdateExitSlipRequestDto>("ExitSlip", updateExitSlipRequestDto);

            //  postResponse.EnsureSuccessStatusCode();

            var returnModel = new ReturnModel();

            returnModel.JsonResponse = await postResponse.Content.ReadAsStringAsync();

            returnModel.MakeReadonly = await _client.GetFromJsonAsync<bool>($"ExitSlip/MakeReadonly?publishStatus={updateExitSlipRequestDto.IsPublished}");

            return returnModel;
        }
    }
}

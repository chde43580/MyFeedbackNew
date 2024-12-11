using MyFeedback.Application.Query.QueryDto;
using MyFeedback.Login.Pages.Model;
using Shared;

namespace MyFeedback.Login.TypedClients.Interfaces
{
    public interface IExitSlipClient
    {
        public Task<ExitSlipResultDto> GetExitSlip(Guid? id);

        public Task<List<ExitSlipResultDto>> GetAllExitSlips();

        public Task CreateExitSlip(CreateExitSlipRequestDto createExitSlipRequestDto);

        public Task<ReturnModel> UpdateExitSlip(ExitSlipViewModel exitSlipDto);

        public Task DeleteExitSlip(Guid id);
    }
}

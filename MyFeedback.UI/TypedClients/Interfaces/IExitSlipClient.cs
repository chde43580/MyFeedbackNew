using MyFeedback.UI.Components.Pages.Model;
using Shared;

namespace MyFeedback.UI.TypedClients.Interfaces
{
    public interface IExitSlipClient
    {
        public Task<ExitSlipResultDto> GetExitSlip(Guid? id);

        public Task<List<ExitSlipResultDto>> GetAllExitSlips();

        public Task CreateExitSlip(CreateExitSlipRequestDto createExitSlipRequestDto);

        public Task<ReturnModel> UpdateExitSlip(ExitSlipViewModel exitSlipViewModel);

        public Task DeleteExitSlip(Guid id);
    }
}

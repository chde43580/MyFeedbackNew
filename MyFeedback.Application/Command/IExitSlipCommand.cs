using MyFeedback.Application.Command.CommandDto.ExitSlip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command
{
    public interface IExitSlipCommand
    {
        void CreateExitSlip(CreateExitSlipDto createExitSlipDto);

        string UpdateExitSlip(UpdateExitSlipDto updateExitSlipDto);

        void DeleteExitSlip(DeleteExitSlipDto deleteExitSlipDto);
    }
}

using MyFeedback.Application.Command.CommandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Repositories
{
    public interface IExitSlipRepo
    {
        ExitSlip GetExitSlip(Guid id);

        void AddExitSlip(ExitSlip exitSlip);

        void UpdateExitSlip(ExitSlip exitSlip, byte[] rowVersion);

        void DeleteExitSlip(ExitSlip exitSlip, byte[] rowVersion);
    }
}

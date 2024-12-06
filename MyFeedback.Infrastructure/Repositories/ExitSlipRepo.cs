using Microsoft.EntityFrameworkCore;
using MyFeedback.Application.Command.CommandDto.ExitSlip;
using MyFeedback.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Infrastructure.Repositories
{
    public class ExitSlipRepo : IExitSlipRepo
    {
        private readonly MyFeedbackContext _dbContext;

        public ExitSlipRepo(MyFeedbackContext dbContext)
        {
            this._dbContext = dbContext;
        }

        void IExitSlipRepo.AddExitSlip(ExitSlip exitSlip)
        {
            _dbContext.ExitSlips.Add(exitSlip);

            _dbContext.SaveChanges();
        }

        void IExitSlipRepo.DeleteExitSlip(ExitSlip exitSlip, byte[] rowVersion)
        {
            _dbContext.Entry(exitSlip).Property(nameof(exitSlip.RowVersion)).OriginalValue = rowVersion;

            exitSlip = _dbContext.ExitSlips.Include(e => e.QuestionList).FirstOrDefault(e => e.Id == exitSlip.Id);
               

            _dbContext.ExitSlips.Remove(exitSlip);

            _dbContext.SaveChanges();
        }

        ExitSlip IExitSlipRepo.GetExitSlip(Guid id)
        {
            return _dbContext.ExitSlips.Include(es => es.QuestionList).Single(b => b.Id == id);
        }

        void IExitSlipRepo.UpdateExitSlip(ExitSlip exitSlip, byte[] rowVersion)
        {
            _dbContext.Entry(exitSlip).Property(nameof(exitSlip.RowVersion)).OriginalValue = rowVersion;

            _dbContext.ExitSlips.Update(exitSlip); // Virker det her??

            _dbContext.SaveChanges();
        }
    }
}

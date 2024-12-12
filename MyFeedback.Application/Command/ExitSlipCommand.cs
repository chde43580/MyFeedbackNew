using MyFeedback.Application.Command.CommandDto.ExitSlip;
using MyFeedback.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFeedback.Domain.Entities;

namespace MyFeedback.Application.Command
{
    public class ExitSlipCommand : IExitSlipCommand
    {
        private readonly IExitSlipRepo _exitSlipRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ExitSlipCommand(IExitSlipRepo exitSlipRepo, IUnitOfWork unitOfWork)
        {
            this._exitSlipRepo = exitSlipRepo;
            this._unitOfWork = unitOfWork;
        }


        void IExitSlipCommand.CreateExitSlip(CreateExitSlipDto createExitSlipDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);

                var newExitSlip = ExitSlip.Create(createExitSlipDto.LessonId, new List<Question>(), createExitSlipDto.IsPublished);

                foreach (var questionDto in createExitSlipDto.QuestionList)
                {
                    var tempQuestion = new Question(questionDto.QuestionNumber, questionDto.QuestionText);

                    newExitSlip.QuestionList.Add(tempQuestion);
                }

                

                _exitSlipRepo.AddExitSlip(newExitSlip);

                _unitOfWork.Commit();
            }
            catch (Exception ex) 
            {
                _unitOfWork.Rollback();

                throw(ex);

            }
            
        }

        string IExitSlipCommand.UpdateExitSlip(UpdateExitSlipDto updateExitSlipDto)
        {

            try
            {
                _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);

                var oldExitSlip = _exitSlipRepo.GetExitSlip(updateExitSlipDto.Id);

                foreach (var question in updateExitSlipDto.QuestionList)
                {
                    if (oldExitSlip.QuestionList.Any())
                    {
                        oldExitSlip.QuestionList.Clear();
                    }

                    oldExitSlip.QuestionList.Add(new Question(question.QuestionNumber, question.QuestionText));
                }

                oldExitSlip.IsPublished = updateExitSlipDto.IsPublished;
                oldExitSlip.LessonId = updateExitSlipDto.LessonId;

                bool textTooLong = false;

                foreach (var question in oldExitSlip.QuestionList)
                {
                   if (question.AssureTextNotTooLong() != "")
                    {
                        return question.AssureTextNotTooLong();
                    }
                }

           

                _exitSlipRepo.UpdateExitSlip(oldExitSlip, updateExitSlipDto.RowVersion);

                _unitOfWork.Commit();

                return "Update successful";
            }

            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                return ex.Message;

            }
        }

        void IExitSlipCommand.DeleteExitSlip(DeleteExitSlipDto deleteExitSlipDto)
        {
           var exitSlipToDelete = _exitSlipRepo.GetExitSlip(deleteExitSlipDto.Id);

            _exitSlipRepo.DeleteExitSlip(exitSlipToDelete, deleteExitSlipDto.RowVersion);
        }


    }
}

using MyFeedback.Application.Command.CommandDto.Answer;
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
    public class AnswerCommand : IAnswerCommand
    {
        private readonly IAnswerRepo _answerRepo;
        private readonly IUnitOfWork _unitOfWork;

        public AnswerCommand(IAnswerRepo answerRepo, IUnitOfWork unitOfWork)
        {
            this._answerRepo = answerRepo;
            this._unitOfWork = unitOfWork;
        }


        void IAnswerCommand.CreateAnswer(CreateAnswerDto createAnswerDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);

                var newAnswer = Answer.Create(createAnswerDto.QuestionId, createAnswerDto.IdentityUserId, createAnswerDto.AnswerText);

                _answerRepo.AddAnswer(newAnswer);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                throw (ex);
            }
        }

        void IAnswerCommand.UpdateAnswer(UpdateAnswerDto updateAnswerDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);

                Answer oldAnswer = _answerRepo.GetAnswer(updateAnswerDto.Id);

                oldAnswer.AnswerText = updateAnswerDto.AnswerText;

                _answerRepo.UpdateAnswer(oldAnswer, updateAnswerDto.RowVersion); // Har DTO'en her fået et RowVersion?

                _unitOfWork.Commit();
            }

            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                throw (ex);

            }
        }


    }
}

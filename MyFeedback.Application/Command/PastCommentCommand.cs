using MyFeedback.Application.Command.CommandDto.ExitSlip;
using MyFeedback.Application.Command.CommandDto.PastComment;
using MyFeedback.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFeedback.Domain.Entities;

namespace MyFeedback.Application.Command
{
    public class PastCommentCommand : IPastCommentCommand
    {
        private readonly IPastCommentRepo _pastCommentRepo;
        private readonly IUnitOfWork _unitOfWork;

        public PastCommentCommand(IUnitOfWork unitOfWork, IPastCommentRepo pastCommentRepo)
        {
            _pastCommentRepo = pastCommentRepo;
            _unitOfWork = unitOfWork;
        }

        void IPastCommentCommand.CreatePastComment(CreatePastCommentDto createPastCommentDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);
                PastComment newPastComment= PastComment.Create(createPastCommentDto.CommentText, createPastCommentDto.CommentDate);
                
                _pastCommentRepo.AddPastComment(newPastComment);

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

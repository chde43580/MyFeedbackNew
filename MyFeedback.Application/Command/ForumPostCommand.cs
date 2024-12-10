using MyFeedback.Application.Command.CommandDto.ExitSlip;
using MyFeedback.Application.Command.CommandDto.ForumPost;
using MyFeedback.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFeedback.Domain.Entities;

namespace MyFeedback.Application.Command
{
    public class ForumPostCommand : IForumPostCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IForumPostRepo _forumPostRepo;

        public ForumPostCommand(IUnitOfWork unitOfWork, IForumPostRepo forumPostRepo)
        {
            this._unitOfWork = unitOfWork;
            this._forumPostRepo = forumPostRepo;
        }

        void IForumPostCommand.CreateForumPost(CreateForumPostDto createForumPostDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);

                ForumPost newForumPost = ForumPost.Create(createForumPostDto.ProblemText, createForumPostDto.SolutionText);

                _forumPostRepo.AddForumPost(newForumPost);

                _unitOfWork.Commit();
            }

            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                throw (ex);
            }
        }

        void IForumPostCommand.DeleteForumPost(DeleteForumPostDto deleteForumPostDto)
        {
            // Vi har bevidst her ikke implementeret nogen uow-funktionalitet; idet dette blot er en Delete-operation

            ForumPost forumPostToDelete = _forumPostRepo.GetForumPost(deleteForumPostDto.Id);

            _forumPostRepo.DeleteForumPost(forumPostToDelete, deleteForumPostDto.RowVersion);
        }
    }
}

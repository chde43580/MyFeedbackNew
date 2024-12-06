using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class Answer : DomainEntity
    {
        public Guid QuestionId { get; protected set; }
        public Guid IdentityUserId { get; protected set; }
        public string AnswerText { get; set; }

        //Nul-constructor
        //public Answer()
        //{
            
        //}

        public Answer(Guid questionId, Guid identityUserId, string answerText)
        {
            this.QuestionId = questionId;
            this.IdentityUserId = identityUserId;
            this.AnswerText = answerText;
        }

        public static Answer Create(Guid questionId, Guid identityUserId, string answerText)
        {
            Answer newAnswer = new Answer(questionId, identityUserId, answerText);

            return newAnswer;
        }

        public void Update(Guid questionId, Guid identityUserId, string answerText)
        {
            this.QuestionId = questionId;
            this.IdentityUserId = identityUserId;
            this.AnswerText = answerText;
        }
    }


}

using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class ExitSlip : DomainEntity
    {
        public Guid LessonId { get; set; } // Should maybe be protected setting?
        public List<Question> QuestionList { get; set; } // Same as above

        public bool IsPublished { get; set; }

        public ExitSlip() 
        { 
        }

        public ExitSlip(Guid lessonId, List<Question> questionList, bool isPublished)
        {
            this.LessonId = lessonId;
            this.QuestionList = questionList;
            this.IsPublished = isPublished;
        }

        public static ExitSlip Create(Guid lessonId, List<Question> questionList, bool isPublished)
        {
            ExitSlip newExitSlip = new ExitSlip(lessonId, questionList, isPublished);

            return newExitSlip;
        }

        public string Update(Guid lessonId, List<Question> questionList, bool isPublished)
        {
            
            if (AssureUpdateImpossibleIfPublished(isPublished))
            {
                this.LessonId = lessonId;
                this.QuestionList = questionList;
                this.IsPublished = isPublished;

                return "Update successful";
            }
            else
            { 

                return "Update not succesful; can't update when slip already published!";
            }



         
        }

        public void AssureQuestionListIsNotNull()
        {
            if (QuestionList == null)
            {
                QuestionList = new List<Question>();
            }
        }

        public bool AssureUpdateImpossibleIfPublished(bool isPublished)
        {
            if (isPublished)
            {
             
                return true;
            }
            else
            {
                return false;
            }
        }
      
    }
}

using MyFeedback.Application.Command.CommandDto.Answer;
using MyFeedback.Application.Command.CommandDto.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command
{
    public interface IAnswerCommand
    {
        void CreateAnswer(CreateAnswerDto createAnswerDto);

        void UpdateAnswer(UpdateAnswerDto updateAnswerDto);
    }
}

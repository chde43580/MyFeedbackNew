using Microsoft.Extensions.DependencyInjection;
using MyFeedback.Application.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IExitSlipCommand, ExitSlipCommand>();
            services.AddScoped<IForumPostCommand, ForumPostCommand>();
            services.AddScoped<ICommentCommand, CommentCommand>();
            services.AddScoped<IAnswerCommand, AnswerCommand>();
            services.AddScoped<IPastCommentCommand, PastCommentCommand>();
          
            return services;
        }
    }
}

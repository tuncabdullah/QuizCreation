using Microsoft.Extensions.DependencyInjection;
using QuizCreation.DataAccess.Abstract;
using QuizCreation.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreation.Business.IoC
{
   public static class Dependencies
    {
        public static IServiceCollection addDependencies(this IServiceCollection services)
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            return services;
        }
    }
}

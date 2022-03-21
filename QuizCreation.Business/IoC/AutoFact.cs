using Autofac;
using QuizCreation.Business.Abstract;
using QuizCreation.Business.Concrete;
using QuizCreation.DataAccess.Abstract;
using QuizCreation.DataAccess.Concrete;
namespace QuizCreation.Business.IoC
{
    public class AutoFact : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<QuestionService>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<ExamService>().As<IExamService>().SingleInstance();
            builder.RegisterType<QuestionRepository>().As<IQuestionRepository>().SingleInstance();
            builder.RegisterType<ExamRepository>().As<IExamRepository>().SingleInstance();
        }

    }
} 

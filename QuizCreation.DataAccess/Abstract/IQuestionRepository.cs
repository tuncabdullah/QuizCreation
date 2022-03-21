using QuizCreation.Core.Data.Abstract;
using QuizCreation.Entities.Concrete;

namespace QuizCreation.DataAccess.Abstract
{
    public interface IQuestionRepository : IEntityRepository<Question>
    {
    }
}

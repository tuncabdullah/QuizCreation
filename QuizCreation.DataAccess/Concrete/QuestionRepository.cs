using QuizCreation.DataAccess.Abstract;
using QuizCreation.DataAccess.Concrete.EntityFramework.Contexts;
using QuizCreation.Entities.Concrete;
using QuizCreation.Core.Data.Concrete;
using Microsoft.EntityFrameworkCore;

namespace QuizCreation.DataAccess.Concrete
{
    public class QuestionRepository : EfEntityRepositoryBase<Question, QuizCreationDbContext>, IQuestionRepository
    {
        public QuestionRepository(QuizCreationDbContext context) : base(context)
        {
        }
        public QuizCreationDbContext? QuizCreationDbContext { get { return _context as QuizCreationDbContext; } }
    }
}

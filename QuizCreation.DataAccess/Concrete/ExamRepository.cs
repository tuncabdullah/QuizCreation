using Microsoft.EntityFrameworkCore;
using QuizCreation.Core.Data.Abstract;
using QuizCreation.Core.Data.Concrete;
using QuizCreation.DataAccess.Abstract;
using QuizCreation.DataAccess.Concrete.EntityFramework.Contexts;
using QuizCreation.Entities.Concrete;

namespace QuizCreation.DataAccess.Concrete
{
    public class ExamRepository : EfEntityRepositoryBase<Exam, QuizCreationDbContext>, IExamRepository
    {
        public ExamRepository(QuizCreationDbContext context) : base(context)
        {
        }
        public QuizCreationDbContext? QuizCreationDbContext { get { return _context as QuizCreationDbContext; } }
    }
}

using QuizCreation.Core.Utilities.Results;
using QuizCreation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreation.Business.Abstract
{
   
    public interface IQuestionService
    {
       
        IDataResult<Question> GetById(int id);
        IList<Question> GetAll();
        Task<IResult> AddAsync(Question question);
        Task<IResult> AddRangeAsync(IEnumerable<Question> questions);
        IResult Remove(Question question);
        IResult RemoveRange(IEnumerable<Question> questions);
        Task<bool> SaveChangesAsync();
        IList<Question> GetAllForExam(Exam exam);
    }
}

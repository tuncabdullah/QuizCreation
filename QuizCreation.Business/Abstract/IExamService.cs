using QuizCreation.Core.Utilities.Results;
using QuizCreation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreation.Business.Abstract
{
    public interface IExamService
    {
        IDataResult<Exam> GetById(int id);
        IList<Exam> GetAll();
        Task<IResult> AddAsync(Exam exam);
        Task<IResult> AddRangeAsync(IEnumerable<Exam> exams);
        IResult Remove(Exam exam);
        IResult RemoveRange(IEnumerable<Exam> exams); 
        Task<bool> SaveChangesAsync();

    }
}

using Microsoft.Extensions.Logging;
using QuizCreation.Business.Abstract;
using QuizCreation.Business.Contanst;
using QuizCreation.Core.Utilities.Results;
using QuizCreation.DataAccess.Abstract;
using QuizCreation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreation.Business.Concrete
{
    

    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly ILogger<ExamService> _logger;

        public ExamService(IExamRepository examRepository, ILogger<ExamService> logger)
        {
            _examRepository = examRepository;
            _logger = logger;
        }

        public async Task<IResult> AddAsync(Exam exam)
        {
            try
            {
                await _examRepository.AddAsync(exam);
                return new SuccessResult(Messages.Added);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new ErrorResult(e.Message);
            }
        }

        public async Task<IResult> AddRangeAsync(IEnumerable<Exam> exams)
        {
            try
            {
                await _examRepository.AddRangeAsync(exams);
                return new SuccessResult(Messages.Added);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new ErrorResult(e.Message);
            }
        }

        public IList<Exam> GetAll()
        {
            return (IList<Exam>)_examRepository.GetAll();
        }

        public IDataResult<Exam> GetById(int id)
        {
            return new SuccessDataResult<Exam>(_examRepository.GetById(x=>x.Id==id));
        }

        public IResult Remove(Exam exam)
        {
            try
            {
                _examRepository.Remove(exam);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new ErrorResult(e.Message);
            }
        }

        public IResult RemoveRange(IEnumerable<Exam> exams)
        {
            try
            {
                _examRepository.RemoveRange(exams);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new ErrorResult(e.Message);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                int  res=await _examRepository.SaveChangesAsync();
                if(res>0)
                  return  true;
                else
                    return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
    }
}

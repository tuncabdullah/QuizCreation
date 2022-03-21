using Microsoft.Extensions.Logging;
using QuizCreation.Business.Abstract;
using QuizCreation.Business.Contanst;
using QuizCreation.Core.Utilities.Results;
using QuizCreation.DataAccess.Abstract;
using QuizCreation.Entities.Concrete;

namespace QuizCreation.Business.Concrete
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
      private readonly ILogger<QuestionService> _logger;

        public QuestionService(IQuestionRepository questionRepository, ILogger<QuestionService> logger)
        {
            _questionRepository = questionRepository;
            _logger = logger;
        }

        public async Task<IResult> AddAsync(Question question)
        {
            try
            {
                await _questionRepository.AddAsync(question);
                return new SuccessResult(Messages.Added);
            }
            catch (Exception e)
          {
                _logger.LogError(e.Message);
                return new ErrorResult(e.Message);
            }
        }

        public async Task<IResult> AddRangeAsync(IEnumerable<Question> questions)
        {
            try
            {
                await _questionRepository.AddRangeAsync(questions);
                return new SuccessResult(Messages.Added);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new ErrorResult(e.Message);
            }
        }

        public IList<Question> GetAll()
        {
            return (IList<Question>)_questionRepository.GetAll();
        }

        public IDataResult<Question> GetById(int id)
        {
            return new SuccessDataResult<Question>(_questionRepository.GetById(x=>x.Id==id));
        }

        public IResult Remove(Question question)
        {
            try
            {
                _questionRepository.Remove(question);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new ErrorResult(e.Message);
            }
        }

        public IResult RemoveRange(IEnumerable<Question> questions)
        {
            try
            {
                _questionRepository.RemoveRange(questions);
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
                int res = await _questionRepository.SaveChangesAsync();
                if (res > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
        public IList<Question> GetAllForExam(Exam exam)
        {
            return (IList<Question>)_questionRepository.GetAll(x=>x.Exam== exam);
        }
    }
}

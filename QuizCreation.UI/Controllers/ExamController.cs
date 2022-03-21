using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizCreation.Business.Abstract;
using QuizCreation.Entities.Concrete;
using QuizCreation.Entities.DTO.Exam;
using QuizCreation.UI.ExternalServices;

namespace QuizCreation.UI.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {

        private readonly IQuestionService _questionService;
        private readonly IExamService _examService;
        private readonly ILogger<HomeController> _logger;

        public ExamController(
            IExamService examService,
          IQuestionService questionService,
            ILogger<HomeController> logger)
        {
            _questionService = questionService;
            _examService = examService;
            _logger = logger;
        }
        GetArticle getArticle = new GetArticle();
        [HttpGet]
        [AllowAnonymous]
        public IActionResult StartExam()
        {
            var exam = _examService.GetAll().FirstOrDefault();
            var model = exam.Adapt<ExamViewModel>();
            var questions = _questionService.GetAllForExam(exam);
            model.QuestionList = questions.Adapt<List<QuestionViewModel>>();
            return View(model);
        }
        public IActionResult Index()
        { 
          
            return View();
        }
      
        [HttpGet]
        public IActionResult ListExam()
        {
            var data = _examService.GetAll();
           var model= data.Adapt<List<ExamListViewModel>>();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateExam()
        {
            ViewData["ArticleList"] = getArticle.GetList(5);
            return View();
        }
        [HttpPost]
        public IActionResult CreateExam(ExamViewModel model)
        {
           
            try
            {
                Exam exam = new()
                {
                    CreateDate = DateTime.Now,
                    Description = model.Description,
                    RegistrationNumber = model.Id,
                    Title = model.Title,
                };
                _ = _examService.AddAsync(exam);
                List<Question> questions = new();
                foreach (var q in model.QuestionList)
                {
                    Question question = new()
                    {
                        OptionA = q.OptionA,
                        OptionB = q.OptionB,
                        OptionC = q.OptionC,
                        OptionD = q.OptionD,
                        Exam = exam,
                        QuestionText = q.QuestionText,
                        TrueOption = q.TrueOption
                    };

                    questions.Add(question);
                }
                _ = _questionService.AddRangeAsync(questions);
                _ = _questionService.SaveChangesAsync();
                ViewBag.Mesaj = "Sınav Başarı ile Kayıt Edildi";
                return RedirectToAction("CreateExam", "Exam", 0);
            }
            catch (Exception ex)
            {
                ViewData["ArticleList"] = getArticle.GetList(5);
                ViewBag.ErorMesage = "Kayıt Başarısız";
                return View(model);
            }
          
            
        }
        [HttpPost]
        public JsonResult GetDescription(string id)
        {
            var article = getArticle.GetById(id);
            return Json(article);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetQuestionList(int Id)
        {
            var exam = _examService.GetById(Id);
            var model = exam.Data.Questions.Adapt<List<QuestionListViewModel>>();
            return Json(model);
        }
        [HttpGet]
        public IActionResult DeleteExam(int Id)
        {
            var exam = _examService.GetById(Id);
            var questions = _questionService.GetAllForExam(exam.Data);
            _ = _questionService.RemoveRange(questions);
            _ = _examService.Remove(exam.Data);
            _ = _questionService.SaveChangesAsync();
            return RedirectToAction("ListExam");
        }
    }
}

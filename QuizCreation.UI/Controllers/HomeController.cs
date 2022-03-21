using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizCreation.Business.Abstract;
using QuizCreation.Business.Concrete;
using QuizCreation.Entities.Concrete;
using QuizCreation.Entities.Concrete.Identity;
using QuizCreation.UI.Models;
using System.Diagnostics;

namespace QuizCreation.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IQuestionService _questionService;
        private readonly IExamService _examService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IExamService examService,
            UserManager<ApplicationUser> userManager,
          IQuestionService questionService,
            ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _questionService = questionService;
            _examService = examService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var exam = new Exam() { CreateDate = DateTime.Now, Title = "Yazı Başlığı", Description = "Yazı açıklaması" };

            //    var data = _examService.AddAsync(exam);
            //    List<Question> questions = new()
            //    {
            //        new Question() { OptionA = "cevap a", OptionB = "cevap b", OptionC = "cevap c", OptionD = "cevap d", TrueOption = "a", QuestionText = " soru?", Exam = exam },
            //        new Question() { OptionA = "cevap a2", OptionB = "cevap b2", OptionC = "cevap c2", OptionD = "cevap d2", TrueOption = "a2", QuestionText = " soru?2", Exam = exam },
            //        new Question() { OptionA = "cevap a3", OptionB = "cevap b3", OptionC = "cevap c3", OptionD = "cevap d3", TrueOption = "a3", QuestionText = " soru?3", Exam = exam },
            //        new Question() { OptionA = "cevap a4", OptionB = "cevap b4", OptionC = "cevap c4", OptionD = "cevap d4", TrueOption = "a4", QuestionText = " soru?4", Exam = exam },
            //        new Question() { OptionA = "cevap a5", OptionB = "cevap b5", OptionC = "cevap c5", OptionD = "cevap d5", TrueOption = "a5", QuestionText = " soru?5", Exam = exam },

            //    };
            //    var rengedata = _questionService.AddRangeAsync(questions);

            //    var dataaaaahjhj = _examService.GetById(1);
            //    var dataaaaaghghg= _examService.Remove(dataaaaahjhj.Data);
            //    var aas= _questionService.GetAllForExam(dataaaaahjhj.Data);
            //    var asada = _questionService.RemoveRange(aas);
            //    var dataaaaa = _questionService.SaveChangesAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
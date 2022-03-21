using QuizCreation.Entities.Concrete.Common;
namespace QuizCreation.Entities.Concrete
{
    public class Question : BaseEntity
    {
        public string? QuestionText { get; set; }
        public string? OptionA { get; set; }
        public string? OptionB { get; set; }
        public string? OptionC { get; set; }
        public string? OptionD { get; set; }
        public string? TrueOption { get; set; }
        public Exam? Exam { get; set; }
    }
}

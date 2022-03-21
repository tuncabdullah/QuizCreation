namespace QuizCreation.Entities.DTO.Exam
{
    public class ExamViewModel
    {
        public ExamViewModel()
        {
            QuestionList = new List<QuestionViewModel>();
        }
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<QuestionViewModel> QuestionList { get; set; }
    }
    public class QuestionViewModel
    {
        public string? Id { get; set; }
        public string? QuestionText { get; set; }
        public string? OptionA { get; set; }
        public string? OptionB { get; set; }
        public string? OptionC { get; set; }
        public string? OptionD { get; set; }
        public string? TrueOption { get; set; }
    }
}

using QuizCreation.Entities.Concrete.Common;
namespace QuizCreation.Entities.Concrete
{
    public class Exam : BaseEntity
    {
        public Exam()
        {
            Questions=new List<Question>();
        }
        public string? RegistrationNumber { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<Question>? Questions { get; set; }
    }
}

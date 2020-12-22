using Ch11_QuizModels;

namespace Ch11_QuizWebApp.Models
{
    public class QuestionViewModel
    {
        public Question Question { get; set; }
        public string Answer { get; set; }
        public int Number { get; set; }
        public int Total { get; set; }
    }
}

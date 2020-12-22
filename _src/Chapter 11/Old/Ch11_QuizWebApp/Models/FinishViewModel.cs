using Ch11_QuizModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11_QuizWebApp.Models
{
    public class FinishViewModel
    {
        public Quiz Quiz { get; set; }
        public Dictionary<int, string> Answers { get; set; }
        public int CorrectAnswers { get; set; }
    }
}

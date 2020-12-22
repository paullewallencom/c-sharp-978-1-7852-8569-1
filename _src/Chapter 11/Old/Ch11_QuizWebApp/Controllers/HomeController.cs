using Ch11_QuizModels;
using Ch11_QuizRepository;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Ch11_QuizWebApp.Controllers
{
    public class HomeController : Controller
    {
        private QuizContext db;
        public HomeController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuizContext>();
            optionsBuilder.UseInMemoryDatabase();
            db = new QuizContext(optionsBuilder.Options);
        }
        public ActionResult Index()
        {
            var model = db.Quizzes.ToList();
            return View(model);
        }
        public ActionResult TakeQuiz(string id)
        {
            Quiz model = db.Quizzes.Where(q => q.QuizID == id).Include(q => q.Questions).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound($"A quiz with the ID of {id} was not found.");
            }
            Session["quiz"] = model;
            Session["answers"] = new Dictionary<int, string>();
            return View(model);
        }
        public ActionResult Question(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound("You must pass an id of a question.");
            }
            Quiz quiz = (Session["quiz"] as Quiz);
            var answers = (Session["answers"] as Dictionary<int, string>);
            var model = new Models.QuestionViewModel
            {
                Question = quiz.Questions.Skip(id.Value - 1).Take(1).FirstOrDefault(),
                Answer =  answers.ContainsKey(id.Value - 1) ? answers[id.Value - 1] : string.Empty,
                Number = id.Value,
                Total = quiz.Questions.Count()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Question(int? id, string submit, string answer)
        {
            if (!id.HasValue)
            {
                return HttpNotFound("You must pass an id of a question.");
            }
            var answers = (Session["answers"] as Dictionary<int, string>);
            answers[id.Value - 1] = answer;
            if (submit == "Previous")
            {
                id--;
            }
            else if (submit == "Next")
            {
                id++;
            }
            else if (submit == "Finish")
            {
                return RedirectToAction("Finish");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Question", new { id = id });
        }
        public ActionResult Finish()
        {
            Quiz quiz = (Session["quiz"] as Quiz);
            var model = new Models.FinishViewModel
            {
                Quiz = quiz,
                Answers = (Session["answers"] as Dictionary<int, string>)
            };
            for (int i = 0; i < model.Quiz.Questions.Count; i++)
            {
                if (model.Quiz.Questions.ToList()[i].CorrectAnswer == model.Answers[i]) model.CorrectAnswers++;
            }
            return View(model);
        }
    }
}

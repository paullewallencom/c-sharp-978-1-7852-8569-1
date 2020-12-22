using Ch11_QuizModels;
using Ch11_QuizRepository;
using Microsoft.Data.Entity;
namespace Ch11_QuizWebApp.App_Start
{
    public class QuizConfig
    {
        public static void AddSampleQuizzes()
        {
            // Configure the in-memory database option
            var optionsBuilder = new DbContextOptionsBuilder<QuizContext>();
            optionsBuilder.UseInMemoryDatabase();
            // Note: in future we could change the statement above to use 
            // a different database such as SQL Database in Azure without
            // needing to change any other code.

            using (var context = new QuizContext(optionsBuilder.Options))
            {
                // define a sample C# and OOP quiz
                var csharpQuiz = new Quiz
                {
                    QuizID = "CSHARP",
                    Title = "C# and OOP",
                    Description = "Questions about the C# language and object-oriented programming."
                };
                csharpQuiz.Questions.Add(new Question
                {
                    Quiz = csharpQuiz,
                    QuestionText = "Which modifier would you apply to a type's member to allow only code within that type access to it?",
                    AnswerA = "internal",
                    AnswerB = "protected",
                    AnswerC = "private",
                    AnswerD = "public",
                    CorrectAnswer = "C"
                });
                csharpQuiz.Questions.Add(new Question
                {
                    Quiz = csharpQuiz,
                    QuestionText = "Which keyword would you apply to a type's field to prevent its value from changing after an instance of the type has been created?",
                    AnswerA = "const",
                    AnswerB = "readonly",
                    AnswerC = "static",
                    AnswerD = "protected",
                    CorrectAnswer = "B"
                });

                var fileioQuiz = new Quiz
                {
                    QuizID = "FILEIO",
                    Title = "File I/O",
                    Description = "Questions about the file input/output features of the .NET Framework including serialization."
                };
                fileioQuiz.Questions.Add(new Question
                {
                    Quiz = fileioQuiz,
                    QuestionText = "Which are the requirements for a type to be serialized by using the BinaryFormatter?",
                    AnswerA = "Apply [Serializable] to the type.",
                    AnswerB = "Apply [Serializable] to the type and make all fields public.",
                    AnswerC = "Ensure the type has a public parameterless contructor.",
                    AnswerD = "Ensure the type has a public parameterless contructor and make all fields public.",
                    CorrectAnswer = "A"
                });

                var aspnetQuiz = new Quiz
                {
                    QuizID = "ASPNET",
                    Title = "ASP.NET Web Applications and Services",
                    Description = "Questions about building MVC web applications and Web API services by using ASP.NET."
                };
                aspnetQuiz.Questions.Add(new Question
                {
                    Quiz = aspnetQuiz,
                    QuestionText = "Which of the following is NOT a requirement for an MVC controller?",
                    AnswerA = "The class must implement the IController interface.",
                    AnswerB = "The class must inherit from the Controller class.",
                    AnswerC = "The class must be public.",
                    AnswerD = "The class's action methods must NOT use generic types.",
                    CorrectAnswer = "B"
                });

                // mark the three quiz and question entities as Added and then save them to the data store
                context.Add(csharpQuiz, GraphBehavior.IncludeDependents);
                context.Add(fileioQuiz, GraphBehavior.IncludeDependents);
                context.Add(aspnetQuiz, GraphBehavior.IncludeDependents);
                context.SaveChanges();
            }
        }
    }
}

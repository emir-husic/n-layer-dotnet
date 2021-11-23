using System.Collections.Generic;
using ListRandomizer;
using log4net;
using Quiz.Common;
using Quiz.Service.Interfaces;

namespace Quiz.Services
{
    public class CategoryExamService : ICategoryExamService
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly ILog _logger;

        public CategoryExamService(IQuestionService questionService, IAnswerService answerService)
        {
            _questionService = questionService;
            _answerService = answerService;
            _logger = LogManager.GetLogger("CategoryExamService");
        }

        private IEnumerable<Answer> AddCorrectAnswerProperty(IEnumerable<Answer> answers, int correctAnswerId)
        {
            foreach (var answer in answers)
            {
                if(answer.Id == correctAnswerId)
                {
                    answer.Correct = true;
                    return answers;
                }
            }
            return answers;
        }

        private IEnumerable<CategoryExam> GetAnswersToQuestions(IEnumerable<Question> questions)
        {
            var categoryQuestions = new List<CategoryExam>();
            foreach (var question in questions)
            {
                var answers = _answerService.GetAnswersToQuestion(question.Id);
                var categoryExam = new CategoryExam
                {
                    Id = question.Id,
                    CategoryId = question.CategoryId,
                    Text = question.Text,
                    ImageUrl = question.ImageUrl,
                    Explanation = question.Explanation,
                    Answers = answers,
                    CorrectAnswerId = question.CorrectAnswerId

                };
                categoryQuestions.Add(categoryExam);

            }

            return categoryQuestions;
        }

        private void AddCorrectPropertyToQuestions(ref IEnumerable<CategoryExam> questions)
        {
            foreach(var question in questions)
            {
                var newAnswers = AddCorrectAnswerProperty(question.Answers, question.CorrectAnswerId);
                question.Answers = newAnswers;
            }
        }

        private IEnumerable<CategoryExam> ShuffleQAndAOrder(IEnumerable<CategoryExam> questions)
        {
            
            foreach (var question in questions)
            {
                List<Answer> tempAnswers = (List < Answer >) question.Answers;
                ListExtension.Shuffle(tempAnswers);
                question.Answers = tempAnswers;
            }
            List<CategoryExam> shuffledQuestions = (List<CategoryExam>)questions;
            ListExtension.Shuffle(shuffledQuestions);
            return questions;

        }

        public IEnumerable<CategoryExam> GetCategoryExam(int categoryId)
        {
            _logger.Debug($"Calling GetCategoryExam with categoryId: {categoryId}");

            var questions = _questionService.GetCategoryQuestions(categoryId);
            _logger.Debug($"Retrieved {questions}");

            var categoryQuestions = GetAnswersToQuestions(questions);
            AddCorrectPropertyToQuestions(ref categoryQuestions);
            var shuffledExam = ShuffleQAndAOrder(categoryQuestions);
            return shuffledExam;
        }
    }
}

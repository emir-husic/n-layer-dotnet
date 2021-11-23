using System.Collections.Generic;
using Moq;
using Quiz.Common;
using Quiz.Services;
using Xunit;
using System.Linq;
using Quiz.Service.Interfaces;

namespace Quiz.Tests
{
    public class CategoryExamServiceTest
    {
        [Fact]
        public void GetCategoryQuestions_ShouldContainOneAnswerWithTheCorrectResultSetToTrue_WhenCategoryIdIsSupplied()
        {
            var categoryId = 2;
            var questionId = 1;

            var correctAnswerId = 3;

            var questionService = new Mock<IQuestionService>();

            var mockCategoryQuestions = new List<Question>()
            {
                new Question()
                {
                    Id = questionId,
                    CategoryId = categoryId,
                    CorrectAnswerId = correctAnswerId,
                    Explanation = "The right answer is always right.",
                    Text = "What is the correct answer?"
                }
            };
            questionService.Setup(x => x.GetCategoryQuestions(categoryId)).Returns(mockCategoryQuestions);

            var answerService = new Mock<IAnswerService>();
            var mockAnswers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    QuestionId = questionId,
                    Text = "Left"
                },
                new Answer()
                {
                    Id = 2,
                    QuestionId = questionId,
                    Text = "Top"
                },
                new Answer()
                {
                    Id = correctAnswerId,
                    QuestionId = questionId,
                    Text = "Right",
                    Correct = true
                }
            };
            answerService.Setup(x => x.GetAnswersToQuestion(questionId)).Returns(mockAnswers);

            var sut = new CategoryExamService(questionService.Object, answerService.Object);

            var categoryExam = sut.GetCategoryExam(categoryId);

            var answer = categoryExam.Where(x => x.Id == questionId).First().Answers.Where(x => x.Id == correctAnswerId).FirstOrDefault();

            Assert.True(answer.Correct);
        }

        [Fact]
        public void GetCategoryQuestions_ShouldContainExaclyOneCorrectAnswer_WhenCategoryIdIsSupplied()
        {
            var categoryId = 2;
            var questionId = 1;

            var questionService = new Mock<IQuestionService>();
            
            var mockCategoryQuestions = new List<Question>()
            {
                new Question()
                {
                    Id = questionId,
                    CategoryId = categoryId,
                    CorrectAnswerId = 3,
                    Explanation = "The right answer is always right.",
                    Text = "What is the correct answer?"
                }
            };
            questionService.Setup(x => x.GetCategoryQuestions(categoryId)).Returns(mockCategoryQuestions);

            var answerService = new Mock<IAnswerService>();
            var mockAnswers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    QuestionId = questionId,
                    Text = "Left"
                },
                new Answer()
                {
                    Id = 2,
                    QuestionId = questionId,
                    Text = "Top"
                },
                new Answer()
                {
                    Id = 3,
                    QuestionId = questionId,
                    Text = "Right",
                    Correct = true
                }
            };
            answerService.Setup(x => x.GetAnswersToQuestion(questionId)).Returns(mockAnswers);

            var sut = new CategoryExamService(questionService.Object, answerService.Object);

            var categoryExam = sut.GetCategoryExam(categoryId);

            var correctCount = categoryExam.First().Answers.Count(x => x.Correct == true);

            Assert.Equal(1, correctCount);

        }
    }
}

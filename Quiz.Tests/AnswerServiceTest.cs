using Xunit;
using Quiz.Services;
using Quiz.Service.Interfaces;
using Quiz.Data.Interfaces;
using Moq;
using System.Collections.Generic;
using Quiz.Common;
using System.Linq;

namespace Quiz.Tests
{
    public class AnswerServiceTest
    {
        public class CategoryExamServiceTest
        {
            [Fact]
            public void GetAnswers_ShouldReturnEmptyListOfAnswers_WhenThereIsNoAnswersInDatabase()
            {
                var answerRepository = new Mock<IAnswerRepository>();
                answerRepository.Setup(x => x.GetAnswers()).Returns(new List<Answer> { });
                IAnswerService answerService = new AnswerService(answerRepository.Object);

                var listOfAnswers = answerService.GetAnswers();

                Assert.Empty(listOfAnswers);
            }

            void SetPropertiesOfAnswer(Answer answer)
            {
                answer.Id = 5;
                answer.QuestionId = 3;
                answer.Text = "Hello, I am a text objext!";
                answer.Correct = false;
            }
            [Fact]
            public void GetAnswers_ShouldReturnListOfAnswers_WhenThereIsAnswersInDatabase()
            {

                var mockAnswer = new Mock<Answer>().SetupAllProperties().Object;
                SetPropertiesOfAnswer(mockAnswer);

                var answerRepository = new Mock<IAnswerRepository>();
                answerRepository.Setup(x => x.GetAnswers()).Returns(new List<Answer> { mockAnswer });
                IAnswerService answerService = new AnswerService(answerRepository.Object);

                var listOfAnswers = answerService.GetAnswers();
                var answer = listOfAnswers.First();
                Assert.Equal(mockAnswer, answer);

            }
        }
    }
}

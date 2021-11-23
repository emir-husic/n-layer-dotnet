using System.Collections.Generic;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Quiz.Common;
using Quiz.Service.Interfaces;

namespace Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly ICategoryExamService _categoryExamService;
        private readonly ILog log;

        public QuestionsController(IQuestionService questionService, ICategoryExamService categoryExamService)
        {
            _questionService = questionService;
            _categoryExamService = categoryExamService;
            log = LogManager.GetLogger("QuestionsController");
        }

        [HttpGet]
        public IEnumerable<Question> GetQuestions()
        {
            return _questionService.GetAllQuestions();
        }

        [HttpGet("category/{categoryId}")]
        public IEnumerable<CategoryExam> GetQuestions(int categoryId)
        {
            log.Debug($"Calling CategoryExam with categoryId: {categoryId}");
            return _categoryExamService.GetCategoryExam(categoryId);
        }
    }
}
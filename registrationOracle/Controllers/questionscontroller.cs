using Microsoft.AspNetCore.Mvc;
using System.Data;
using static registrationOracle.packages.PKG_QUESTIONS;

namespace registrationOracle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class questionscontroller : ControllerBase
    {
        private readonly IPKG_BAKARI_QUESTIONS _package;

        public questionscontroller(IPKG_BAKARI_QUESTIONS package)
        {
            _package = package;
        }

        [HttpPost("add")]
        public IActionResult AddQuestion(string p_question, string p_answer, int p_main)
        {
            try
            {
                _package.add_question(p_question, p_answer, p_main);
                return Ok("Question added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding question: {ex.Message}");
            }
        }

        [HttpPut("edit/{id}")]
        public IActionResult EditQuestion(int id, string p_question, string p_answer, int p_main)
        {
            try
            {
                _package.edit_question(id, p_question, p_answer, p_main);
                return Ok($"Question with ID {id} edited successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error editing question: {ex.Message}");
            }
        }

        [HttpGet("list")]
        public IActionResult GetQuestions()
        {
            try
            {
                List<QuestionDto> questions = _package.get_questions();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving questions: {ex.Message}");
            }
        }

    }
}

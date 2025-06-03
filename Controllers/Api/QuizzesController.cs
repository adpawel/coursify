using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Coursify.Data;
using Coursify.Models;
using Coursify.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Coursify.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly CoursifyContext _context;

        public QuizzesController(CoursifyContext context)
        {
            _context = context;
        }

        // GET: api/Quizzes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizDto>>> GetQuizzes()
        {
            var quizzes = await _context.Quiz
                .Select(q => new QuizDto
                {
                    Id = q.Id,
                    Title = q.Title,
                    CourseId = q.CourseId,
                    Level = q.Level
                })
                .ToListAsync();
            return Ok(quizzes);
        }

        // GET: api/Quizzes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizDto>> GetQuiz(int id)
        {
            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            var dto = new QuizDto
            {
                Id = quiz.Id,
                Title = quiz.Title,
                CourseId = quiz.CourseId,
                Level = quiz.Level
            };
            return Ok(dto);
        }

        // PUT: api/Quizzes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz(int id, QuizDto quizDto)
        {
            if (id != quizDto.Id)
            {
                return BadRequest();
            }
         
            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            quiz.Title = quizDto.Title;
            quiz.CourseId = quizDto.CourseId;
            quiz.Level = quizDto.Level;
            _context.Entry(quiz).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        // POST: api/Quizzes
        [HttpPost]
        public async Task<ActionResult<QuizDto>> PostQuiz(QuizDto quizDto)
        {
            var quiz = new Quiz
            {
                Title = quizDto.Title,
                CourseId = quizDto.CourseId,
                Level = quizDto.Level
            };
            _context.Quiz.Add(quiz);
            await _context.SaveChangesAsync();
            quizDto.Id = quiz.Id; // Set the Id of the created quiz
            return CreatedAtAction(nameof(GetQuiz), new { id = quiz.Id }, quizDto);
        }

        // DELETE: api/Quizzes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync();
         
            return NoContent();
        }

        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.Id == id);
        }
    }
}

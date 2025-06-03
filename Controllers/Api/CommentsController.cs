using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Coursify.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Coursify.Data;
using Coursify.Models;

namespace Coursify.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CoursifyContext _context;
        public CommentsController(CoursifyContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments()
        {
            var comments = await _context.Rating
                .Select(r => new CommentDto
                {
                    Id = r.Comment.Id,
                    Description = r.Comment.Description,
                    Title = r.Comment.Title,
                    CourseId = r.CourseId,
                    Author = r.Comment.Author,
                    Stars = r.Stars,
                    RatingId = r.Id
                })
                .ToListAsync();

            return Ok(comments);
        }

        // GET: api/Comments/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CommentDto>> GetComment(int id)
        {
            var comment = await _context.Rating
                .Where(r => r.Comment.Id == id)
                .Select(r => new CommentDto
                {
                    Id = r.Comment.Id,
                    Description = r.Comment.Description,
                    Title = r.Comment.Title,
                    CourseId = r.CourseId,
                    Author = r.Comment.Author,
                    Stars = r.Stars,
                    RatingId = r.Id
                })
                .FirstOrDefaultAsync();

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // POST: api/Comments
        [HttpPost]
        public async Task<ActionResult<CommentDto>> PostComment(CommentDto commentDto)
        {
            if (commentDto == null || string.IsNullOrEmpty(commentDto.Description) || string.IsNullOrEmpty(commentDto.Author))
            {
                return BadRequest("Invalid comment data.");
            }

            var rating = new Rating
            {
                Stars = commentDto.Stars,
                CourseId = commentDto.CourseId,
                Comment = new Comment
                {
                    Title = commentDto.Title,
                    Description = commentDto.Description,
                    Author = commentDto.Author
                }
            };

            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();
            commentDto.Id = rating.Comment.Id;

            return CreatedAtAction(nameof(GetComments), new { id = commentDto.Id }, commentDto);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, CommentDto commentDto)
        {
            if (id != commentDto.Id)
            {
                return BadRequest("Comment ID mismatch.");
            }

            var rating = await _context.Rating
                .Include(r => r.Comment)
                .FirstOrDefaultAsync(r => r.Comment.Id == id);
            
            if (rating == null)
            {
                return NotFound("Comment not found.");
            }
            
            rating.Stars = commentDto.Stars;
            rating.CourseId = commentDto.CourseId;
            rating.Comment.Title = commentDto.Title;
            rating.Comment.Description = commentDto.Description;
            rating.Comment.Author = commentDto.Author;
            
            _context.Entry(rating).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var rating = await _context.Rating
                .Include(r => r.Comment)
                .FirstOrDefaultAsync(r => r.Comment.Id == id);
            
            if (rating == null)
            {
                return NotFound("Comment not found.");
            }
            
            _context.Rating.Remove(rating);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
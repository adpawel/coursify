using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coursify.Data;
using Coursify.Models;
using Coursify.Models.ViewModels;

namespace Coursify.Controllers
{
    public class RatingsController : Controller
    {
        private readonly CoursifyContext _context;

        public RatingsController(CoursifyContext context)
        {
            _context = context;
        }

        // GET: Ratings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rating.ToListAsync());
        }

        // GET: Ratings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Ratings/Create
        public IActionResult Create(int courseId)
        {
            var model = new RatingViewModel
            {
                CourseId = courseId,
            };

            return View(model);
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RatingViewModel model)
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var rating = new Rating
            {
                Stars = model.Stars,
                CourseId = model.CourseId,
                Comment = new Comment
                {
                    Title = model.Title,
                    Description = model.Description,
                    Author = User.Identity?.Name ?? "Anonymous"
                }
            };

            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyCourseDetails", "Courses", new { id = model.CourseId });
        }

        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(int courseId)
        {
            var rating = await _context.Rating
                .Include(r => r.Comment)
                .FirstOrDefaultAsync(r => r.CourseId == courseId);

            if (rating == null)
            {
                return NotFound();
            }

            var model = new RatingViewModel
            {
                Id = rating.Id,
                CourseId = rating.CourseId,
                Stars = rating.Stars,
                Title = rating.Comment?.Title,
                Description = rating.Comment?.Description
            };

            return View(model);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RatingViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var rating = await _context.Rating
                .Include(r => r.Comment)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rating == null)
            {
                return NotFound();
            }

            rating.Stars = model.Stars;
            rating.Comment.Title = model.Title;
            rating.Comment.Description = model.Description;

            await _context.SaveChangesAsync();

            return RedirectToAction("MyCourseDetails", "Courses", new { id = model.CourseId });
        }

        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(int? courseId)
        {
            var rating = await _context.Rating
                .Include(r => r.Comment)
                .FirstOrDefaultAsync(r => r.CourseId == courseId);

            if (rating == null)
            {
                return NotFound();
            }

            var model = new RatingViewModel
            {
                Id = rating.Id,
                CourseId = rating.CourseId,
                Stars = rating.Stars,
                Title = rating.Comment?.Title,
                Description = rating.Comment?.Description
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, RatingViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                .Include(r => r.Comment)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rating == null)
            {
                return NotFound();
            }

            _context.Rating.Remove(rating); 
            await _context.SaveChangesAsync();

            return RedirectToAction("MyCourseDetails", "Courses", new { id = model.CourseId });
        }

        private bool RatingExists(int id)
        {
            return _context.Rating.Any(e => e.Id == id);
        }
    }
}

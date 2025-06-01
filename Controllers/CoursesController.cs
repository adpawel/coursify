using Coursify.Areas.Identity.Data;
using Coursify.Data;
using Coursify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursify.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly CoursifyContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CoursesController(CoursifyContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(this.User);

            return View(await _context.Courses
                .Where(c => c.UserCourses.FirstOrDefault(uc => uc.UserId.Equals(userId)) == null)
                .ToListAsync());
        }

        public async Task<IActionResult> SearchCourses(string searchText)
        {
            string userId = _userManager.GetUserId(this.User);

            var courses = await _context.Courses
                .Where(c => c.UserCourses.All(uc => uc.UserId != userId))
                .ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.ToLower();
                courses = courses
                    .Where(c => c.Name.ToLower().Contains(searchText) ||
                                c.Category.ToLower().Contains(searchText))
                    .ToList();
            }

            return PartialView("_GridView", courses);
        }


        // GET: Courses/MyCourses
        public async Task<IActionResult> MyCourses()
        {
            ViewData["UserId"] = _userManager.GetUserId(this.User);
            string userId = _userManager.GetUserId(this.User);

            return View(await _context.Courses
                .Where(c => c.UserCourses.FirstOrDefault(uc => uc.UserId.Equals(userId)) != null)
                .ToListAsync());

        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Ratings)
                    .ThenInclude(r => r.Comment)
                .Include(c => c.UserCourses)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            // Statystyki zapisów
            var enrolledAllTime = course.UserCourses.Count;
            var enrolledLastWeek = course.UserCourses
                .Count(uc => uc.EnrolledAt >= DateTime.Now.AddDays(-7));

            ViewBag.EnrolledAllTime = enrolledAllTime;
            ViewBag.EnrolledLastWeek = enrolledLastWeek;

            ViewBag.Quizzes = await _context.Quiz
                .Where(q => q.CourseId == id)
                .Include(q => q.UserQuizzes)
                .ToListAsync();

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Category,Details")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Category,Details")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Quit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Quit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuitConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);

            // Znajdź kurs z jego relacjami
            var course = await _context.Courses
                .Include(c => c.UserCourses)
                .FirstOrDefaultAsync(c => c.Id == id);
            
            if (course != null)
            {
                var userCourse = course.UserCourses.FirstOrDefault(uc => uc.UserId == userId);

                if (userCourse != null)
                {
                    _context.UserCourses.Remove(userCourse); 
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyCourses));
        }

        public async Task<IActionResult> Enroll(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            var alreadyEnrolled = await _context.UserCourses
                .AnyAsync(uc => uc.UserId == userId && uc.CourseId == id);
            if (alreadyEnrolled)
            {
                return RedirectToAction(nameof(Index));
            }

            var userCourse = new UserCourse
            {
                UserId = userId,
                CourseId = course.Id,
                EnrolledAt = DateTime.Now 
            };

            _context.UserCourses.Add(userCourse);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> MyCourseDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses
                .Include(c => c.Ratings)
                    .ThenInclude(r => r.Comment)
                .Include(c => c.UserCourses)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            // Statystyki zapisów
            var enrolledAllTime = course.UserCourses.Count;
            var enrolledLastWeek = course.UserCourses
                .Count(uc => uc.EnrolledAt >= DateTime.Now.AddDays(-7));

            ViewBag.EnrolledAllTime = enrolledAllTime;
            ViewBag.EnrolledLastWeek = enrolledLastWeek;

            ViewBag.Quizzes = await _context.Quiz
                .Where(q => q.CourseId == id)
                .Include(q => q.UserQuizzes)
                .ToListAsync();

            return View(course);
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}

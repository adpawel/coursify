using Coursify.Data;
using Coursify.Models;
using Coursify.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Coursify.Areas.Identity.Data;

namespace Coursify.Controllers
{
    public class QuizzesController : Controller
    {
        private readonly CoursifyContext _context;
        private readonly UserManager<AppUser> _userManager;

        public QuizzesController(CoursifyContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Quizzes
        public async Task<IActionResult> Index()
        {
            var coursifyContext = _context.Quiz.Include(q => q.Course);
            return View(await coursifyContext.ToListAsync());
        }

        // GET: Quizzes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                .Include(q => q.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        public IActionResult Create()
        {
            var model = new QuizCreateViewModel
            {
                Courses = _context.Courses
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }),

                Levels = Enum.GetValues(typeof(Level))
                    .Cast<Level>()
                    .Select(level => new SelectListItem
                    {
                        Value = level.ToString(),
                        Text = level.GetType()
                                    .GetMember(level.ToString())[0]
                                    .GetCustomAttribute<DisplayAttribute>()?.Name ?? level.ToString()
                    })
            };

            return View(model);
        }

        [HttpGet("Quizzes/Solve/{quizId}")]
        public async Task<IActionResult> Solve(int? quizId)
        {
            if (quizId == null)
            {
                return NotFound();
            }

            var quiz = _context.Quiz
                .Include(q => q.Course)
                .Include(q => q.UserQuizzes)
                .FirstOrDefault(q => q.Id == quizId);

            if(quiz == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);

            if(!quiz.UserQuizzes.Any(uq => uq.UserId == userId))
            {
                _context.UserQuizzes.Add(new UserQuiz
                {
                    UserId = userId,
                    QuizId = quiz.Id,
                    CompletedAt = DateTime.Now
                });

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MyCourseDetails", "Courses", new { id = quiz.CourseId });
        }

        public async Task<IActionResult> Leaderboard()
        {
            var leaderboardData = await _context.UserQuizzes
                .Include(uq => uq.User)
                .GroupBy(uq => uq.User)
                .Select(g => new
                {
                    g.Key.UserName,
                    g.Key.Email,
                    QuizCount = g.Count()
                })
                .OrderByDescending(x => x.QuizCount)
                .ToListAsync();

            var leaderboard = leaderboardData
                .Select((x, index) => new LeaderboardViewModel
                {
                    UserName = x.UserName,
                    Email = x.Email,
                    QuizCount = x.QuizCount,
                    Rank = index + 1
                })
                .ToList();

            return View(leaderboard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuizCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Courses = _context.Courses.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

                model.Levels = Enum.GetValues(typeof(Level))
                    .Cast<Level>()
                    .Select(level => new SelectListItem
                    {
                        Value = level.ToString(),
                        Text = level.GetType()
                                    .GetMember(level.ToString())[0]
                                    .GetCustomAttribute<DisplayAttribute>()?.Name ?? level.ToString()
                    });

                return View(model);
            }

            var quiz = new Quiz
            {
                Title = model.Title,
                Level = model.Level,
                CourseId = model.CourseId
            };

            _context.Quiz.Add(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Quizzes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Category", quiz.CourseId);
            return View(quiz);
        }

        // POST: Quizzes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Level,CourseId")] Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(quiz.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Category", quiz.CourseId);
            return View(quiz);
        }

        // GET: Quizzes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                .Include(q => q.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: Quizzes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz != null)
            {
                _context.Quiz.Remove(quiz);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.Id == id);
        }
    }
}

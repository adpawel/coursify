using Coursify.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursify.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [PersonalData]
    public string? FirstName { get; set; }
    [PersonalData]
    public string? LastName { get; set; } 
    public string ApiToken { get; set; } = Guid.NewGuid().ToString();
    public ICollection<UserCourse>? UserCourses { get; set; }
    public ICollection<UserQuiz>? UserQuizzes { get; set; }


}


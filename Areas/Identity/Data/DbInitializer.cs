using Coursify.Data;
using Coursify.Models;
using Microsoft.AspNetCore.Identity;

namespace Coursify.Areas.Identity.Data
{
    public static class DbInitializer
    {
        public static void Seed(CoursifyContext context)
        {
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course { Name = "ASP.NET Core", Category = "Web", Details = "Intro to ASP.NET" },
                    new Course { Name = "SQL Basics", Category = "Databases", Details = "Learn SQL" },
                    new Course { Name = "C# Advanced", Category = "Programming", Details = "Delegates, LINQ" },
                    new Course { Name = "Podstawy gotowania", Category = "Gotowanie", Details = "Nauka podstaw kuchni" },
                    new Course { Name = "Makijaż dzienny", Category = "Uroda", Details = "Codzienny makijaż krok po kroku" },
                    new Course { Name = "Historia sztuki", Category = "Sztuka", Details = "Od starożytności do współczesności" },
                    new Course { Name = "Fotografia mobilna", Category = "Fotografia", Details = "Robienie zdjęć telefonem" },
                    new Course { Name = "Jogging dla początkujących", Category = "Sport", Details = "Jak zacząć biegać" },
                    new Course { Name = "JavaScript dla początkujących", Category = "Web", Details = "Podstawy JS" },
                    new Course { Name = "Excel w pracy biurowej", Category = "Office", Details = "Formuły i wykresy" },
                    new Course { Name = "Wprowadzenie do psychologii", Category = "Nauka", Details = "Podstawowe pojęcia" },
                    new Course { Name = "Kreatywne pisanie", Category = "Literatura", Details = "Techniki narracyjne" },
                    new Course { Name = "DIY – Zrób to sam", Category = "Rękodzieło", Details = "Projekty do domu" },
                    new Course { Name = "Pierwsza pomoc", Category = "Medycyna", Details = "Reakcje w nagłych wypadkach" },
                    new Course { Name = "Tworzenie podcastów", Category = "Media", Details = "Nagrywanie i publikacja" },
                    new Course { Name = "Projektowanie wnętrz", Category = "Design", Details = "Podstawy aranżacji" },
                    new Course { Name = "Taniec towarzyski", Category = "Hobby", Details = "Style i kroki" },
                    new Course { Name = "Ogrodnictwo miejskie", Category = "Ekologia", Details = "Uprawa w mieście" },
                    new Course { Name = "Zarządzanie czasem", Category = "Rozwój osobisty", Details = "Techniki organizacji" },
                    new Course { Name = "Git i GitHub", Category = "Narzędzia", Details = "Kontrola wersji" }
                );
                context.SaveChanges();
            }

            if (!context.Quiz.Any())
            {
                context.Quiz.AddRange(
                    // Kurs 1 - ASP.NET Core (5 quizów)
                    new Quiz { Title = "ASP.NET Basics", Level = Level.Basic, CourseId = 1 },
                    new Quiz { Title = "Entity Framework", Level = Level.Medium, CourseId = 1 },
                    new Quiz { Title = "Middleware", Level = Level.Medium, CourseId = 1 },
                    new Quiz { Title = "Dependency Injection", Level = Level.Advanced, CourseId = 1 },
                    new Quiz { Title = "Razor Pages", Level = Level.Basic, CourseId = 1 },

                    // Kurs 2 - SQL Basics (5 quizów)
                    new Quiz { Title = "SQL Joins", Level = Level.Medium, CourseId = 2 },
                    new Quiz { Title = "SQL Subqueries", Level = Level.Advanced, CourseId = 2 },
                    new Quiz { Title = "SQL Aggregations", Level = Level.Basic, CourseId = 2 },
                    new Quiz { Title = "Indexes and Performance", Level = Level.Advanced, CourseId = 2 },
                    new Quiz { Title = "Transactions", Level = Level.Medium, CourseId = 2 },

                    // Kurs 3 - C# Advanced (5 quizów)
                    new Quiz { Title = "C# Delegates", Level = Level.Medium, CourseId = 3 },
                    new Quiz { Title = "LINQ Mastery", Level = Level.Advanced, CourseId = 3 },
                    new Quiz { Title = "Events and Handlers", Level = Level.Medium, CourseId = 3 },
                    new Quiz { Title = "Asynchronous Programming", Level = Level.Advanced, CourseId = 3 },
                    new Quiz { Title = "Generics", Level = Level.Basic, CourseId = 3 },

                    // Kurs 4 - Podstawy gotowania (5 quizów)
                    new Quiz { Title = "Podstawowe techniki gotowania", Level = Level.Basic, CourseId = 4 },
                    new Quiz { Title = "Przyprawy i ich zastosowanie", Level = Level.Medium, CourseId = 4 },
                    new Quiz { Title = "Gotowanie warzyw", Level = Level.Basic, CourseId = 4 },
                    new Quiz { Title = "Gotowanie mięs", Level = Level.Medium, CourseId = 4 },
                    new Quiz { Title = "Bezpieczeństwo w kuchni", Level = Level.Basic, CourseId = 4 },

                    // Kurs 5 - Makijaż dzienny (5 quizów)
                    new Quiz { Title = "Podstawy makijażu", Level = Level.Basic, CourseId = 5 },
                    new Quiz { Title = "Wybór kosmetyków", Level = Level.Medium, CourseId = 5 },
                    new Quiz { Title = "Techniki aplikacji podkładu", Level = Level.Basic, CourseId = 5 },
                    new Quiz { Title = "Makijaż oczu", Level = Level.Medium, CourseId = 5 },
                    new Quiz { Title = "Utrwalenie makijażu", Level = Level.Basic, CourseId = 5 },

                    // Kurs 6 - Historia sztuki (5 quizów)
                    new Quiz { Title = "Sztuka starożytna", Level = Level.Basic, CourseId = 6 },
                    new Quiz { Title = "Renesans", Level = Level.Medium, CourseId = 6 },
                    new Quiz { Title = "Barok", Level = Level.Medium, CourseId = 6 },
                    new Quiz { Title = "Impresjonizm", Level = Level.Medium, CourseId = 6 },
                    new Quiz { Title = "Sztuka współczesna", Level = Level.Advanced, CourseId = 6 },

                    // Kurs 7 - Fotografia mobilna (5 quizów)
                    new Quiz { Title = "Podstawy fotografii", Level = Level.Basic, CourseId = 7 },
                    new Quiz { Title = "Kompozycja zdjęć", Level = Level.Medium, CourseId = 7 },
                    new Quiz { Title = "Edycja zdjęć na telefonie", Level = Level.Medium, CourseId = 7 },
                    new Quiz { Title = "Fotografia w różnych warunkach", Level = Level.Advanced, CourseId = 7 },
                    new Quiz { Title = "Techniki selfie", Level = Level.Basic, CourseId = 7 },

                    // Kurs 8 - Jogging dla początkujących (5 quizów)
                    new Quiz { Title = "Podstawy biegania", Level = Level.Basic, CourseId = 8 },
                    new Quiz { Title = "Plan treningowy", Level = Level.Medium, CourseId = 8 },
                    new Quiz { Title = "Technika biegu", Level = Level.Basic, CourseId = 8 },
                    new Quiz { Title = "Odżywianie biegacza", Level = Level.Medium, CourseId = 8 },
                    new Quiz { Title = "Bezpieczeństwo podczas joggingu", Level = Level.Basic, CourseId = 8 },

                    // Kurs 9 - JavaScript dla początkujących (5 quizów)
                    new Quiz { Title = "Podstawy JavaScript", Level = Level.Basic, CourseId = 9 },
                    new Quiz { Title = "Zmienne i typy danych", Level = Level.Basic, CourseId = 9 },
                    new Quiz { Title = "Funkcje i zdarzenia", Level = Level.Medium, CourseId = 9 },
                    new Quiz { Title = "Manipulacja DOM", Level = Level.Medium, CourseId = 9 },
                    new Quiz { Title = "Asynchroniczność", Level = Level.Advanced, CourseId = 9 },

                    // Kurs 10 - Excel w pracy biurowej (5 quizów)
                    new Quiz { Title = "Formuły podstawowe", Level = Level.Basic, CourseId = 10 },
                    new Quiz { Title = "Tworzenie wykresów", Level = Level.Medium, CourseId = 10 },
                    new Quiz { Title = "Filtrowanie danych", Level = Level.Medium, CourseId = 10 },
                    new Quiz { Title = "Tabele przestawne", Level = Level.Advanced, CourseId = 10 },
                    new Quiz { Title = "Automatyzacja w Excelu", Level = Level.Advanced, CourseId = 10 },

                    // Kurs 11 - Wprowadzenie do psychologii (5 quizów)
                    new Quiz { Title = "Podstawowe pojęcia psychologii", Level = Level.Basic, CourseId = 11 },
                    new Quiz { Title = "Psychologia rozwojowa", Level = Level.Medium, CourseId = 11 },
                    new Quiz { Title = "Psychologia społeczna", Level = Level.Medium, CourseId = 11 },
                    new Quiz { Title = "Zaburzenia psychiczne", Level = Level.Advanced, CourseId = 11 },
                    new Quiz { Title = "Techniki terapeutyczne", Level = Level.Advanced, CourseId = 11 },

                    // Kurs 12 - Kreatywne pisanie (5 quizów)
                    new Quiz { Title = "Techniki narracyjne", Level = Level.Basic, CourseId = 12 },
                    new Quiz { Title = "Budowa postaci", Level = Level.Medium, CourseId = 12 },
                    new Quiz { Title = "Dialogi", Level = Level.Medium, CourseId = 12 },
                    new Quiz { Title = "Styl i język", Level = Level.Advanced, CourseId = 12 },
                    new Quiz { Title = "Edytowanie tekstu", Level = Level.Advanced, CourseId = 12 },

                    // Kurs 13 - DIY – Zrób to sam (5 quizów)
                    new Quiz { Title = "Narzędzia i materiały", Level = Level.Basic, CourseId = 13 },
                    new Quiz { Title = "Projekty dla początkujących", Level = Level.Basic, CourseId = 13 },
                    new Quiz { Title = "Bezpieczeństwo", Level = Level.Medium, CourseId = 13 },
                    new Quiz { Title = "Techniki malarskie", Level = Level.Medium, CourseId = 13 },
                    new Quiz { Title = "Projekty zaawansowane", Level = Level.Advanced, CourseId = 13 },

                    // Kurs 14 - Pierwsza pomoc (5 quizów)
                    new Quiz { Title = "Podstawy pierwszej pomocy", Level = Level.Basic, CourseId = 14 },
                    new Quiz { Title = "Resuscytacja krążeniowo-oddechowa", Level = Level.Medium, CourseId = 14 },
                    new Quiz { Title = "Postępowanie przy złamaniach", Level = Level.Medium, CourseId = 14 },
                    new Quiz { Title = "Pierwsza pomoc przy oparzeniach", Level = Level.Basic, CourseId = 14 },
                    new Quiz { Title = "Zatrucia i reakcje alergiczne", Level = Level.Advanced, CourseId = 14 },

                    // Kurs 15 - Tworzenie podcastów (5 quizów)
                    new Quiz { Title = "Planowanie podcastu", Level = Level.Basic, CourseId = 15 },
                    new Quiz { Title = "Nagrywanie dźwięku", Level = Level.Medium, CourseId = 15 },
                    new Quiz { Title = "Edycja audio", Level = Level.Medium, CourseId = 15 },
                    new Quiz { Title = "Publikacja i dystrybucja", Level = Level.Medium, CourseId = 15 },
                    new Quiz { Title = "Promocja podcastu", Level = Level.Advanced, CourseId = 15 },

                    // Kurs 16 - Projektowanie wnętrz (5 quizów)
                    new Quiz { Title = "Podstawy aranżacji", Level = Level.Basic, CourseId = 16 },
                    new Quiz { Title = "Kolory i materiały", Level = Level.Medium, CourseId = 16 },
                    new Quiz { Title = "Meble i oświetlenie", Level = Level.Medium, CourseId = 16 },
                    new Quiz { Title = "Styl skandynawski", Level = Level.Basic, CourseId = 16 },
                    new Quiz { Title = "Projektowanie przestrzeni małych", Level = Level.Advanced, CourseId = 16 },

                    // Kurs 17 - Taniec towarzyski (5 quizów)
                    new Quiz { Title = "Podstawowe kroki", Level = Level.Basic, CourseId = 17 },
                    new Quiz { Title = "Style tańca", Level = Level.Medium, CourseId = 17 },
                    new Quiz { Title = "Technika partnerstwa", Level = Level.Medium, CourseId = 17 },
                    new Quiz { Title = "Choreografia", Level = Level.Advanced, CourseId = 17 },
                    new Quiz { Title = "Turnieje taneczne", Level = Level.Advanced, CourseId = 17 },

                    // Kurs 18 - Ogrodnictwo miejskie (5 quizów)
                    new Quiz { Title = "Uprawa warzyw w mieście", Level = Level.Basic, CourseId = 18 },
                    new Quiz { Title = "Rośliny ozdobne", Level = Level.Medium, CourseId = 18 },
                    new Quiz { Title = "Pielęgnacja roślin", Level = Level.Medium, CourseId = 18 },
                    new Quiz { Title = "Ekologiczne metody", Level = Level.Advanced, CourseId = 18 },
                    new Quiz { Title = "Planowanie ogrodu miejskiego", Level = Level.Basic, CourseId = 18 },

                    // Kurs 19 - Zarządzanie czasem (5 quizów)
                    new Quiz { Title = "Podstawy zarządzania czasem", Level = Level.Basic, CourseId = 19 },
                    new Quiz { Title = "Techniki planowania", Level = Level.Medium, CourseId = 19 },
                    new Quiz { Title = "Priorytetyzacja zadań", Level = Level.Medium, CourseId = 19 },
                    new Quiz { Title = "Radzenie sobie ze stresem", Level = Level.Advanced, CourseId = 19 },
                    new Quiz { Title = "Nawyki produktywności", Level = Level.Advanced, CourseId = 19 },

                    // Kurs 20 - Git i GitHub (5 quizów)
                    new Quiz { Title = "Podstawy Git", Level = Level.Basic, CourseId = 20 },
                    new Quiz { Title = "Praca z repozytoriami", Level = Level.Medium, CourseId = 20 },
                    new Quiz { Title = "Branching i merging", Level = Level.Medium, CourseId = 20 },
                    new Quiz { Title = "Rozwiązywanie konfliktów", Level = Level.Advanced, CourseId = 20 },
                    new Quiz { Title = "GitHub Actions", Level = Level.Advanced, CourseId = 20 }
                );
                context.SaveChanges();
            }
            if (!context.UserCourses.Any()) 
                AssignCoursesToUsers(context);
            if (!context.UserQuizzes.Any())
                AssignQuizzesToUsers(context);

            if(!context.Rating.Any())
                GenerateRatings(context);

            //context.Rating.RemoveRange(context.Rating);
            //context.SaveChanges();
        }

        public static void AssignCoursesToUsers(CoursifyContext context)
        {
            var users = context.Users.ToList();
            var allCourseIds = context.Courses.Select(c => c.Id).ToList();
            var rng = new Random();

            foreach (var user in users)
            {
                var assignedCourses = new HashSet<int>();

                while (assignedCourses.Count < 5)
                {
                    var randomCourseId = allCourseIds[rng.Next(allCourseIds.Count)];
                    assignedCourses.Add(randomCourseId);
                }

                foreach (var courseId in assignedCourses)
                {
                    // 50% szans, że data będzie z ostatniego tygodnia
                    var daysOffset = rng.NextDouble() < 0.5
                        ? rng.Next(0, 7) // ostatni tydzień
                        : rng.Next(7, 60); // wcześniejsze daty (7 do 60 dni temu)

                    var enrolledAt = DateTime.UtcNow.AddDays(-daysOffset).AddHours(rng.Next(0, 24)).AddMinutes(rng.Next(0, 60));

                    context.UserCourses.Add(new UserCourse
                    {
                        UserId = user.Id,
                        CourseId = courseId,
                        EnrolledAt = enrolledAt
                    });
                }
            }

            context.SaveChanges();
        }

        public static void AssignQuizzesToUsers(CoursifyContext context)
        {
            var rng = new Random();

            var userCourses = context.UserCourses.ToList(); // kursy przypisane do użytkowników
            var quizzes = context.Quiz.ToList(); // wszystkie quizy z ich CourseId

            // pogrupuj quizy po CourseId
            var quizzesByCourse = quizzes
                .GroupBy(q => q.CourseId)
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var userCourse in userCourses)
            {
                if (!quizzesByCourse.ContainsKey(userCourse.CourseId))
                    continue; // brak quizów dla tego kursu

                var courseQuizzes = quizzesByCourse[userCourse.CourseId];

                // Wybierz 1–5 quizów losowo
                var selectedQuizzes = courseQuizzes
                    .OrderBy(q => rng.Next())
                    .Take(rng.Next(1, Math.Min(6, courseQuizzes.Count + 1)))
                    .ToList();

                foreach (var quiz in selectedQuizzes)
                {
                    // Wygeneruj losowy dzień między datą zapisania a dziś
                    var enrollmentDate = userCourse.EnrolledAt.Date;
                    var today = DateTime.UtcNow.Date;

                    if (enrollmentDate >= today)
                        continue; // użytkownik zapisał się dzisiaj lub w przyszłości – nie wykonuje jeszcze quizów

                    var totalDays = (today - enrollmentDate).Days;
                    var completedAt = enrollmentDate.AddDays(rng.Next(1, totalDays + 1));

                    context.UserQuizzes.Add(new UserQuiz
                    {
                        UserId = userCourse.UserId,
                        QuizId = quiz.Id,
                        CompletedAt = completedAt
                    });
                }
            }

            context.SaveChanges();
        }

        public static void GenerateRatings(CoursifyContext context)
        {
            var rng = new Random();

            // Pobierz użytkowników i ich kursy
            var users = context.Users.ToList();
            var userCourses = context.UserCourses.ToList();

            var ratings = new List<Rating>();

            foreach (var user in users)
            {
                // Wyszukaj kursy użytkownika
                var enrolledCourses = userCourses
                    .Where(uc => uc.UserId == user.Id)
                    .Select(uc => uc.CourseId)
                    .ToList();

                foreach (var courseId in enrolledCourses)
                {
                    // Możemy losowo pominąć niektóre oceny, by było realistycznie
                    if (rng.NextDouble() < 0.4) continue;

                    int stars = rng.Next(1, 6); // 1–5 gwiazdek

                    ratings.Add(new Rating
                    {
                        Stars = stars,
                        CourseId = courseId,
                        Comment = GetCommentForStars(stars, user)
                    });
                }
            }

            context.Rating.AddRange(ratings);
            context.SaveChanges();
        }

        private static Comment GetCommentForStars(int stars, IdentityUser user)
        {
            var rng = new Random();

            string title, description;

            if (stars <= 2)
            {
                var negativeTitles = new[] { "Rozczarowujące", "Nie polecam", "Słaby kurs" };
                var negativeDescriptions = new[]
                {
            "Treści mało przydatne.",
            "Prowadzący nie tłumaczy jasno.",
            "Spodziewałem się więcej po tym kursie."
        };

                title = negativeTitles[rng.Next(negativeTitles.Length)];
                description = negativeDescriptions[rng.Next(negativeDescriptions.Length)];
            }
            else if (stars == 3)
            {
                var neutralTitles = new[] { "Może być", "Średni", "Nic specjalnego" };
                var neutralDescriptions = new[]
                {
            "Część materiału była ok, część nie.",
            "Nie najgorszy, ale mogło być lepiej.",
            "Po prostu przeciętny kurs."
        };

                title = neutralTitles[rng.Next(neutralTitles.Length)];
                description = neutralDescriptions[rng.Next(neutralDescriptions.Length)];
            }
            else
            {
                var positiveTitles = new[] { "Świetny kurs!", "Polecam!", "Warto było!" };
                var positiveDescriptions = new[]
                {
            "Bardzo dobrze wytłumaczone zagadnienia.",
            "Świetna struktura kursu i dobre materiały.",
            "Dużo się nauczyłem i było ciekawie."
        };

                title = positiveTitles[rng.Next(positiveTitles.Length)];
                description = positiveDescriptions[rng.Next(positiveDescriptions.Length)];
            }

            return new Comment
            {
                Title = title,
                Description = description,
                Author = user.Email ?? user.UserName ?? "Anonim"
            };
        }

    }
}

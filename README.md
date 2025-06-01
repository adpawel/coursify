# 📚 Coursify

**Coursify** to aplikacja internetowa stworzona w ASP.NET Core MVC, która umożliwia tworzenie i rozwiązywanie quizów przypisanych do kursów. Projekt zawiera system użytkowników, przypisywanie kursów, ranking użytkowników oraz system oceniania kursów.

---

## 🧩 Funkcje

- Rejestracja i logowanie użytkowników (Identity)
- Przeglądanie dostępnych kursów
- Dołączanie do kursów
- Przeglądanie szczegółów kursu i statystyk zapisów
- Quizy przypisane do kursów
- Zapamiętywanie wykonanych quizów przez użytkowników
- System ocen i komentarzy do kursów
- Tabela wyników (Leaderboard) z rankingiem użytkowników

---

## Baza danych - tabele
- Comment
- Courses
- Quiz
- Rating
- UserCourses
- UserQuizzes

---

## 🛠️ Technologie

- ASP.NET Core MVC
- Entity Framework Core
- sqlite (lub inna baza danych)
- Bootstrap + jQuery + DataTables
- ASP.NET Identity (zarządzanie użytkownikami)

---

## 📦 Struktura projektu

- `Models/` – modele danych (Course, Quiz, UserQuiz, Rating, Comment itp.)
- `Controllers/` – kontrolery obsługujące logikę (CoursesController, QuizzesController, RatingsController)
- `Views/` – widoki Razor (.cshtml)
- `wwwroot/` – zasoby statyczne (JS, CSS)
- `Data/` – kontekst bazy danych (CoursifyContext)
- `Migrations/` – migracje EF Core

---

## ⚙️ Konfiguracja lokalna

1. **Klonuj repozytorium**:
    ```bash
    git clone https://github.com/twoje-repo/coursify.git
    cd coursify
    ```

2. **Utwórz bazę danych**:
    Upewnij się, że w pliku `appsettings.json` masz poprawny connection string. Następnie uruchom:

    ```bash
    dotnet ef database update
    ```

3. **Uruchom aplikację**:
    ```bash
    dotnet run
    ```

4. **Wejdź na**:
    ```
    https://localhost:5001
    ```

---

## 📊 Ranking użytkowników (Leaderboard)

Dostępny pod:
```
/Quizzes/Leaderboard
```
Zawiera listę użytkowników posortowanych według liczby rozwiązanych quizów.
---

## ✅ Do zrobienia (TODO)

- Dodanie czasu rozwiązywania quizów
- Historia quizów użytkownika
- Realne quizy

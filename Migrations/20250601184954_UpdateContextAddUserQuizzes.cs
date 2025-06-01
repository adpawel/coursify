using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coursify.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContextAddUserQuizzes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuiz_AspNetUsers_UserId",
                table: "UserQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuiz_Quiz_QuizId",
                table: "UserQuiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuiz",
                table: "UserQuiz");

            migrationBuilder.RenameTable(
                name: "UserQuiz",
                newName: "UserQuizzes");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuiz_QuizId",
                table: "UserQuizzes",
                newName: "IX_UserQuizzes_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuizzes",
                table: "UserQuizzes",
                columns: new[] { "UserId", "QuizId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizzes_AspNetUsers_UserId",
                table: "UserQuizzes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizzes_Quiz_QuizId",
                table: "UserQuizzes",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizzes_AspNetUsers_UserId",
                table: "UserQuizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizzes_Quiz_QuizId",
                table: "UserQuizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuizzes",
                table: "UserQuizzes");

            migrationBuilder.RenameTable(
                name: "UserQuizzes",
                newName: "UserQuiz");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuizzes_QuizId",
                table: "UserQuiz",
                newName: "IX_UserQuiz_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuiz",
                table: "UserQuiz",
                columns: new[] { "UserId", "QuizId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuiz_AspNetUsers_UserId",
                table: "UserQuiz",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuiz_Quiz_QuizId",
                table: "UserQuiz",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coursify.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentCourseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Rating_Id",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Rating",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comment",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_CourseId",
                table: "Rating",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_RatingId",
                table: "Comment",
                column: "RatingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Rating_RatingId",
                table: "Comment",
                column: "RatingId",
                principalTable: "Rating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Courses_CourseId",
                table: "Rating",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Rating_RatingId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Courses_CourseId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_CourseId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Comment_RatingId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Rating");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comment",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Rating_Id",
                table: "Comment",
                column: "Id",
                principalTable: "Rating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

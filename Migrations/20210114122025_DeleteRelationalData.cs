using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMovieBookingAPI.Migrations
{
    public partial class DeleteRelationalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_user",
                schema: "ocb",
                table: "booking");

            migrationBuilder.DropForeignKey(
                name: "FK_cinema_city",
                schema: "ocb",
                table: "cinema");

            migrationBuilder.DropForeignKey(
                name: "FK_hall_cinema",
                schema: "ocb",
                table: "hall");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_schedule_movie",
                schema: "ocb",
                table: "movie_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_schedule_schedule",
                schema: "ocb",
                table: "movie_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_schedule_hall",
                schema: "ocb",
                table: "schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_user_city",
                schema: "ocb",
                table: "user");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_user",
                schema: "ocb",
                table: "booking",
                column: "user_id",
                principalSchema: "ocb",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cinema_city",
                schema: "ocb",
                table: "cinema",
                column: "city_id",
                principalSchema: "ocb",
                principalTable: "city",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hall_cinema",
                schema: "ocb",
                table: "hall",
                column: "cinema_id",
                principalSchema: "ocb",
                principalTable: "cinema",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_schedule_movie",
                schema: "ocb",
                table: "movie_schedule",
                column: "movie_id",
                principalSchema: "ocb",
                principalTable: "movie",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_schedule_schedule",
                schema: "ocb",
                table: "movie_schedule",
                column: "schedule_id",
                principalSchema: "ocb",
                principalTable: "schedule",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_hall",
                schema: "ocb",
                table: "schedule",
                column: "hall_id",
                principalSchema: "ocb",
                principalTable: "hall",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_city",
                schema: "ocb",
                table: "user",
                column: "city_id",
                principalSchema: "ocb",
                principalTable: "city",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_user",
                schema: "ocb",
                table: "booking");

            migrationBuilder.DropForeignKey(
                name: "FK_cinema_city",
                schema: "ocb",
                table: "cinema");

            migrationBuilder.DropForeignKey(
                name: "FK_hall_cinema",
                schema: "ocb",
                table: "hall");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_schedule_movie",
                schema: "ocb",
                table: "movie_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_schedule_schedule",
                schema: "ocb",
                table: "movie_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_schedule_hall",
                schema: "ocb",
                table: "schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_user_city",
                schema: "ocb",
                table: "user");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_user",
                schema: "ocb",
                table: "booking",
                column: "user_id",
                principalSchema: "ocb",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cinema_city",
                schema: "ocb",
                table: "cinema",
                column: "city_id",
                principalSchema: "ocb",
                principalTable: "city",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_hall_cinema",
                schema: "ocb",
                table: "hall",
                column: "cinema_id",
                principalSchema: "ocb",
                principalTable: "cinema",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_schedule_movie",
                schema: "ocb",
                table: "movie_schedule",
                column: "movie_id",
                principalSchema: "ocb",
                principalTable: "movie",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_schedule_schedule",
                schema: "ocb",
                table: "movie_schedule",
                column: "schedule_id",
                principalSchema: "ocb",
                principalTable: "schedule",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_hall",
                schema: "ocb",
                table: "schedule",
                column: "hall_id",
                principalSchema: "ocb",
                principalTable: "hall",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_city",
                schema: "ocb",
                table: "user",
                column: "city_id",
                principalSchema: "ocb",
                principalTable: "city",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPISample.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    PosterImg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Director", "Genre", "PosterImg", "Title" },
                values: new object[,]
                {
                    { 1, "Martin Scorsese", "Drama", "https://www.joblo.com/assets/images/oldsite/posters/images/full/2008-dark_knight-5.jpg", "The Departed" },
                    { 2, "Christopher Nolan", "Drama", "https://www.joblo.com/assets/images/oldsite/posters/images/full/2006-departed-9.jpg", "The Dark Knight" },
                    { 3, "Christopher Nolan", "Drama", "https://www.joblo.com/assets/images/oldsite/posters/images/full/inception-imax-poster0.jpg", "Inception" },
                    { 4, "David Gordon Green", "Comedy", "https://www.joblo.com/assets/images/oldsite/posters/images/full/2008-pineapple_express-4.jpg", "Pineapple Express" },
                    { 5, "John McTiernan", "Action", "https://www.joblo.com/assets/images/oldsite/posters/images/full/1988-die-hard-poster2.jpg", "Die Hard" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}

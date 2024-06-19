using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilkyProject.DataAccessLayer.Migrations
{
    public partial class mig_jobname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobName",
                table: "Testimonials");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class StateCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Tareas");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tareas",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Tareas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_StateId",
                table: "Tareas",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_States_StateId",
                table: "Tareas",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_States_StateId",
                table: "Tareas");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_StateId",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Tareas");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tareas",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tareas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Tareas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

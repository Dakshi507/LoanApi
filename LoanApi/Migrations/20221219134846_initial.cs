using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Userdetails",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userdetails", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Loandetails",
                columns: table => new
                {
                    Loanid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loannumber = table.Column<int>(type: "int", nullable: false),
                    Propertyaddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loanamount = table.Column<int>(type: "int", nullable: false),
                    Loantype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanTerm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loandetails", x => x.Loanid);
                    table.ForeignKey(
                        name: "FK_Loandetails_Userdetails_UserId",
                        column: x => x.UserId,
                        principalTable: "Userdetails",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loandetails_Loannumber",
                table: "Loandetails",
                column: "Loannumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loandetails_UserId",
                table: "Loandetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Userdetails_Username",
                table: "Userdetails",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loandetails");

            migrationBuilder.DropTable(
                name: "Userdetails");
        }
    }
}

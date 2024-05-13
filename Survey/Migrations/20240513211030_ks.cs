using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey.Migrations
{
    public partial class ks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyUser_Company_Author_CompanyId",
                table: "SurveyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyUser_Company_CompanyId",
                table: "SurveyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyUser_SurveyUser_Authorid",
                table: "SurveyUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyUser",
                table: "SurveyUser");

            migrationBuilder.DropIndex(
                name: "IX_SurveyUser_Author_CompanyId",
                table: "SurveyUser");

            migrationBuilder.DropIndex(
                name: "IX_SurveyUser_Authorid",
                table: "SurveyUser");

            migrationBuilder.DropIndex(
                name: "IX_SurveyUser_CompanyId",
                table: "SurveyUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22735325-9069-4bc3-b285-60083799306a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "272633e6-5404-4ead-afcb-fa09f23a3f94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ccdb484-b43d-4fa3-8bb5-de14dd911360");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98d164a3-162f-4b5b-ae78-5c2b1dce3eb7");

            migrationBuilder.DropColumn(
                name: "Author_CompanyId",
                table: "SurveyUser");

            migrationBuilder.DropColumn(
                name: "Author_Confirmed",
                table: "SurveyUser");

            migrationBuilder.DropColumn(
                name: "Authorid",
                table: "SurveyUser");

            migrationBuilder.DropColumn(
                name: "Boss_Confirmed",
                table: "SurveyUser");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "SurveyUser");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "SurveyUser");

            migrationBuilder.RenameTable(
                name: "SurveyUser",
                newName: "Commenters");

            migrationBuilder.AlterColumn<bool>(
                name: "Confirmed",
                table: "Commenters",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commenters",
                table: "Commenters",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    Confirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    LikeRate = table.Column<float>(type: "REAL", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Authors_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bosses",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    Confirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    LikeRate = table.Column<float>(type: "REAL", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bosses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bosses_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a0aa30d-4656-4189-bd35-73d9808d1fbb", null, "Boss", "BOSS" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c6b6500-1887-4e18-b762-2ee76080f138", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "230172b1-b774-4045-80f8-f5c8eab9aed4", null, "Author", "AUTHOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7426c844-0705-4967-af5f-3b3465eee682", null, "Commentator", "COMMENTATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_CompanyId",
                table: "Authors",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bosses_CompanyId",
                table: "Bosses",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Bosses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commenters",
                table: "Commenters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a0aa30d-4656-4189-bd35-73d9808d1fbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c6b6500-1887-4e18-b762-2ee76080f138");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "230172b1-b774-4045-80f8-f5c8eab9aed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7426c844-0705-4967-af5f-3b3465eee682");

            migrationBuilder.RenameTable(
                name: "Commenters",
                newName: "SurveyUser");

            migrationBuilder.AlterColumn<bool>(
                name: "Confirmed",
                table: "SurveyUser",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Author_CompanyId",
                table: "SurveyUser",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Author_Confirmed",
                table: "SurveyUser",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Authorid",
                table: "SurveyUser",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Boss_Confirmed",
                table: "SurveyUser",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "SurveyUser",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "SurveyUser",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyUser",
                table: "SurveyUser",
                column: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22735325-9069-4bc3-b285-60083799306a", null, "Commentator", "COMMENTATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "272633e6-5404-4ead-afcb-fa09f23a3f94", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ccdb484-b43d-4fa3-8bb5-de14dd911360", null, "Boss", "BOSS" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98d164a3-162f-4b5b-ae78-5c2b1dce3eb7", null, "Author", "AUTHOR" });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyUser_Author_CompanyId",
                table: "SurveyUser",
                column: "Author_CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyUser_Authorid",
                table: "SurveyUser",
                column: "Authorid");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyUser_CompanyId",
                table: "SurveyUser",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyUser_Company_Author_CompanyId",
                table: "SurveyUser",
                column: "Author_CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyUser_Company_CompanyId",
                table: "SurveyUser",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyUser_SurveyUser_Authorid",
                table: "SurveyUser",
                column: "Authorid",
                principalTable: "SurveyUser",
                principalColumn: "id");
        }
    }
}

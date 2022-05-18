using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWords.infrastructure.Persistent.Migrations
{
    public partial class added1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FristName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldEmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewEmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailConfigurations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Entiries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entiries_Users_CreateById",
                        column: x => x.CreateById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntiryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryComments_Entiries_EntiryId",
                        column: x => x.EntiryId,
                        principalTable: "Entiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryComments_Users_CreateById",
                        column: x => x.CreateById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryFovorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntiryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryFovorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryFovorites_Entiries_EntiryId",
                        column: x => x.EntiryId,
                        principalTable: "Entiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryFovorites_Users_GreatedUserId",
                        column: x => x.GreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntiryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoteType = table.Column<int>(type: "int", nullable: false),
                    CreateById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryVotes_EmailConfigurations_EntryCommentId",
                        column: x => x.EntryCommentId,
                        principalTable: "EmailConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryVotes_Entiries_EntiryId",
                        column: x => x.EntiryId,
                        principalTable: "Entiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryCommentFovorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryCommandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryCommentFovorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryCommentFovorites_EntryComments_EntryCommentId",
                        column: x => x.EntryCommentId,
                        principalTable: "EntryComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryCommentFovorites_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryCommentVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntiryCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoteType = table.Column<int>(type: "int", nullable: false),
                    CreateById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntiryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryCommentVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryCommentVotes_Entiries_EntiryId",
                        column: x => x.EntiryId,
                        principalTable: "Entiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryCommentVotes_EntryComments_EntryCommentId",
                        column: x => x.EntryCommentId,
                        principalTable: "EntryComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailConfigurations_UserId",
                table: "EmailConfigurations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Entiries_CreateById",
                table: "Entiries",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_EntryCommentFovorites_CreatedUserId",
                table: "EntryCommentFovorites",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryCommentFovorites_EntryCommentId",
                table: "EntryCommentFovorites",
                column: "EntryCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryComments_CreateById",
                table: "EntryComments",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_EntryComments_EntiryId",
                table: "EntryComments",
                column: "EntiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryCommentVotes_EntiryId",
                table: "EntryCommentVotes",
                column: "EntiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryCommentVotes_EntryCommentId",
                table: "EntryCommentVotes",
                column: "EntryCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryFovorites_EntiryId",
                table: "EntryFovorites",
                column: "EntiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryFovorites_GreatedUserId",
                table: "EntryFovorites",
                column: "GreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryVotes_EntiryId",
                table: "EntryVotes",
                column: "EntiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryVotes_EntryCommentId",
                table: "EntryVotes",
                column: "EntryCommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryCommentFovorites");

            migrationBuilder.DropTable(
                name: "EntryCommentVotes");

            migrationBuilder.DropTable(
                name: "EntryFovorites");

            migrationBuilder.DropTable(
                name: "EntryVotes");

            migrationBuilder.DropTable(
                name: "EntryComments");

            migrationBuilder.DropTable(
                name: "EmailConfigurations");

            migrationBuilder.DropTable(
                name: "Entiries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

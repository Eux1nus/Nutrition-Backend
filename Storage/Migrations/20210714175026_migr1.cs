using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Storage.Migrations
{
    public partial class migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivationCodes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActivate = table.Column<bool>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    PhoneNumberType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivationCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalOptions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    SexType = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    IsActivated = table.Column<bool>(nullable: false),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    ServantType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiftSertificates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    PersonId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftSertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftSertificates_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PersonId = table.Column<long>(nullable: false),
                    UserRole = table.Column<int>(nullable: false),
                    IsActivated = table.Column<bool>(nullable: false),
                    SubscribeId = table.Column<long>(nullable: true),
                    DateRegistration = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalOptionsServants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    AdditionalOptionsId = table.Column<long>(nullable: true),
                    ServantId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalOptionsServants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalOptionsServants_AdditionalOptions_AdditionalOptio~",
                        column: x => x.AdditionalOptionsId,
                        principalTable: "AdditionalOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdditionalOptionsServants_Servants_ServantId",
                        column: x => x.ServantId,
                        principalTable: "Servants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServantPhotos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    ServantId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServantPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServantPhotos_Servants_ServantId",
                        column: x => x.ServantId,
                        principalTable: "Servants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarOfEvents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarOfEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarOfEvents_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultations_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodDiaries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDiaries_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questionnaire",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Heigh = table.Column<double>(nullable: false),
                    CurrentWeight = table.Column<double>(nullable: false),
                    DesiredWeight = table.Column<double>(nullable: false),
                    NeckVolume = table.Column<double>(nullable: false),
                    BreastVolume = table.Column<double>(nullable: false),
                    Waist = table.Column<double>(nullable: false),
                    Hips = table.Column<double>(nullable: false),
                    BloodType = table.Column<double>(nullable: false),
                    FromUserId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    PersonId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questionnaire_User_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questionnaire_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FromUserId = table.Column<long>(nullable: false),
                    ToUserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_User_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_User_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAdditionalOptions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    AdditionalOptionsId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdditionalOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdditionalOptions_AdditionalOptions_AdditionalOptionsId",
                        column: x => x.AdditionalOptionsId,
                        principalTable: "AdditionalOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdditionalOptions_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGiftSertificates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    GiftSertificateId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGiftSertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGiftSertificates_GiftSertificates_GiftSertificateId",
                        column: x => x.GiftSertificateId,
                        principalTable: "GiftSertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGiftSertificates_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserServants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    ServantId = table.Column<long>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserServants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserServants_Servants_ServantId",
                        column: x => x.ServantId,
                        principalTable: "Servants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserServants_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    FromUserId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FoodDiaryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_FoodDiaries_FoodDiaryId",
                        column: x => x.FoodDiaryId,
                        principalTable: "FoodDiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_User_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestForm",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    FoodDiaryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestForm_FoodDiaries_FoodDiaryId",
                        column: x => x.FoodDiaryId,
                        principalTable: "FoodDiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestForm_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodTestPhotos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    FromUserId = table.Column<long>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    QuestionnaireId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTestPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodTestPhotos_User_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodTestPhotos_Questionnaire_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsPhotos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    FromUserId = table.Column<long>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    QuestionsId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsPhotos_User_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionsPhotos_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentsFile",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    File = table.Column<string>(nullable: true),
                    FromUserId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CommentsId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentsFile_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentsFile_User_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalOptionsServants_AdditionalOptionsId",
                table: "AdditionalOptionsServants",
                column: "AdditionalOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalOptionsServants_ServantId",
                table: "AdditionalOptionsServants",
                column: "ServantId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTestPhotos_FromUserId",
                table: "BloodTestPhotos",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTestPhotos_QuestionnaireId",
                table: "BloodTestPhotos",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarOfEvents_UserId",
                table: "CalendarOfEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FoodDiaryId",
                table: "Comments",
                column: "FoodDiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FromUserId",
                table: "Comments",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsFile_CommentsId",
                table: "CommentsFile",
                column: "CommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsFile_FromUserId",
                table: "CommentsFile",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_UserId",
                table: "Consultations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_UserId",
                table: "FoodDiaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftSertificates_PersonId",
                table: "GiftSertificates",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaire_FromUserId",
                table: "Questionnaire",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaire_PersonId",
                table: "Questionnaire",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FromUserId",
                table: "Questions",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ToUserId",
                table: "Questions",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsPhotos_FromUserId",
                table: "QuestionsPhotos",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsPhotos_QuestionsId",
                table: "QuestionsPhotos",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestForm_FoodDiaryId",
                table: "RequestForm",
                column: "FoodDiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestForm_UserId",
                table: "RequestForm",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServantPhotos_ServantId",
                table: "ServantPhotos",
                column: "ServantId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdditionalOptions_AdditionalOptionsId",
                table: "UserAdditionalOptions",
                column: "AdditionalOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdditionalOptions_UserId",
                table: "UserAdditionalOptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGiftSertificates_GiftSertificateId",
                table: "UserGiftSertificates",
                column: "GiftSertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGiftSertificates_UserId",
                table: "UserGiftSertificates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserServants_ServantId",
                table: "UserServants",
                column: "ServantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserServants_UserId",
                table: "UserServants",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivationCodes");

            migrationBuilder.DropTable(
                name: "AdditionalOptionsServants");

            migrationBuilder.DropTable(
                name: "BloodTestPhotos");

            migrationBuilder.DropTable(
                name: "CalendarOfEvents");

            migrationBuilder.DropTable(
                name: "CommentsFile");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "QuestionsPhotos");

            migrationBuilder.DropTable(
                name: "RequestForm");

            migrationBuilder.DropTable(
                name: "ServantPhotos");

            migrationBuilder.DropTable(
                name: "UserAdditionalOptions");

            migrationBuilder.DropTable(
                name: "UserGiftSertificates");

            migrationBuilder.DropTable(
                name: "UserServants");

            migrationBuilder.DropTable(
                name: "Questionnaire");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AdditionalOptions");

            migrationBuilder.DropTable(
                name: "GiftSertificates");

            migrationBuilder.DropTable(
                name: "Servants");

            migrationBuilder.DropTable(
                name: "FoodDiaries");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}

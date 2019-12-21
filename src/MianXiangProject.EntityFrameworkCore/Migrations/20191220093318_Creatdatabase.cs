using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MianXiangProject.Migrations
{
    public partial class Creatdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MXAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sort = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    AttributeName = table.Column<string>(nullable: true),
                    AttributeValue = table.Column<string>(nullable: true),
                    AttributeType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MXAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MXCompany",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sort = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: true),
                    CompanyType = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MXCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MXJob",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sort = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    JobName = table.Column<string>(maxLength: 100, nullable: true),
                    JobType = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MXJob", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MXQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sort = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Question = table.Column<string>(type: "text", nullable: true),
                    QuestionType = table.Column<string>(nullable: false),
                    QuestionCate = table.Column<string>(maxLength: 50, nullable: true),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    JobId = table.Column<int>(nullable: false),
                    Knowledge1 = table.Column<string>(maxLength: 255, nullable: true),
                    Knowledge2 = table.Column<string>(maxLength: 255, nullable: true),
                    Knowledge3 = table.Column<string>(maxLength: 255, nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    Options = table.Column<string>(maxLength: 500, nullable: true),
                    Tags = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MXQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WxAppletUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sort = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UnionId = table.Column<string>(nullable: true),
                    OpenId = table.Column<string>(nullable: true),
                    SessionKey = table.Column<string>(nullable: true),
                    SessionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WxAppletUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WxUserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sort = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Uid = table.Column<string>(nullable: true),
                    Openid = table.Column<string>(nullable: true),
                    UnionId = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Headimgul = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WxUserInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MXAttribute");

            migrationBuilder.DropTable(
                name: "MXCompany");

            migrationBuilder.DropTable(
                name: "MXJob");

            migrationBuilder.DropTable(
                name: "MXQuestion");

            migrationBuilder.DropTable(
                name: "WxAppletUser");

            migrationBuilder.DropTable(
                name: "WxUserInfo");
        }
    }
}

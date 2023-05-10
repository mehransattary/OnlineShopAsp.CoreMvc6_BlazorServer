using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertiseImage = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    AdvertiseName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AdvertiseUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogCategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BlogCategoryEnglishName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BlogCategoryImage = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    BlogCategoryOrder = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    BlogCategoryShortDescription = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    BlogCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogCategoryIsEnableForMainPage = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BrandEnglishName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BrandImage = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    BrandOrder = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    BrandShortDescription = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    BrandDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandIsEnableForMainPage = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CategoryEnglishName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CategoryImage = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    CategoryOrder = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    CategoryShortDescription = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryIsEnableForMainPage = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactorMain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactorMainDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FactorMainNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FactorMainPayNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FactorMainSumPriceAll = table.Column<double>(type: "float", nullable: false),
                    FactorMainBuyerFullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FactorMainBuyerAddress = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    FactorMainBuyerMobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    FactorMainBuyerCodePosti = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FactorMainSellerFullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FactorMainSellerAddress = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    FactorMainSellerPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorMain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PostPrice = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RoleTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ServiceImage = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    ServiceOrder = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    ServiceShortDescription = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceIsEnableForMainPage = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettingSiteName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SettingShopName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SettingAddress = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderImage = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    SliderName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SliderShortDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SliderUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialEnum = table.Column<int>(type: "int", nullable: false),
                    SocialOrder = table.Column<byte>(type: "tinyint", nullable: false),
                    SocialLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogGroupName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BlogGroupImage = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    BlogGroupOrder = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    BlogGroupShortDescription = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    BlogGroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogGroupIsEnableForMainPage = table.Column<bool>(type: "bit", nullable: false),
                    BlogCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogGroups_BlogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GroupImage = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    GroupOrder = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    GroupShortDescription = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    GroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupIsEnableForMainPage = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactorDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactorDetailsNameProduct = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FactorDetailsCountProduct = table.Column<int>(type: "int", nullable: false),
                    FactorDetailsPriceProduct = table.Column<double>(type: "float", nullable: false),
                    FactorDetailsSumPriceProduct = table.Column<double>(type: "float", nullable: false),
                    FactorMainId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactorDetails_FactorMain_FactorMainId",
                        column: x => x.FactorMainId,
                        principalTable: "FactorMain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CodePosti = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BlogImageMain = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    BlogImageSmall = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    BlogOrder = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    BlogShortDescription = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    BlogDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogIsEnableForMainPage = table.Column<bool>(type: "bit", nullable: false),
                    BlogGroupId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogGroups_BlogGroupId",
                        column: x => x.BlogGroupId,
                        principalTable: "BlogGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductEnglishName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ProductImageMain = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    ProductImageSmall = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    ProductOrder = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    ProductShortDescription = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogGroups_BlogCategoryId",
                table: "BlogGroups",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogGroupId",
                table: "Blogs",
                column: "BlogGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FactorDetails_FactorMainId",
                table: "FactorDetails",
                column: "FactorMainId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CategoryId",
                table: "Groups",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupId",
                table: "Products",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertises");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "FactorDetails");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BlogGroups");

            migrationBuilder.DropTable(
                name: "FactorMain");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MsCategory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MsPayment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Number = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MsProduct",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MsShipment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsShipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MsUserProfile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    IdUser = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsUserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrCheckout",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    IdCheckoutPayment = table.Column<string>(type: "TEXT", nullable: true),
                    IdCheckoutShipment = table.Column<string>(type: "TEXT", nullable: true),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCheckout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MsProductCategory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    IdProduct = table.Column<string>(type: "TEXT", nullable: true),
                    IdCategory = table.Column<string>(type: "TEXT", nullable: true),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MsProductCategory_MsCategory_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "MsCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MsProductCategory_MsProduct_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "MsProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrBasket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    IdProduct = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrBasket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrBasket_MsProduct_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "MsProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MsUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    IdUserProfile = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Fullname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MsUser_MsUserProfile_IdUserProfile",
                        column: x => x.IdUserProfile,
                        principalTable: "MsUserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MsUserAddress",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    IdUserProfile = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    IsFavorit = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsUserAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MsUserAddress_MsUserProfile_IdUserProfile",
                        column: x => x.IdUserProfile,
                        principalTable: "MsUserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HsCheckoutPayment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    IdCheckout = table.Column<string>(type: "TEXT", nullable: true),
                    IdPayment = table.Column<string>(type: "TEXT", nullable: true),
                    Provider = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HsCheckoutPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HsCheckoutPayment_MsPayment_IdPayment",
                        column: x => x.IdPayment,
                        principalTable: "MsPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HsCheckoutPayment_TrCheckout_IdCheckout",
                        column: x => x.IdCheckout,
                        principalTable: "TrCheckout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HsCheckoutProductConf",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    IdCheckout = table.Column<string>(type: "TEXT", nullable: true),
                    IdProduct = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HsCheckoutProductConf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HsCheckoutProductConf_MsProduct_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "MsProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HsCheckoutProductConf_TrCheckout_IdCheckout",
                        column: x => x.IdCheckout,
                        principalTable: "TrCheckout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HsCheckoutShipment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    IdCheckout = table.Column<string>(type: "TEXT", nullable: true),
                    IdShipment = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    UserIn = table.Column<string>(type: "TEXT", nullable: true),
                    DateIn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserUp = table.Column<string>(type: "TEXT", nullable: true),
                    DateUp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HsCheckoutShipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HsCheckoutShipment_MsShipment_IdShipment",
                        column: x => x.IdShipment,
                        principalTable: "MsShipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HsCheckoutShipment_TrCheckout_IdShipment",
                        column: x => x.IdShipment,
                        principalTable: "TrCheckout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HsCheckoutPayment_IdCheckout",
                table: "HsCheckoutPayment",
                column: "IdCheckout",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HsCheckoutPayment_IdPayment",
                table: "HsCheckoutPayment",
                column: "IdPayment");

            migrationBuilder.CreateIndex(
                name: "IX_HsCheckoutPayment_IsActive",
                table: "HsCheckoutPayment",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_HsCheckoutProductConf_IdCheckout",
                table: "HsCheckoutProductConf",
                column: "IdCheckout");

            migrationBuilder.CreateIndex(
                name: "IX_HsCheckoutProductConf_IdProduct",
                table: "HsCheckoutProductConf",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_HsCheckoutProductConf_IsActive",
                table: "HsCheckoutProductConf",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_HsCheckoutShipment_IdShipment",
                table: "HsCheckoutShipment",
                column: "IdShipment",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HsCheckoutShipment_IsActive",
                table: "HsCheckoutShipment",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MsCategory_IsActive",
                table: "MsCategory",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MsPayment_IsActive",
                table: "MsPayment",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MsProduct_IsActive",
                table: "MsProduct",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MsProductCategory_IdCategory",
                table: "MsProductCategory",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_MsProductCategory_IdProduct",
                table: "MsProductCategory",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_MsProductCategory_IsActive",
                table: "MsProductCategory",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MsShipment_IsActive",
                table: "MsShipment",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MsUser_IdUserProfile",
                table: "MsUser",
                column: "IdUserProfile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MsUser_IsActive",
                table: "MsUser",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MsUser_Username",
                table: "MsUser",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MsUserAddress_IdUserProfile",
                table: "MsUserAddress",
                column: "IdUserProfile");

            migrationBuilder.CreateIndex(
                name: "IX_MsUserAddress_IsActive",
                table: "MsUserAddress",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MsUserProfile_IsActive",
                table: "MsUserProfile",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TrBasket_IdProduct",
                table: "TrBasket",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_TrBasket_IsActive",
                table: "TrBasket",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TrCheckout_IsActive",
                table: "TrCheckout",
                column: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HsCheckoutPayment");

            migrationBuilder.DropTable(
                name: "HsCheckoutProductConf");

            migrationBuilder.DropTable(
                name: "HsCheckoutShipment");

            migrationBuilder.DropTable(
                name: "MsProductCategory");

            migrationBuilder.DropTable(
                name: "MsUser");

            migrationBuilder.DropTable(
                name: "MsUserAddress");

            migrationBuilder.DropTable(
                name: "TrBasket");

            migrationBuilder.DropTable(
                name: "MsPayment");

            migrationBuilder.DropTable(
                name: "MsShipment");

            migrationBuilder.DropTable(
                name: "TrCheckout");

            migrationBuilder.DropTable(
                name: "MsCategory");

            migrationBuilder.DropTable(
                name: "MsUserProfile");

            migrationBuilder.DropTable(
                name: "MsProduct");
        }
    }
}

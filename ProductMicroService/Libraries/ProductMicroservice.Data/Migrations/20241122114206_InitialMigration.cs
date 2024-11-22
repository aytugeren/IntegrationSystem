using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductMicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPicture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PictureName = table.Column<string>(type: "text", nullable: false),
                    PictureUrl = table.Column<string>(type: "text", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    PictureAltName = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()"),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    LogMessage = table.Column<string>(type: "text", nullable: true, defaultValue: "Picture is added on 22-11-2024 11:42")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPicture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    VatRate = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductMainCode = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()"),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    LogMessage = table.Column<string>(type: "text", nullable: true, defaultValue: "Product is added on 22-11-2024 11:42")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProductVariant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductVariantName = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProductVariantCode = table.Column<string>(type: "text", nullable: false),
                    CargoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryDuration = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryOption = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()"),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    LogMessage = table.Column<string>(type: "text", nullable: true, defaultValue: "ProductVariant is added on 22-11-2024 11:42")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProductVariant_tblProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProductSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Barcode = table.Column<string>(type: "text", nullable: false),
                    SizeCode = table.Column<string>(type: "text", nullable: false),
                    ProductVariantId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()"),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    LogMessage = table.Column<string>(type: "text", nullable: true, defaultValue: "Product is added on 22-11-2024 11:42")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProductSize_tblProductVariant_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "tblProductVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProductVariantPicture",
                columns: table => new
                {
                    ProductVariantId = table.Column<Guid>(type: "uuid", nullable: false),
                    PictureId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductVariantPicture", x => new { x.ProductVariantId, x.PictureId });
                    table.ForeignKey(
                        name: "FK_tblProductVariantPicture_tblPicture_PictureId",
                        column: x => x.PictureId,
                        principalTable: "tblPicture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblProductVariantPicture_tblProductVariant_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "tblProductVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProductSizeRegion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductSizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()"),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    LogMessage = table.Column<string>(type: "text", nullable: true, defaultValue: "ProductSizeRegion is added on 22-11-2024 11:42")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductSizeRegion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProductSizeRegion_tblProductSize_ProductSizeId",
                        column: x => x.ProductSizeId,
                        principalTable: "tblProductSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProductSize_ProductVariantId",
                table: "tblProductSize",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductSizeRegion_ProductSizeId",
                table: "tblProductSizeRegion",
                column: "ProductSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductVariant_ProductId",
                table: "tblProductVariant",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductVariantPicture_PictureId",
                table: "tblProductVariantPicture",
                column: "PictureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductSizeRegion");

            migrationBuilder.DropTable(
                name: "tblProductVariantPicture");

            migrationBuilder.DropTable(
                name: "tblProductSize");

            migrationBuilder.DropTable(
                name: "tblPicture");

            migrationBuilder.DropTable(
                name: "tblProductVariant");

            migrationBuilder.DropTable(
                name: "tblProduct");
        }
    }
}

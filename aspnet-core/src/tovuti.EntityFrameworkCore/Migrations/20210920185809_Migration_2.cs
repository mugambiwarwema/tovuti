using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace tovuti.Migrations
{
    public partial class Migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tovuti_Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttributeName = table.Column<string>(type: "text", nullable: true),
                    AttributeDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tovuti_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tovuti_ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductTypeName = table.Column<string>(type: "text", nullable: true),
                    ProductTypeDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tovuti_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tovuti_AttributeValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttributeId = table.Column<int>(type: "integer", nullable: false),
                    ValueName = table.Column<string>(type: "text", nullable: true),
                    ValueDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tovuti_AttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tovuti_AttributeValues_tovuti_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "tovuti_Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tovuti_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    ProductDescription = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tovuti_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tovuti_Products_tovuti_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "tovuti_ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tovuti_ProductTypeAttributeValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    AttributeValueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tovuti_ProductTypeAttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tovuti_ProductTypeAttributeValues_tovuti_AttributeValues_At~",
                        column: x => x.AttributeValueId,
                        principalTable: "tovuti_AttributeValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tovuti_ProductTypeAttributeValues_tovuti_ProductTypes_Produ~",
                        column: x => x.ProductTypeId,
                        principalTable: "tovuti_ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tovuti_ProductAttributeValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttributeValueId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tovuti_ProductAttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tovuti_ProductAttributeValues_tovuti_AttributeValues_Attrib~",
                        column: x => x.AttributeValueId,
                        principalTable: "tovuti_AttributeValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tovuti_ProductAttributeValues_tovuti_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tovuti_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tovuti_AttributeValues_AttributeId",
                table: "tovuti_AttributeValues",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_tovuti_ProductAttributeValues_AttributeValueId",
                table: "tovuti_ProductAttributeValues",
                column: "AttributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_tovuti_ProductAttributeValues_ProductId",
                table: "tovuti_ProductAttributeValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tovuti_Products_ProductTypeId",
                table: "tovuti_Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tovuti_ProductTypeAttributeValues_AttributeValueId",
                table: "tovuti_ProductTypeAttributeValues",
                column: "AttributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_tovuti_ProductTypeAttributeValues_ProductTypeId",
                table: "tovuti_ProductTypeAttributeValues",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tovuti_ProductAttributeValues");

            migrationBuilder.DropTable(
                name: "tovuti_ProductTypeAttributeValues");

            migrationBuilder.DropTable(
                name: "tovuti_Products");

            migrationBuilder.DropTable(
                name: "tovuti_AttributeValues");

            migrationBuilder.DropTable(
                name: "tovuti_ProductTypes");

            migrationBuilder.DropTable(
                name: "tovuti_Attributes");
        }
    }
}

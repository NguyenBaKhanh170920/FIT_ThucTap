using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CategoryName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryId", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderCode = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    OrderDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TotalPrice = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    seller = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Paid = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Sale = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCode", x => x.OrderCode);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ProductCode = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OrderCode = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NumberProduct = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalPrice = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Sale = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailId", x => x.OrderDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductCode = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProductName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Image = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cost = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RentailPrice = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Inventory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Unit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CategoryId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TradekMarkId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCode", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Paid = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Deposit = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Unpaid = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierCode = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierCode", x => x.SupplierCode);
                });

            migrationBuilder.CreateTable(
                name: "TradeMark",
                columns: table => new
                {
                    TradeMarkId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TradeMarkName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeMarkId", x => x.TradeMarkId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "TradeMark");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACarApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Admin",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: false),
            //        name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        lastname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        password = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
            //        created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Admin", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Dealership",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        phone = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Dealership", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FuelType",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        type = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FuelType", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GearType",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_GearType", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PaymentMethod",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        type = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PaymentMethod", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PaymentStatus",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        is_successful = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PaymentStatus", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ReservationStatus",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ReservationStatus", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "User",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: false),
            //        name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        lastname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        birth_date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        password = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
            //        phone_number = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
            //        license_number = table.Column<string>(type: "char(6)", unicode: false, fixedLength: true, maxLength: 6, nullable: false),
            //        address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_User", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Car",
            //    columns: table => new
            //    {
            //        vin_number = table.Column<string>(type: "char(17)", unicode: false, fixedLength: true, maxLength: 17, nullable: false),
            //        brand = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        model = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        year = table.Column<short>(type: "smallint", nullable: false),
            //        fuel_type = table.Column<int>(type: "int", nullable: false),
            //        gear_type = table.Column<int>(type: "int", nullable: false),
            //        license_plate = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
            //        seat_count = table.Column<byte>(type: "tinyint", nullable: false),
            //        price_per_day = table.Column<double>(type: "float", nullable: false),
            //        availability_status = table.Column<bool>(type: "bit", nullable: false),
            //        created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
            //        min_age = table.Column<byte>(type: "tinyint", nullable: false),
            //        kilometer = table.Column<int>(type: "int", nullable: false),
            //        dealership_id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Car", x => x.vin_number);
            //        table.ForeignKey(
            //            name: "FK_Car_Dealership",
            //            column: x => x.dealership_id,
            //            principalTable: "Dealership",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK_Car_FuelType",
            //            column: x => x.fuel_type,
            //            principalTable: "FuelType",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK_Car_GearType",
            //            column: x => x.gear_type,
            //            principalTable: "GearType",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Log",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        user_id = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true),
            //        admin_id = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true),
            //        messaage = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Log", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Log_Admin",
            //            column: x => x.admin_id,
            //            principalTable: "Admin",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK_Log_User",
            //            column: x => x.user_id,
            //            principalTable: "User",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Deleted",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        car_id = table.Column<string>(type: "char(17)", unicode: false, fixedLength: true, maxLength: 17, nullable: false),
            //        delete_time = table.Column<DateTime>(type: "datetime", nullable: true),
            //        admin_id = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Deleted", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Deleted_Admin",
            //            column: x => x.admin_id,
            //            principalTable: "Admin",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK_Deleted_Car",
            //            column: x => x.car_id,
            //            principalTable: "Car",
            //            principalColumn: "vin_number");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Reservation",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        user_id = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: false),
            //        car_id = table.Column<string>(type: "char(17)", unicode: false, fixedLength: true, maxLength: 17, nullable: false),
            //        start_date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        end_date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        total_price = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
            //        status = table.Column<int>(type: "int", nullable: false),
            //        created_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        updated_date = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Reservation", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Reservation_Car",
            //            column: x => x.car_id,
            //            principalTable: "Car",
            //            principalColumn: "vin_number");
            //        table.ForeignKey(
            //            name: "FK_Reservation_ReservationStatus",
            //            column: x => x.status,
            //            principalTable: "ReservationStatus",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK_Reservation_User",
            //            column: x => x.user_id,
            //            principalTable: "User",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Payment",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        reservation_id = table.Column<int>(type: "int", nullable: false),
            //        amount = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
            //        payment_method = table.Column<int>(type: "int", nullable: false),
            //        payment_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        payment_status = table.Column<int>(type: "int", nullable: false),
            //        created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Payment", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Payment_PaymentMethod",
            //            column: x => x.payment_method,
            //            principalTable: "PaymentMethod",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK_Payment_PaymentStatus",
            //            column: x => x.payment_status,
            //            principalTable: "PaymentStatus",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK_Payment_Reservation",
            //            column: x => x.reservation_id,
            //            principalTable: "Reservation",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Car_dealership_id",
            //    table: "Car",
            //    column: "dealership_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Car_fuel_type",
            //    table: "Car",
            //    column: "fuel_type");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Car_gear_type",
            //    table: "Car",
            //    column: "gear_type");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Deleted_admin_id",
            //    table: "Deleted",
            //    column: "admin_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Deleted_car_id",
            //    table: "Deleted",
            //    column: "car_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Log_admin_id",
            //    table: "Log",
            //    column: "admin_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Log_user_id",
            //    table: "Log",
            //    column: "user_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payment_payment_method",
            //    table: "Payment",
            //    column: "payment_method");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payment_payment_status",
            //    table: "Payment",
            //    column: "payment_status");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payment_reservation_id",
            //    table: "Payment",
            //    column: "reservation_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reservation_car_id",
            //    table: "Reservation",
            //    column: "car_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reservation_status",
            //    table: "Reservation",
            //    column: "status");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reservation_user_id",
            //    table: "Reservation",
            //    column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deleted");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "ReservationStatus");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Dealership");

            migrationBuilder.DropTable(
                name: "FuelType");

            migrationBuilder.DropTable(
                name: "GearType");
        }
    }
}

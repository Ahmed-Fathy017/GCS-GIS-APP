using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace SQL_App.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Polygons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<Polygon>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polygons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Polygons",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((35.191766965947394 53.37158203124999, 33.02708758002874 51.21826171875, 33.44977658311846 55.06347656249999, 35.191766965947394 53.37158203124999))"), "Polygon01" },
                    { 2, (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((38.70265930723801 57.74414062500001, 37.09023980307208 57.568359375, 37.49229399862877 60.13916015625, 38.70265930723801 57.74414062500001))"), "Polygon02" },
                    { 3, (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((34.415973384481866 57.39257812499999, 31.89621446335144 55.37109374999999, 32.45415593941475 58.68896484375, 34.415973384481866 57.39257812499999))"), "Polygon03" },
                    { 4, (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((30.65681556429287 56.42578125, 28.70986084394286 53.72314453125, 30.164126343161097 59.19433593750001, 30.65681556429287 56.42578125))"), "Polygon04" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polygons");
        }
    }
}

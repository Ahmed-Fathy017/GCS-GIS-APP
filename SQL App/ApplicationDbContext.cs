using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQL_App
{
    class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SpatialDB;User ID=sa;Password=123@qwe;",
                x => x.UseNetTopologySuite())
                .UseLoggerFactory(MyLoggerFactory);
            base.OnConfiguring(optionsBuilder);

            //DESKTOP-RIIUMOL
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) =>
            category == DbLoggerCategory.Database.Name
            && level == LogLevel.Information)
            .AddConsole();
        });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            modelBuilder.Entity<PolygonShape>()
                .HasData(new List<PolygonShape>()
                {
                    new PolygonShape(){Id = 1, Name = "Polygon01", Location = geometryFactory.CreatePolygon(new LinearRing(new Coordinate[]
                    {
                        new Coordinate(35.191766965947394, 53.37158203124999),
                        new Coordinate(33.02708758002874, 51.21826171875),
                        new Coordinate(33.44977658311846,55.06347656249999),
                        new Coordinate(35.191766965947394, 53.37158203124999),
                    }))},

                    new PolygonShape(){Id = 2, Name = "Polygon02", Location = geometryFactory.CreatePolygon(new LinearRing(new Coordinate[]
                    {
                        new Coordinate(38.70265930723801 ,57.74414062500001),
                        new Coordinate(37.09023980307208,57.568359375),
                        new Coordinate(37.49229399862877,60.13916015625),
                        new Coordinate(38.70265930723801 ,57.74414062500001),
                        
                    }))},

                    new PolygonShape(){Id = 3, Name = "Polygon03", Location = geometryFactory.CreatePolygon(new LinearRing(new Coordinate[]
                    {
                        new Coordinate(34.415973384481866,57.39257812499999),
                        new Coordinate(31.89621446335144,55.37109374999999),
                        new Coordinate(32.45415593941475,58.68896484375),
                        new Coordinate(34.415973384481866,57.39257812499999),
                    }))},

                    new PolygonShape(){Id = 4, Name = "Polygon04", Location = geometryFactory.CreatePolygon(new LinearRing(new Coordinate[]
                    {
                        new Coordinate(30.65681556429287,56.42578125),
                        new Coordinate(28.70986084394286,53.72314453125),
                        new Coordinate(30.164126343161097,59.19433593750001),
                        new Coordinate(30.65681556429287,56.42578125),
                    }))}
                });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PolygonShape> Polygons {get; set;}
        //public DbSet<pointShapes> Points { get; set; }
    }
}

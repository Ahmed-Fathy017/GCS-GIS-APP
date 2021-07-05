using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace SQL_App
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new ApplicationDbContext())
            {
                //Reversal points code test
                //Console.WriteLine("not reversed" + newPolygon.Location);

                //newPolygon.Location = (Polygon)newPolygon.Location.Reverse();

                //Console.WriteLine("reversed" + newPolygon.Location);

                //Creatind and adding polygons to the database
                //var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

                //for (int i = 0; i < 998000; i++)
                //{


                //    var newPolygon = new PolygonShape()
                //    {
                //        Name = $"Polygon0{i}",
                //        Location = geometryFactory.CreatePolygon(new LinearRing(new Coordinate[]
                //    {
                //        new Coordinate(38.70265930723801 ,57.74414062500001),
                //        new Coordinate(37.09023980307208,57.568359375),
                //        new Coordinate(37.49229399862877,60.13916015625),
                //        new Coordinate(38.70265930723801 ,57.74414062500001),
                //    }))
                //    };

                //    newPolygon.Location = (Polygon)newPolygon.Location.Reverse();

                //    context.Polygons.Add(newPolygon);
                //}

                //for (int i = 10000; i < 20000; i++)
                //{
                //    var newPolygon = new PolygonShape()
                //    {
                //        Name = $"Polygon0{i}",
                //        Location = geometryFactory.CreatePolygon(new LinearRing(new Coordinate[]
                //    {
                //        new Coordinate(35.191766965947394, 53.37158203124999),
                //        new Coordinate(33.02708758002874, 51.21826171875),
                //        new Coordinate(33.44977658311846, 55.06347656249999),
                //        new Coordinate(35.191766965947394, 53.37158203124999),
                //    }))
                //    };

                //    newPolygon.Location = (Polygon)newPolygon.Location.Reverse();

                //    context.Polygons.Add(newPolygon);
                //}

                //context.SaveChanges();

                //Console.WriteLine("done with adding 1000000 record");


                //Testing retrieval intersection query speed

                Console.WriteLine(DateTime.Now);
                //Timer timer = new Timer(1000);
                //timer.Elapsed += Timer_Elapsed;
                //timer.Start();
                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

                var myPoint = geometryFactory.CreatePoint(new Coordinate(34.10725639663118, 53.349609375));

                for (int i = 0; i < 1000; i++)
                {
                    var intersectedPolygons = context.Polygons.Where(pol => pol.Location.Intersects(myPoint)).ToList();
                }

                Console.WriteLine("finished");
                Console.WriteLine(DateTime.Now);
                //timer.Stop();
                //Console.WriteLine(timer);

            }
        }

        //private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
           
        //}
    }
}

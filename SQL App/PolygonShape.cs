using System;
using System.Collections.Generic;
using System.Text;
using NetTopologySuite.Geometries;

namespace SQL_App
{
    public class PolygonShape
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Polygon Location { get; set; }
    }
}

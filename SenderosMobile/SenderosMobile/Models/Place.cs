using System;
using System.Collections.Generic;
using System.Text;

namespace SenderosMobile
{
    class Place
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PlaceImage { get; set; }
        public int Grade { get; set; }
        public int Visits { get; set; }
    }
}

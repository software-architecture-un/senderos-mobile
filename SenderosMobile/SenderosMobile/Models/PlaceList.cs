using System;
using System.Collections.Generic;
using System.Text;

namespace SenderosMobile
{
    class PlaceList
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int OwnerUser { get; set; }
        public string Comment { get; set; }
        public List<Place> Places { get; set; }
        public string EstimatedDate { get; set; }
        public int Order { get; set; }
        public int NumberPlaces { get; set; }
    }
}

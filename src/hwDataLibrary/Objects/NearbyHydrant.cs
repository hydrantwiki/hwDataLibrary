using System;
using TreeGecko.Library.Geospatial.Objects;

namespace HydrantWiki.Library.Objects
{
    public class NearbyHydrant
    {
        public Guid HydrantGuid { get; set; }

        public string HydrantImageUrl { get; set; }

        public string DistanceInFeet { get; set; }

        public GeoPoint Position { get; set; }
    }
}

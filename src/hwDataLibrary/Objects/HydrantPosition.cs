using System;
using TreeGecko.Library.Geospatial.Objects;

namespace HydrantWiki.Library.Objects
{
    public class HydrantPosition
    {
        public Guid HydrantGuid { get; set; }
        public GeoPoint Position { get; set; }
    }
}

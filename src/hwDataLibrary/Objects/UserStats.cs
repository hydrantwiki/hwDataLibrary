using System;
using TreeGecko.Library.Common.Objects;

namespace HydrantWiki.Library.Objects
{
    public class UserStats : AbstractTGObject 
    {
        public Guid UserGuid { get; set; }

        public int TagCount { get; set; }

        public int ActiveTagCount { get; set; }

        public int HydrantCount { get; set; }

        public override TGSerializedObject GetTGSerializedObject()
        {
            TGSerializedObject tgs = base.GetTGSerializedObject();

            tgs.Add("UserGuid", UserGuid);
            tgs.Add("TagCount", TagCount);
            tgs.Add("ActiveTagCount", ActiveTagCount);
            tgs.Add("HydrantCount", HydrantCount);

            return tgs;                
        }

        public override void LoadFromTGSerializedObject(TGSerializedObject _tgs)
        {
            base.LoadFromTGSerializedObject(_tgs);

            UserGuid = _tgs.GetGuid("UserGuid");
            TagCount = _tgs.GetInt32("TagCount");
            ActiveTagCount = _tgs.GetInt32("ActiveTagCount");
            HydrantCount = _tgs.GetInt32("HydrantCount");
        }

        public override string ToString()
        {
            TGSerializedObject obj = GetTGSerializedObject();

            return obj.ToString();
        }
    }
}

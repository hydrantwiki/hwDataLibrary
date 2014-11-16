using System;
using TreeGecko.Library.Common.Objects;
using TreeGecko.Library.Net.Objects;

namespace HydrantWiki.Library.Objects
{
    public class SystemEmail : TGEmail
    {
        public SystemEmail()
        {
            SentDateTime = DateTime.UtcNow;
        }

        public SystemEmail(Guid _cannedEmailGuid)
        {
            SentDateTime = DateTime.UtcNow;
            CannedEmailGuid = _cannedEmailGuid;
        }

        public SystemEmail(DateTime _sendDateTime, Guid _cannedEmailGuid)
        {
            SentDateTime = _sendDateTime;
            CannedEmailGuid = _cannedEmailGuid;
        }

        public DateTime SentDateTime { get; set; }
        public Guid CannedEmailGuid { get; set; }

        public override TGSerializedObject GetTGSerializedObject()
        {
            TGSerializedObject tgs = base.GetTGSerializedObject();

            tgs.Add("CannedEmailGuid", CannedEmailGuid);
            tgs.Add("SentDateTime", SentDateTime);

            return tgs;
        }

        public override void LoadFromTGSerializedObject(TGSerializedObject _tgs)
        {
            base.LoadFromTGSerializedObject(_tgs);

            CannedEmailGuid = _tgs.GetGuid("CannedEmailGuid");
            SentDateTime = _tgs.GetDateTime("SentDateTime");
        }
    }
}

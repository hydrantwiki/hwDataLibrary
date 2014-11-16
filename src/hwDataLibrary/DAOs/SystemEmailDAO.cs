using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HydrantWiki.Library.Objects;
using MongoDB.Driver;
using TreeGecko.Library.Mongo.DAOs;

namespace HydrantWiki.Library.DAOs
{
    public class SystemEmailDAO : AbstractMongoDAO<SystemEmail>
    {
        public SystemEmailDAO(MongoDatabase _mongoDB)
            : base(_mongoDB)
        {
            HasParent = false;
        }

        public override string TableName
        {
            get { return "SystemEmail"; }
        }

        public override void BuildTable()
        {
            base.BuildTable();

            BuildNonuniqueIndex("SentDateTime", "SENT");
        }
    }
}

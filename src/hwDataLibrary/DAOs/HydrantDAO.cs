using HydrantWiki.Library.Objects;
using MongoDB.Driver;
using TreeGecko.Library.Mongo.DAOs;

namespace HydrantWiki.Library.DAOs
{
    internal class HydrantDAO: AbstractMongoDAO<Hydrant>
    {
        public HydrantDAO(MongoDatabase _mongoDB)
            : base(_mongoDB)
        {
        }

        public override string TableName
        {
            get { return "Hydrant"; }
        }

        public override void BuildTable()
        {
            base.BuildTable();
        }
    }
}

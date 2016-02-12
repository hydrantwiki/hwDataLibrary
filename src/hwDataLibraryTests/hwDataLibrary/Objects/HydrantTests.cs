using System;
using HydrantWiki.Library.Constants;
using HydrantWiki.Library.Objects;
using NUnit.Framework;
using TreeGecko.Library.Common.Objects;
using TreeGecko.Library.Geospatial.Objects;

namespace hwDataLibraryTests.hwDataLibrary.Objects
{
    [TestFixture]
    public class HydrantTests
    {
        [Test]
        public void SerializeTest()
        {
            GeoPoint pos = new GeoPoint(-100, 45);

            Hydrant hydrant = new Hydrant
            {
                Active = true,
                CreationDateTime = DateTime.Now,
                Guid = Guid.NewGuid(),
                LastModifiedBy = Guid.NewGuid(),
                LastModifiedDateTime = DateTime.Now,
                LastReviewerUserGuid = Guid.NewGuid(),
                OriginalReviewerUserGuid = Guid.NewGuid(),
                OriginalTagDateTime = DateTime.Now,
                OriginalTagUserGuid = Guid.NewGuid(),
                PersistedDateTime = DateTime.Now,
                Position = pos,
                PrimaryImageGuid = Guid.NewGuid()
            };


            TGSerializedObject tgs = hydrant.GetTGSerializedObject();
            Hydrant newHydrant = TGSerializedObject.GetTGSerializable<Hydrant>(tgs);

            Assert.AreEqual(hydrant.Active, newHydrant.Active);
            Assert.AreEqual(hydrant.CreationDateTime, newHydrant.CreationDateTime);
            Assert.AreEqual(hydrant.LastModifiedBy, newHydrant.LastModifiedBy);
            Assert.AreEqual(hydrant.LastModifiedDateTime, newHydrant.LastModifiedDateTime);
            Assert.AreEqual(hydrant.Guid, newHydrant.Guid);
            Assert.AreEqual(hydrant.LastReviewerUserGuid, newHydrant.LastReviewerUserGuid);
            Assert.AreEqual(hydrant.OriginalReviewerUserGuid, newHydrant.OriginalReviewerUserGuid);
            Assert.AreEqual(hydrant.OriginalTagDateTime, newHydrant.OriginalTagDateTime);
            Assert.AreEqual(hydrant.OriginalTagUserGuid, newHydrant.OriginalTagUserGuid);
            Assert.AreEqual(hydrant.PersistedDateTime, newHydrant.PersistedDateTime);
            Assert.AreEqual(hydrant.PrimaryImageGuid, newHydrant.PrimaryImageGuid);

            Assert.IsNotNull(newHydrant.Position);
            Assert.AreEqual(hydrant.Position.X, newHydrant.Position.X);
            Assert.AreEqual(hydrant.Position.Y, newHydrant.Position.Y);
        }

    }
}

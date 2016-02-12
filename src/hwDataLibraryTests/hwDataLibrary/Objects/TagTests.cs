using System;
using HydrantWiki.Library.Constants;
using HydrantWiki.Library.Objects;
using NUnit.Framework;
using TreeGecko.Library.Common.Objects;
using TreeGecko.Library.Geospatial.Objects;

namespace hwDataLibraryTests.hwDataLibrary.Objects
{
    [TestFixture]
    public class TagTests
    {
        [OneTimeSetUp]
        public void TestSetup()
        {

        }

        [Test]
        public void SerializeTest()
        {
            GeoPoint pos = new GeoPoint(-100, 45);

            Tag tag = new Tag
            {
                Active = true,
                DeviceDateTime = DateTime.Now.ToUniversalTime(),
                ExternalIdentifier = Guid.NewGuid().ToString(),
                ExternalSource = "TestSource",
                Guid = Guid.NewGuid(),
                HydrantGuid = Guid.NewGuid(),
                Position = pos,
                TagType = TagTypes.ExistingHydrant,
                Status = TagStatus.Pending,
                ImageGuid = Guid.NewGuid()
            };

            TGSerializedObject tgs = tag.GetTGSerializedObject();
            Tag newTag = TGSerializedObject.GetTGSerializable<Tag>(tgs);

            Assert.AreEqual(tag.Active, newTag.Active);
            Assert.AreEqual(tag.DeviceDateTime, newTag.DeviceDateTime);
            Assert.AreEqual(tag.ExternalIdentifier, newTag.ExternalIdentifier);
            Assert.AreEqual(tag.ExternalSource, newTag.ExternalSource);
            Assert.AreEqual(tag.Guid, newTag.Guid);
            Assert.AreEqual(tag.HydrantGuid, newTag.HydrantGuid);
            Assert.AreEqual(tag.ImageGuid, newTag.ImageGuid);
            Assert.AreEqual(tag.UserGuid, newTag.UserGuid);
            Assert.AreEqual(tag.TagType, newTag.TagType);
            Assert.AreEqual(tag.Status, newTag.Status);

            Assert.IsNotNull(newTag.Position);
            Assert.AreEqual(tag.Position.X, newTag.Position.X);
            Assert.AreEqual(tag.Position.Y, newTag.Position.Y);
        }
    }
}

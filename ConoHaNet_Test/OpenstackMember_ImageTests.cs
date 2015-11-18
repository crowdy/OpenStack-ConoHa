namespace ConoHaNet_Test
{
    using ConoHaNet;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class OpenstackMember_ImageTests : OpenstackMemberTestBase
    {

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
        }

        [TestInitialize()]
        public void Initialize()
        {
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        [TestMethod()]
        public void GetImageApiEndPointTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            Assert.IsNotNull(os.ImagesProvider);
        }

        #region "images"

        [TestMethod()]
        public void ListGlanceImagesTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var images = os.ListGlanceImages();
            Assert.IsNotNull(images);
        }

        [TestMethod()]
        public void GetGlanceImageTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var images = os.ListGlanceImages();
            Assert.IsNotNull(images);
            foreach (var i in images)
            {
                var image = os.GetGlanceImage(i.Id);
                Assert.IsNotNull(image);

            }
        }

        [TestMethod(), Ignore]
        public void DeleteImageTest()
        {
            string imageId = string.Empty;
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            bool b = os.DeleteGlanceImage(imageId);
        }

        #endregion

    }
}
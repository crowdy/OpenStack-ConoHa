namespace ConoHaNet_Test
{
    using ConoHaNet;
    using ConoHaNet.Objects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass()]
    public class OpenstackMember_BlockStorageTests : OpenstackMemberTestBase
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
        public void GetBlockStorageApiEndPointTest()
        {
            
        }


        #region "types"

        [TestMethod()]
        public void ListVolumeTypesTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId); // with tenant
            var types = os.ListVolumeTypes();
            Assert.IsNotNull(types);
        }

        [TestMethod()]
        public void GetVolumeTypeTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId); // with tenant
            var types = os.ListVolumeTypes();
            Assert.IsNotNull(types);
            foreach (var t in types)
            {
                var type = os.GetVolumeType(t.Id);
                Assert.IsNotNull(t);
            }
        }

        #endregion


        #region "volumes"

        [TestMethod()]
        public void ListVolumesTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId); // with tenant
            var volumes = os.ListVolumes();
            Assert.IsNotNull(volumes);
        }

        [TestMethod()]
        public void ListVolumesDetailsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId); // with tenant
            var volumes = os.ListVolumesDetails();
            Assert.IsNotNull(volumes);
        }

        [TestMethod()]
        public void GetVolumeTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId); // with tenant
            var volumes = os.ListVolumesDetails();
            Assert.IsNotNull(volumes);
            foreach (var v in volumes)
            {
                Assert.IsNotNull(v);
            }
        }

        [TestMethod()]
        public void CreateVolumeTest()
        {
            int size = 200;

            var os = new OpenStackMember(UserName, Password, TenantName, TenantId); // with tenant
            var v = os.CreateVolume(size, name:"testVolume");
            Assert.IsNotNull(v);

            os.WaitForVolumeAvailable(v.Id);

            bool b = os.DeleteVolume(v.Id);
            Assert.IsTrue(b);
        }

        [TestMethod()]
        public void DeleteVolumeTest()
        {
            CreateVolumeTest();
        }

        #endregion

        public Volume GetVolumeByName(string name)
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId); // with tenant
            var volumes = os.ListVolumes();
            if (volumes != null)
                return volumes.First<Volume>();
            else
                throw new ArgumentException("no item found");
        }

    }
}
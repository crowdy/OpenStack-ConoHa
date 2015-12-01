using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rackspace.Services.Identity.V2;
using System.Threading;
using OpenStack.Services.Identity;
using System.Threading.Tasks;

namespace ConoHaNet.portable_net45_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Test_ListApiVersions()
        {

            using (CancellationTokenSource cancellationTokenSource = new CancellationTokenSource())
            {
                IBaseIdentityService client = new ConoHaIdentityClient(new Uri("https://identity.tyo1.conoha.io/"));
                // test using the simple extension method
                var versions = await client.ListApiVersionsAsync(cancellationTokenSource.Token);
                Assert.IsNotNull(versions);
                Assert.AreNotEqual(0, versions.Count);
                Assert.IsFalse(versions.CanHaveNextPage);
                Assert.IsFalse(versions.Contains(null));
            }

        }
    }
}

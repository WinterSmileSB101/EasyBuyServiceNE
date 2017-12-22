
using NUnit.Framework;
using Easybuyservicene.Service.Dtos;
using Easybuyservicene.Service.Services;

namespace Easybuyservicene.Test
{
    [TestFixture]
    public class VersionServiceTest
    {
        VersionService service = null;

        [SetUp]
        public void Setup()
        {
            service = new VersionService();
        }

        [Test]
        public void TestOnBeforeExecute()
        {
           Version version = service.OnGet(null) as Version;
           Assert.IsNotNull(version);
           Assert.AreEqual("1.0.0.0", version.No);
        }
    }
}

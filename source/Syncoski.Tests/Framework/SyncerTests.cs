using System.Transactions;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Syncoski.Framework;

namespace Syncoski.Tests.Framework
{

    [TestFixture]
    public class SyncerTests
    {

        [TestCase(@"C:\Users\jose.cordero\Dropbox")]
        public void Start_PassedPath(string path)
        {
            var fixture = CompositionRoot.FixtureInstance;
            var syncer = fixture.Create<Syncer>();

            syncer.Start(path);
        }

    }

}

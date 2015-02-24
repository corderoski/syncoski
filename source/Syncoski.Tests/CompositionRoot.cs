using System;
using Ploeh.AutoFixture;

namespace Syncoski.Tests
{
    public class CompositionRoot
    {

        internal static IFixture FixtureInstance
        {
            get
            {
                var fix = new Fixture();//.Customize(new Ploeh.AutoFixture.AutoMoq.AutoMoqCustomization());
                fix.Behaviors.Remove(new ThrowingRecursionBehavior());
                fix.Behaviors.Add(new OmitOnRecursionBehavior());
                return fix;
            }
        }

    }
}

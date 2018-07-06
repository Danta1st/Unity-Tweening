using NUnit.Framework;
using Tweening.Updatable;

namespace Tweening.Test.Editor
{
    [TestFixture]
    public class TweenerTests
    {
        private IUpdateInvoker updateInvoker;
        
        [SetUp]
        public void Setup()
        {
            updateInvoker = UpdateInvokerFactory.GetDefault();
        }

        [TearDown]
        public void TearDown()
        {
            updateInvoker = null;
        }
        
        //TODO: Establish tests for tweeners
    }
}
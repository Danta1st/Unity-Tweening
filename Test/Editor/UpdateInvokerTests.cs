using NUnit.Framework;
using Tweening.Updatable;

namespace Tweening.Test.Editor
{
    [TestFixture]
    public class UpdateInvokerTests
    {
        private class Updatable : IUpdatable
        {
            public int UpdateCount;

            public void Update()
            {
                UpdateCount++;
            }
        }

        private IUpdateInvoker updateInvoker;
        private Updatable updatable;

        [SetUp]
        public void Setup()
        {
            updateInvoker = new UpdateInvoker();
            updatable = new Updatable();
        }

        [TearDown]
        public void TearDown()
        {
            updateInvoker = null;
            updatable = null;
        }
        

        [Test]
        public void Updater_Updates_Object()
        {
            updateInvoker.Add(updatable);
            updateInvoker.Update();
            
            Assert.AreEqual(1, updatable.UpdateCount);
        }
        
        [Test]
        public void Updater_DoesNotFail_OnNulledObject()
        {
            updateInvoker.Add(updatable);
            updatable = null;
            updateInvoker.Update();
        }
    }
}
using NUnit.Framework;
using Tweening.Updatable;

namespace Tweening.Test.Editor
{
    [TestFixture]
    public class UpdateInvokerTests
    {
        private class MockUpdatable : IUpdatable
        {
            public int UpdateCount;

            public void Update(float deltaTime)
            {
                UpdateCount++;
            }
        }

        private IUpdateInvoker updateInvoker;
        private MockUpdatable mockUpdatable;

        [SetUp]
        public void Setup()
        {
            updateInvoker = new UpdateInvoker();
            mockUpdatable = new MockUpdatable();
        }

        [TearDown]
        public void TearDown()
        {
            updateInvoker = null;
            mockUpdatable = null;
        }
        

        [Test]
        public void Updater_Updates_Object()
        {
            updateInvoker.Add(mockUpdatable);
            updateInvoker.Update();
            
            Assert.AreEqual(1, mockUpdatable.UpdateCount);
        }
        
        [Test]
        public void Updater_DoesNotFail_OnNulledObject()
        {
            updateInvoker.Add(mockUpdatable);
            mockUpdatable = null;
            updateInvoker.Update();
        }
    }
}
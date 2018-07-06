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
            mockUpdatable = new MockUpdatable();
            updateInvoker = new UpdateInvoker();
        }

        [TearDown]
        public void TearDown()
        {
            updateInvoker = null;
            mockUpdatable = null;
        }
        

        [Test]
        public void Add_StartsInvication_Immediately()
        {
            updateInvoker.Add(mockUpdatable);
            updateInvoker.Update();
            
            Assert.AreEqual(1, mockUpdatable.UpdateCount);
        }
        
        [Test]
        public void Remove_StopsInvocation_Immediately()
        {
            updateInvoker.Add(mockUpdatable);
            updateInvoker.Update();
            
            updateInvoker.Remove(mockUpdatable);
            updateInvoker.Update();
            
            Assert.AreEqual(1, mockUpdatable.UpdateCount);
        }

        [Test]
        public void Remove_NotAddedItem_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() =>
            {
                updateInvoker.Remove(mockUpdatable);
                updateInvoker.Update();
            });
        }

        
        [Test]
        public void MultipleAdd_IsOnlyInvokedOnce()
        {
            updateInvoker.Add(mockUpdatable);
            updateInvoker.Add(mockUpdatable);
            updateInvoker.Update();
            
            Assert.AreEqual(1, mockUpdatable.UpdateCount);
            
            updateInvoker.Add(mockUpdatable);
            updateInvoker.Update();
            
            Assert.AreEqual(2, mockUpdatable.UpdateCount);
        }
        
        
        [Test]
        public void MultipleRemove_IsNotInvoked()
        {
            updateInvoker.Add(mockUpdatable);
            updateInvoker.Update();
            
            //Ensure the added object is in the update queue
            Assert.AreEqual(1, mockUpdatable.UpdateCount);
            
            updateInvoker.Remove(mockUpdatable);
            updateInvoker.Remove(mockUpdatable);
            updateInvoker.Update();
            
            Assert.AreEqual(1, mockUpdatable.UpdateCount);
        }
        
        [Test]
        public void AddRemove_WithinSameFrame_DoesNotCauseInvocation()
        {
            updateInvoker.Add(mockUpdatable);
            updateInvoker.Remove(mockUpdatable);
            updateInvoker.Update();
            
            Assert.AreEqual(0, mockUpdatable.UpdateCount);
        }
        
        [Test]
        public void RemoveAdd_WithinSameFrame_DoesCauseInvocation()
        {
            updateInvoker.Remove(mockUpdatable);
            updateInvoker.Add(mockUpdatable);
            updateInvoker.Update();
            
            Assert.AreEqual(1, mockUpdatable.UpdateCount);
            
            updateInvoker.Update();
            
            Assert.AreEqual(2, mockUpdatable.UpdateCount);
        }
        
    }
}
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Assembly-CSharp-Editor")]
namespace Tweening.Updatable
{
    internal sealed class UpdateInvoker : IUpdateInvoker
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        private readonly List<IUpdatable> updatables = new List<IUpdatable>();

        private readonly Queue<IUpdatable> addQueue = new Queue<IUpdatable>();
        private readonly Queue<IUpdatable> removeQueue = new Queue<IUpdatable>();


        public void Add(IUpdatable updatable)
        {
            if(addQueue.Contains(updatable))
                return;
            
            addQueue.Enqueue(updatable);
        }

        public void Remove(IUpdatable updatable)
        {
            if(removeQueue.Contains(updatable))
                return;
            
            removeQueue.Enqueue(updatable);
        }
        
        public void Update()
        {
            ExpediteRemoveRequests();
            
            ExpediteAddRequests();

            InvokeUpdateCalls();
        }

        private void ExpediteAddRequests()
        {
            foreach (var updatable in addQueue)
            {
                if (updatables.Contains(updatable))
                    continue;

                updatables.Add(updatable);
            }

            addQueue.Clear();
        }

        private void ExpediteRemoveRequests()
        {
            foreach (var updatable in removeQueue)
            {
                if(!updatables.Contains(updatable))
                    continue;
                
                updatables.Remove(updatable);
            }
            
            removeQueue.Clear();
        }

        private void InvokeUpdateCalls()
        {
            var deltaTime = stopwatch.ElapsedMilliseconds * 0.001f;
            foreach (var updatable in updatables)
            {
                if (updatable == null)
                    continue;

                updatable.Update(deltaTime);
            }

            stopwatch.Reset();
            stopwatch.Start();
        }
    }
}
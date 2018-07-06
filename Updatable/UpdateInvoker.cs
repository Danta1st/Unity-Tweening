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

        private readonly List<IUpdatable> addQueue = new List<IUpdatable>();
        private readonly List<IUpdatable> removeQueue = new List<IUpdatable>();


        public void Add(IUpdatable updatable)
        {
            if(addQueue.Contains(updatable))
                return;

            if (removeQueue.Contains(updatable))
                removeQueue.Remove(updatable);
            
            addQueue.Add(updatable);
        }

        public void Remove(IUpdatable updatable)
        {
            if(removeQueue.Contains(updatable))
                return;

            if (addQueue.Contains(updatable))
                addQueue.Remove(updatable);
            
            removeQueue.Add(updatable);
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
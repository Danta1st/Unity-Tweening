using UnityEngine;

namespace Tweening.Updatable
{
    internal sealed class RuntimeUpdateInvoker : MonoBehaviour, IUpdateInvoker
    {
        private UpdateInvoker updateInvoker;

        private void Awake()
        {
            updateInvoker = new UpdateInvoker();
        }

        public void Add(IUpdatable updatable)
        {
            updateInvoker.Add(updatable);
        }

        public void Remove(IUpdatable updatable)
        {
            updateInvoker.Remove(updatable);
        }

        public void Update()
        {
            updateInvoker.Update();
        }
    }
}
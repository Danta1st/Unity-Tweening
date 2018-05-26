using Tweening.Updatable;
using UnityEditor;

namespace Tweening.Editor
{
    internal class EditorUpdateInvoker : IUpdateInvoker
    {
        private readonly UpdateInvoker invoker;
        public EditorUpdateInvoker()
        {
            invoker = new UpdateInvoker();
            EditorApplication.update += Update;
        }
        
        public void Add(IUpdatable updatable)
        {
            invoker.Add(updatable);
        }

        public void Remove(IUpdatable updatable)
        {
            invoker.Remove(updatable);
        }

        public void Update()
        {
            invoker.Update();
        }

        ~EditorUpdateInvoker()
        {
            EditorApplication.update -= Update;
        }
    }
}
using UnityEngine;

namespace Tweening.Updatable
{
    internal static class UpdateInvokerFactory
    {
        private static IUpdateInvoker updateInvoker;
        public static IUpdateInvoker GetDefault()
        {
            if (updateInvoker != null)
                return updateInvoker;

            if (Application.isPlaying)
            {
                updateInvoker = GetRuntimeUpdater();
                return updateInvoker;
            }
            
            updateInvoker = new UpdateInvoker();
            return updateInvoker;
        }

        private static IUpdateInvoker GetRuntimeUpdater()
        {
            var updaterInstance = new GameObject("RuntimeUpdater").AddComponent<RuntimeUpdateInvoker>();
            Object.DontDestroyOnLoad(updaterInstance.gameObject);
            
            return updaterInstance;
        }
    }
}
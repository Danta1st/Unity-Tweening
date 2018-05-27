namespace Tweening.Updatable
{
    internal interface IUpdateInvoker
    {
        /// <summary>
        /// Adds an updatable to the list.
        /// </summary>
        /// <param name="updatable"></param>
        void Add(IUpdatable updatable);
        
        /// <summary>
        /// Removed an updatable from the list
        /// </summary>
        /// <param name="updatable"></param>
        void Remove(IUpdatable updatable);
        
        /// <summary>
        /// Trigger an update on all registered updatables.
        /// </summary>
        void Update();
    }
}
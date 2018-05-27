namespace Tweening.Updatable
{
    internal interface IUpdatable
    {
        /// <summary>
        /// Update callback from the <see cref="IUpdateInvoker"/>
        /// </summary>
        /// <param name="deltaTime">The time in seconds it took to complete the last update</param>
        void Update(float deltaTime);
    }
}
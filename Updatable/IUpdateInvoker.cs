namespace Tweening.Updatable
{
    internal interface IUpdateInvoker
    {
        void Add(IUpdatable updatable);
        void Remove(IUpdatable updatable);
        void Update();
    }
}
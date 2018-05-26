namespace Tweening.Model
{
    public sealed class Data<T>
    {
        public T From { get; private set; }
        public T To { get; private set; }

        public Data(T from, T to)
        {
            From = from;
            To = to;
        }
    }
}
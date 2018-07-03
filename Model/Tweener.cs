using System;
using Tweening.Updatable;
using UnityEngine;

namespace Tweening.Model
{
    public abstract class Tweener<T> : ITweener<T>, IUpdatable
    {
        protected Tweener()
        {
            updateInvoker = UpdateInvokerFactory.GetDefault();
        }

        private readonly IUpdateInvoker updateInvoker;

        private float step;
        private Data<T> data;
        private Action<T> onProgressAction;
        private Action onCompleteAction;
        
        private float duration = 0.4f;
        private IEasingEquation easingEquation = Easings.SineInOut;

        public ITweener<T> OverSeconds(float duration)
        {
            this.duration = duration;
            return this;
        }

        public ITweener<T> EvaluatedBy(IEasingEquation evaluator)
        {
            easingEquation = evaluator;
            return this;
        }

        protected abstract T GetLerpValue(Data<T> data, float evaluation);

        public ITweener<T> Start(T from, T to, Action<T> onProgress, Action onComplete)
        {
            step = 0f;
            data = new Data<T>(from, to);
            onProgressAction = onProgress;
            onCompleteAction = onComplete;

            updateInvoker.Add(this);

            return this;
        }

        public void Stop()
        {
            Reset();

            updateInvoker.Remove(this);
        }

        private void Reset()
        {
            step = 0f;
            data = null;
            onProgressAction = null;
            onCompleteAction = null;
        }

        public void Update(float deltaTime)
        {
            step += deltaTime / duration;
            step = Mathf.Clamp01(step);

            var evaluation = easingEquation.Evaluate(step);
            var result = GetLerpValue(data, evaluation);

            onProgressAction.Invoke(result);
            
            if(step < 1f)
                return;
                
            updateInvoker.Remove(this);
            
            onCompleteAction.Invoke();;
        }
    }
}
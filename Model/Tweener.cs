using System;
using Tweening.Updatable;
using UnityEngine;

namespace Tweening.Model
{
    public abstract class Tweener<T> : ITweener<T>, IUpdatable
    {
        private readonly IUpdateInvoker updateInvoker;

        public Tweener()
        {
            updateInvoker = UpdateInvokerFactory.GetDefault();
        }

        private float step;
        private Data<T> data;
        private Action<T> onProgressAction;
        private Action onCompleteAction;
        
        private float duration = 0.4f;
        public ITweener<T> OverSeconds(float duration)
        {
            this.duration = duration;
            return this;
        }

        private AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        public ITweener<T> EvaluatedBy(AnimationCurve animationCurve)
        {
            this.animationCurve = animationCurve;
            return this;
        }

        protected abstract T GetLerpValue(Data<T> data, float evaluation);

        public ITweener<T> Start(T from, T to, Action<T> onProgress, Action onComplete)
        {
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

            var evaluation = animationCurve.Evaluate(step);
            var result = GetLerpValue(data, evaluation);

            onProgressAction.Invoke(result);
            
            if(step < 1f)
                return;
                
            updateInvoker.Remove(this);
            
            onCompleteAction.Invoke();;
        }
    }
}
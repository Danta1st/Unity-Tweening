using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Tweening.Model
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public interface ITweener<T>
    {
        /// <summary>
        /// Starts the in betweening session.
        /// </summary>
        /// <param name="from">value to begin from</param>
        /// <param name="to">value to transition to</param>
        /// <param name="onProgress">Callback invoked on each frame update</param>
        /// <param name="onComplete">Callback invoked once when the transition completes</param>
        /// <returns></returns>
        ITweener<T> Start(T from, T to, Action<T> onProgress, Action onComplete);
        
        /// <summary>
        /// Stops the ongoing in betweening session. Will not trigger the OnComplete callback.
        /// </summary>
        void Stop();


        ITweener<T> OverSeconds(float duration);
        
        ITweener<T> EvaluatedBy(IEasingEquation easingEquation);
    }
}
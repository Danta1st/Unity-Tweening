using Tweening.Model;
using UnityEngine;

namespace Tweening
{
    public sealed class FloatTweener : Tweener<float>
    {
        protected override float GetLerpValue(Data<float> data, float evaluation)
        {
            return Mathf.Lerp(data.From, data.To, evaluation);
        }
    }
}
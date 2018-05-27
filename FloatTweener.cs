using System.Diagnostics.CodeAnalysis;
using Tweening.Model;
using UnityEngine;

namespace Tweening
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public sealed class FloatTweener : Tweener<float>
    {
        protected override float GetLerpValue(Data<float> data, float evaluation)
        {
            return Mathf.Lerp(data.From, data.To, evaluation);
        }
    }
}
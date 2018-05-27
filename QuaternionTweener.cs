using System.Diagnostics.CodeAnalysis;
using Tweening.Model;
using UnityEngine;

namespace Tweening
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public sealed class QuaternionTweener : Tweener<Quaternion>
    {
        protected override Quaternion GetLerpValue(Data<Quaternion> data, float evaluation)
        {
            return Quaternion.Lerp(data.From, data.To, evaluation);
        }
    }
}
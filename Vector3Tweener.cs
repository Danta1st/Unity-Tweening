using System.Diagnostics.CodeAnalysis;
using Tweening.Model;
using UnityEngine;

namespace Tweening
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public sealed class Vector3Tweener : Tweener<Vector3>
    {
        protected override Vector3 GetLerpValue(Data<Vector3> data, float evaluation)
        {
            return Vector3.Lerp(data.From, data.To, evaluation);
        }
    }
}
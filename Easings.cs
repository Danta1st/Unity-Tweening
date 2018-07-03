using System.Diagnostics.CodeAnalysis;
using Tweening.Model;

namespace Tweening
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class Easings
    {
        public static IEasingEquation Linear{ get { return new Linear(); } }
		
        public static IEasingEquation QuadraticIn{ get { return new QuadraticIn(); } }
        public static IEasingEquation QuadraticOut{ get { return new QuadraticOut(); } }
        public static IEasingEquation QuadraticInOut{ get { return new QuadraticInOut(); } }
		
        public static IEasingEquation CubicIn{ get { return new CubicIn(); } }
        public static IEasingEquation CubicOut{ get { return new CubicOut(); } }
        public static IEasingEquation CubicInOut{ get { return new CubicInOut(); } }
		
        public static IEasingEquation QuarticIn{ get { return new QuarticIn(); } }
        public static IEasingEquation QaurticOut{ get { return new QaurticOut(); } }
        public static IEasingEquation QuarticInOut{ get { return new QuarticInOut(); } }
		
        public static IEasingEquation QuinticIn{ get { return new QuinticIn(); } }
        public static IEasingEquation QuinticOut{ get { return new QuinticOut(); } }
        public static IEasingEquation QuinticInOut{ get { return new QuinticInOut(); } }
		
        public static IEasingEquation SineIn{ get { return new SineIn(); } }
        public static IEasingEquation SineOut{ get { return new SineOut(); } }
        public static IEasingEquation SineInOut{ get { return new SineInOut(); } }
		
        public static IEasingEquation CircIn{ get { return new CircIn(); } }
        public static IEasingEquation CircOut{ get { return new CircOut(); } }
        public static IEasingEquation CircInOut{ get { return new CircInOut(); } }
		
        public static IEasingEquation ExpoIn{ get { return new ExpoIn(); } }
        public static IEasingEquation ExpoOut{ get { return new ExpoOut(); } }
        public static IEasingEquation ExpoInOut{ get { return new ExpoInOut(); } }
		
        public static IEasingEquation ElasticIn{ get { return new ElasticIn(); } }
        public static IEasingEquation ElasticOut{ get { return new ElasticOut(); } }
        public static IEasingEquation ElasticInOut{ get { return new ElasticInOut(); } }
		
        public static IEasingEquation BackIn{ get { return new BackIn(); } }
        public static IEasingEquation BackOut{ get { return new BackOut(); } }
        public static IEasingEquation BackInOut{ get { return new BackInOut(); } }
		
        public static IEasingEquation BounceIn{ get { return new BounceIn(); } }
        public static IEasingEquation BounceOut{ get { return new BounceOut(); } }
        public static IEasingEquation BounceInOut{ get { return new BounceInOut(); } }

	    public static IEasingEquation AnimationCurve(UnityEngine.AnimationCurve animationCurve)
	    {
		    return new AnimationCurve(animationCurve);
	    }
    }
}
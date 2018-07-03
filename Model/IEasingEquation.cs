using System;
using UnityEngine;

namespace Tweening.Model
{
    /// <summary>
    /// Implement this interface to provide custom easing equations.
    /// </summary>
    public interface IEasingEquation
    {
        /// <summary>
        /// Evaluation method utilized by the <see cref="Tweener{T}"/>
        /// </summary>
        /// <param name="step">Normalised linear value between 0-1</param>
        /// <returns></returns>
        float Evaluate(float step);
    }

	
	internal sealed class Linear : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return step;
		}
	}
	
	
	internal sealed class QuadraticIn : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return step * step;
		}
	}
	
	internal sealed class QuadraticOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return -(step * (step - 2f));
		}
	}

	internal sealed class QuadraticInOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			if (step < 0.5f)
			{
				return 2 * step * step;
			}

			return (-2 * step * step) + (4 * step) - 1f;
		}
	}

	
	internal sealed class CubicIn : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return step * step * step;
		}
	}

	internal sealed class CubicOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			var f = step - 1f;
			return f * f * f + 1f;
		}
	}

	internal sealed class CubicInOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			if(step < 0.5f)
			{
				return 4 * step * step * step;
			}

			var f = ((2 * step) - 2);
			return 0.5f * f * f * f + 1;
		}
	}

	
	internal sealed class QuarticIn : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return step * step * step * step;
		}
	}
	
	internal sealed class QaurticOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			var f = step - 1f;
			return step * step * step * (1 - step) + 1f;
		}
	}

	internal sealed class QuarticInOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			if(step < 0.5f)
			{
				return 8 * step * step * step * step;
			}

			var f = (step - 1);
			return -8 * f * f * f * f + 1;
		}
	}

	
	internal sealed class QuinticIn : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return step * step * step * step * step;
		}
	}
	
	internal sealed class QuinticOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			var f = (step - 1);
			return f * f * f * f * f + 1;
		}
	}

	internal sealed class QuinticInOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			if(step < 0.5f)
			{
				return 16 * step * step * step * step * step;
			}

			var f = ((2 * step) - 2);
			return 0.5f * f * f * f * f * f + 1;
		}
	}

	
	internal sealed class SineIn : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return (float) (Math.Sin((step - 1f) * Mathf.PI * 0.5f) + 1f);
		}
	}
	
	internal sealed class SineOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return (float) Math.Sin(step * Math.PI * 0.5f);
		}
	}
	
	internal sealed class SineInOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return (float) ((1f - Math.Cos(step * Math.PI)) * 0.5f);
		}
	}

	
	internal sealed class CircIn : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return (float) (1f - Math.Sqrt(1f - (step * step)));
		}
	}
	
	internal sealed class CircOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return (float) Math.Sqrt((2 - step) * step);
		}
	}
	
	internal sealed class CircInOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			if(step < 0.5f)
			{
				return (float) (0.5f * (1f - Math.Sqrt(1f - 4f * (step * step))));
			}

			return (float) (0.5f * (Math.Sqrt(-((2f * step) - 3f) * ((2f * step) - 1f)) + 1f));
		}
	}

	
	internal sealed class ExpoIn : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return (float) (step == 0f 
				? step 
				: Math.Pow(2, 10 * (step - 1)));
		}
	}
	
	internal sealed class ExpoOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return (float) ((step == 1f) 
				? step 
				: 1 - Math.Pow(2, -10 * step));
		}
	}
	
	internal sealed class ExpoInOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			if(step == 0.0 || step == 1.0) 
				return step;
		
			if(step < 0.5f)
			{
				return (float) (0.5f * Math.Pow(2f, (20f * step) - 10f));
			}

			return (float) (-0.5f * Math.Pow(2f, (-20f * step) + 10f) + 1f);
		}
	}

	
	internal sealed class ElasticIn : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return (float) (Math.Sin(13f * Math.PI * 0.5f * step) * Math.Pow(2f, 10f * (step - 1f)));
			
		}
	}
	
	internal sealed class ElasticOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return (float) (Math.Sin(-13f * Math.PI * 0.5f * (step + 1f)) * Math.Pow(2f, -10f * step) + 1f);
			
		}
	}
	
	internal sealed class ElasticInOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			if(step < 0.5f)
			{
				return (float) (0.5f * Math.Sin(13f * Math.PI * 0.5f * (2f * step)) * Math.Pow(2f, 10f * ((2f * step) - 1f)));
			}

			return (float) (0.5f * (Math.Sin(-13 * Math.PI * 0.5f * ((2f * step - 1f) + 1f)) * Math.Pow(2f, -10f * (2f * step - 1f)) + 2f));

		}
	}

	
	internal sealed class BackIn : IEasingEquation
	{
		public float Evaluate(float step)
		{
			return (float) (step * step * step - step * Math.Sin(step * Math.PI));
		}
	}
	
	internal sealed class BackOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			var f = 1f - step;
			return (float) (1f - (f * f * f - f * Math.Sin(f * Math.PI)));
		}
	}
	
	internal sealed class BackInOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			if(step < 0.5f)
			{
				var f = 2f * step;
				return (float) (0.5f * (f * f * f - f * Math.Sin(f * Math.PI)));
			}
			else
			{
				var f = 1f - (2f * step - 1f);
				return (float) (0.5f * (1f - (f * f * f - f * Math.Sin(f * Math.PI))) + 0.5f);
			}
			
		}
	}
	
	
	internal sealed class BounceIn : IEasingEquation
	{
		private readonly IEasingEquation bounceOut = new BounceOut();
		public float Evaluate(float step)
		{
			return 1f - bounceOut.Evaluate(1f - step);
		}
	}
	
	internal sealed class BounceOut : IEasingEquation
	{
		public float Evaluate(float step)
		{
			if(step < 4f/11f)
			{
				return (121f * step * step)/16f;
			}

			if(step < 8f/11f)
			{
				return (363f/40f * step * step) - (99f/10f * step) + 17f/5f;
			}

			if(step < 9f/10f)
			{
				return (4356f/361f * step * step) - (35442f/1805f * step) + 16061f/1805f;
			}

			return (54f/5f * step * step) - (513f/25f * step) + 268f/25f;
		}
	}
	
	internal sealed class BounceInOut : IEasingEquation
	{
		private readonly IEasingEquation bounceIn = new BounceIn();
		private readonly IEasingEquation bounceOut = new BounceOut();
		
		public float Evaluate(float step)
		{
			if(step < 0.5f)
			{
				return 0.5f * bounceIn.Evaluate(step * 2f);
			}

			return 0.5f * bounceOut.Evaluate(step * 2f - 1f) + 0.5f;
		}
	}
	
	
	internal sealed class AnimationCurve : IEasingEquation
	{
		private readonly UnityEngine.AnimationCurve animationCurve;

		public AnimationCurve(UnityEngine.AnimationCurve animationCurve)
		{
			this.animationCurve = animationCurve;
		}
		
		public float Evaluate(float step)
		{
			return animationCurve.Evaluate(step);
		}
	}
}
using System.Collections.Generic;
using UnityEngine;

namespace ZeShmouttsAssets.ScriptingTools
{
	/// <summary>
	/// Library of useful methods for scripts.
	/// </summary>
	public static partial class ScriptingTools
	{
		/// <summary>
		/// Math-related methods, like vector operations or basic math that isn't included in Mathf.
		/// </summary>
		public static class Math
		{
			#region Remap

			/// <summary>
			/// Remaps a float from a value range to another.
			/// </summary>
			/// <param name="value">Value to remap.</param>
			/// <param name="from1">Original range, minimum value.</param>
			/// <param name="to1">Original range, maximum value.</param>
			/// <param name="from2">New range, minimum value.</param>
			/// <param name="to2">New range, maximum value.</param>
			/// <returns>Returns a float.</returns>
			public static float Remap(float value, float from1, float to1, float from2, float to2)
			{
				return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
			}

			#endregion

			#region Rounding

			/// <summary>
			/// Returns f rounded to the nearest step multiple.
			/// </summary>
			/// <param name="f">Value to round.</param>
			/// <param name="step">Step used to round the value.</param>
			/// <returns>Returns a float.</returns>
			public static float RoundToStep(float f, float step)
			{
				if (step == 0)
				{
					return f;
				}
				else
				{
					return Mathf.Round(f / step) * step;
				}
			}

			/// <summary>
			/// Returns f rounded to the nearest step multiple.
			/// </summary>
			/// <param name="f">Value to round.</param>
			/// <param name="step">Step used to round the value.</param>
			/// <returns></returns>
			public static int RoundToStepInt(float f, int step)
			{
				return Mathf.RoundToInt(RoundToStep(f, (float)step));
			}

			#endregion

			#region Average

			/// <summary>
			/// Returns the average value of a float array.
			/// </summary>
			/// <param name="list">Array to take values from.</param>
			/// <returns>Returns a float.</returns>
			public static float Average(float[] list)
			{
				float final = 0f;
				for (int i = 0; i < list.Length; i++)
				{
					final += list[i];
				}
				final /= list.Length;
				return final;
			}

			/// <summary>
			/// Returns the average value of a float list.
			/// </summary>
			/// <param name="list">List to take values from.</param>
			/// <returns>Returns a float.</returns>
			public static float Average(List<float> list)
			{
				return Average(list.ToArray());
			}

			/// <summary>
			/// Returns the average vector of a Vector3 array.
			/// </summary>
			/// <param name="vectors">Array to take values from.</param>
			/// <returns>Returns a float.</returns>
			public static Vector3 Average(Vector3[] vectors)
			{
				float x = 0f, y = 0f, z = 0f, counter = 0f;

				for (int i = 0; i < vectors.Length; i++)
				{
					if (vectors[i].magnitude > float.Epsilon)
					{
						x += vectors[i].x;
						y += vectors[i].y;
						z += vectors[i].z;
						counter += 1f;
					}
				}

				x /= counter;
				y /= counter;
				z /= counter;

				return new Vector3(x, y, z);
			}

			/// <summary>
			/// Returns the average vector of a Vector3 list.
			/// </summary>
			/// <param name="vectors">Array to take values from.</param>
			/// <returns>Returns a float.</returns>
			public static Vector3 Average(List<Vector3> vectors)
			{
				return Average(vectors.ToArray());
			}

			#endregion

			#region In Range

			/// <summary>
			/// Returns true if the target float is in the selected range.
			/// </summary>
			/// <param name="target">The float to compare.</param>
			/// <param name="min">The lower limit to compare to (inclusive).</param>
			/// <param name="max">The upper limit to compare to (inclusive).</param>
			/// <returns>Returns true if the float is in the selected range, and false in all other cases.</returns>
			public static bool InRange(float target, float min, float max)
			{
				return (target >= min && target <= max);
			}

			/// <summary>
			/// Returns true if the target int is in the selected range.
			/// </summary>
			/// <param name="target">The int to compare.</param>
			/// <param name="min">The lower limit to compare to (inclusive).</param>
			/// <param name="max">The upper limit to compare to (inclusive).</param>
			/// <returns>Returns true if the int is in the selected range, and false in all other cases.</returns>
			public static bool InRange(int target, int min, int max)
			{
				return (target >= min && target <= max);
			}

			#endregion

			#region Angles

			/// <summary>
			/// Checks if an angle is in a range.
			/// </summary>
			/// <param name="angle">Angle to compare.</param>
			/// <param name="min">Minimum angle.</param>
			/// <param name="max">Maximum angle.</param>
			/// <returns>Returns a boolean.</returns>
			public static bool AngleIsBetween(float angle, float min, float max)
			{
				angle = (360 + (angle % 360)) % 360;
				min = (3600000 + min) % 360;
				max = (3600000 + max) % 360;

				if (min < max)
				{
					return min <= angle && angle <= max;
				}

				return min <= angle || angle <= max;
			}

			/// <summary>
			/// Returns the corresponding angle in degrees from a direction vector, with 0° corresponding to (0, 1).
			/// </summary>
			/// <param name="direction">Vector used as a direction.</param>
			/// <returns>Returns an angle in the 0°-360° range.</returns>
			public static float DirectionToAngle(Vector2 direction)
			{
				return DirectionToAngle(direction.x, direction.y);
			}

			/// <summary>
			/// Returns the corresponding angle in degrees from a direction vector, with 0° corresponding to (0, 1).
			/// </summary>
			/// <param name="x">First direction value.</param>
			/// <param name="y">Second direction value.</param>
			/// <returns>Returns an angle in the 0°-360° range.</returns>
			public static float DirectionToAngle(float x, float y)
			{
				return Mathf.Atan2(x, y) * Mathf.Rad2Deg;
			}

			/// <summary>
			/// Returns the corresponding direction vector from an angle, with with 0° corresponding to (0, 1).
			/// </summary>
			/// <param name="angle">Angle to use (in degrees).</param>
			/// <returns>Returns a Vector2.</returns>
			public static Vector2 AngleToDirection(float angle)
			{
				return new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
			}

			#endregion
		}
	}
}
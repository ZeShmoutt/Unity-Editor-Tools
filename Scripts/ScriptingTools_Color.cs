using UnityEngine;

namespace ZeShmouttsAssets.ScriptingTools
{
	/// <summary>
	/// Library of useful methods for scripts.
	/// </summary>
	public static partial class ScriptingTools
	{
		/// <summary>
		/// Color-related methods, including rich text color tags.
		/// </summary>
		public static class Color
		{
			#region Rich Text

			/// <summary>
			/// Colors a string with an hexadecimal color string.
			/// </summary>
			/// <param name="original">The string to color.</param>
			/// <param name="color">The hexadecimal value of the color to use.</param>
			/// <returns>Returns a rich text string of the original string with color tags.</returns>
			public static string RichTextColor(string original, string color)
			{
				return string.Format("<color=#{0}>{1}</color>", color, original);
			}

			/// <summary>
			/// Colors a string with a Color.
			/// </summary>
			/// <param name="original">The string to color.</param>
			/// <param name="color">The color to use.</param>
			/// <returns>Returns a rich text string of the original string with color tags.</returns>
			public static string RichTextColor(string original, UnityEngine.Color color)
			{
				return RichTextColor(original, ColorToHex(color));
			}

			/// <summary>
			/// Colors a single character with an hexadecimal color string.
			/// </summary>
			/// <param name="original">The character to color.</param>
			/// <param name="color">The color to use.</param>
			/// <returns>Returns a rich text string of the original character with color tags.</returns>
			public static string RichTextColor(char original, string color)
			{
				return RichTextColor(original.ToString(), color);
			}

			/// <summary>
			/// Colors a single character with a Color.
			/// </summary>
			/// <param name="original">The character to color.</param>
			/// <param name="color">The color to use.</param>
			/// <returns>Returns a rich text string of the original character with color tags.</returns>
			public static string RichTextColor(char original, UnityEngine.Color color)
			{
				return RichTextColor(original.ToString(), ColorToHex(color));
			}

			#endregion

			#region Hexadecimal Conversion

			/// <summary>
			/// Converts a Color to an hexadecimal color string.
			/// </summary>
			/// <param name="color">The color to convert.</param>
			/// <returns>Returns the hexadecimal value of the color as a string.</returns>
			public static string ColorToHex(UnityEngine.Color color)
			{
				return ColorUtility.ToHtmlStringRGBA(color);
			}

			/// <summary>
			/// Converts an hexadecimal string into a Color.
			/// </summary>
			/// <param name="hex">String to convert.</param>
			/// <returns>Returns a Color.</returns>
			public static UnityEngine.Color HexToColor(string hex)
			{
				UnityEngine.Color col;
				if (ColorUtility.TryParseHtmlString(hex, out col))
				{
					return col;
				}
				else
				{
					throw new System.ArgumentException(string.Format("\"{0}\" is not a valid hexadecimal color.", hex));
				}
			}

			#endregion

			#region Alpha

			/// <summary>
			/// Changes the alpha of an existing color. Ideal when you're lazy.
			/// </summary>
			/// <param name="color">Color to modify.</param>
			/// <param name="alpha">New alpha value, ranging from 0.0f to 1.0f.</param>
			/// <returns>Returns a new color with the selected values.</returns>
			public static UnityEngine.Color ColorAndAlpha(UnityEngine.Color color, float alpha)
			{
				return new UnityEngine.Color(color.r, color.g, color.b, alpha);
			}

			/// <summary>
			/// Changes the alpha of an existing color. Ideal when you're lazy.
			/// </summary>
			/// <param name="color">Color to modify.</param>
			/// <param name="alpha">New alpha value, ranging from 0 to 255.</param>
			/// <returns>Returns a new color with the selected values.</returns>
			public static UnityEngine.Color ColorAndAlpha(UnityEngine.Color color, int alpha)
			{
				return ColorAndAlpha(color, alpha / 255f);
			}

			#endregion

			#region More Colors

			/// <summary>
			/// Pure black. RGBA is (0.00f, 0.00f, 0.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Black { get { return new UnityEngine.Color(0.00f, 0.00f, 0.00f, 1.00f); } }

			/// <summary>
			/// Pure blue. RGBA is (0.00f, 0.00f, 1.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Blue { get { return new UnityEngine.Color(0.00f, 0.00f, 1.00f, 1.00f); } }

			/// <summary>
			/// Dark brown. RGBA is (0.65f, 0.16f, 0.16f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Brown { get { return new UnityEngine.Color(0.65f, 0.16f, 0.16f, 1.00f); } }

			/// <summary>
			/// Cyan. RGBA is (0.00f, 1.00f, 1.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Cyan { get { return new UnityEngine.Color(0.00f, 1.00f, 1.00f, 1.00f); } }

			/// <summary>
			/// Dark blue. RGBA is (0.00f, 0.00f, 0.63f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Darkblue { get { return new UnityEngine.Color(0.00f, 0.00f, 0.63f, 1.00f); } }

			/// <summary>
			/// Dark green. RGBA is (0.00f, 0.50f, 0.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Green { get { return new UnityEngine.Color(0.00f, 0.50f, 0.00f, 1.00f); } }

			/// <summary>
			/// Grey. RGBA is (0.50f, 0.50f, 0.50f, 1.0f).
			/// </summary>
			public static UnityEngine.Color Grey { get { return new UnityEngine.Color(0.50f, 0.50f, 0.50f, 1.00f); } }

			/// <summary>
			/// Light blue. RGBA is (0.68f, 0.85f, 0.90f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Lightblue { get { return new UnityEngine.Color(0.68f, 0.85f, 0.90f, 1.00f); } }

			/// <summary>
			/// Pure green. RGBA is (0.00f, 1.00f, 0.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Lime { get { return new UnityEngine.Color(0.00f, 1.00f, 0.00f, 1.00f); } }

			/// <summary>
			/// Magenta. RGBA is (1.00f, 0.00f, 1.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Magenta { get { return new UnityEngine.Color(1.00f, 0.00f, 1.00f, 1.00f); } }

			/// <summary>
			/// Dark red. RGBA is (0.50f, 0.00f, 0.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Maroon { get { return new UnityEngine.Color(0.50f, 0.00f, 0.00f, 1.00f); } }

			/// <summary>
			/// Dark blue. RGBA is (0.00f, 0.00f, 0.50f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Navy { get { return new UnityEngine.Color(0.00f, 0.00f, 0.50f, 1.00f); } }

			/// <summary>
			/// Dark yellow-green. RGBA is (0.50f, 0.50f, 0.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Olive { get { return new UnityEngine.Color(0.50f, 0.50f, 0.00f, 1.00f); } }

			/// <summary>
			/// Orange. RGBA is (1.00f, 0.65f, 0.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Orange { get { return new UnityEngine.Color(1.00f, 0.65f, 0.00f, 1.00f); } }

			/// <summary>
			/// Purple. RGBA is (0.50f, 0.00f, 0.50f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Purple { get { return new UnityEngine.Color(0.50f, 0.00f, 0.50f, 1.00f); } }

			/// <summary>
			/// Pure red. RGBA is (1.00f, 0.00f, 0.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Red { get { return new UnityEngine.Color(1.00f, 0.00f, 0.00f, 1.00f); } }

			/// <summary>
			/// Light grey. RGBA is (0.75f, 0.75f, 0.75f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Silver { get { return new UnityEngine.Color(0.75f, 0.75f, 0.75f, 1.00f); } }

			/// <summary>
			/// Teal. RGBA is (0.00f, 0.50f, 0.50f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Teal { get { return new UnityEngine.Color(0.00f, 0.50f, 0.50f, 1.00f); } }

			/// <summary>
			/// Pure white. RGBA is (1.00f, 1.00f, 1.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color White { get { return new UnityEngine.Color(1.00f, 1.00f, 1.00f, 1.00f); } }

			/// <summary>
			/// Pure yellow. RGBA is (1.00f, 1.00f, 0.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Yellow { get { return new UnityEngine.Color(1.00f, 1.00f, 0.00f, 1.00f); } }

			/// <summary>
			/// Same as cyan. RGBA is (0.00f, 1.00f, 1.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Aqua { get { return Cyan; } }

			/// <summary>
			/// Same as magenta. RGBA is (1.00f, 0.00f, 1.00f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Fuchsia { get { return Magenta; } }

			/// <summary>
			/// Same as grey. RGBA is (0.50f, 0.50f, 0.50f, 1.00f).
			/// </summary>
			public static UnityEngine.Color Gray { get { return Grey; } }

			#endregion
		}
	}
}
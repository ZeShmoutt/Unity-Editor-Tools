namespace ZeShmouttsAssets.ScriptingTools
{
	/// <summary>
	/// Library of useful methods for scripts.
	/// </summary>
	public static partial class ScriptingTools
	{
		/// <summary>
		/// Physics-related methods, like a cone version of OverlapSphere.
		/// </summary>
		public static class String
		{
			#region Substring

			/// <summary>
			/// Same as Substring, except it takes a start and end indexes instead of start index and length.
			/// </summary>
			/// <param name="source">String instance to use.</param>
			/// <param name="start">The zero-based starting character position of a substring in this instance.</param>
			/// <param name="end">The zero-based ending character position of a substring in this instance.</param>
			/// <returns>Returns a substring.</returns>
			public static string SubstringByIndexes(string source, int startIndex, int endIndex)
			{
				return source.Substring(startIndex, endIndex - startIndex);
			}

			#endregion

			#region Is any null or empty

			/// <summary>
			/// Checks if a list of strings contains at least one that is null or empty.
			/// </summary>
			/// <param name="strings">List to check.</param>
			/// <returns>Returns true if the list has an item that is null or empty.</returns>
			public static bool IsAnyNullOrEmpty(List<string> strings)
			{
				return IsAnyNullOrEmpty(strings.ToArray());
			}

			/// <summary>
			/// Checks if an array of strings contains at least one that is null or empty.
			/// </summary>
			/// <param name="strings">Array to check.</param>
			/// <returns>Returns true if the array has an item that is null or empty.</returns>
			public static bool IsAnyNullOrEmpty(string[] strings)
			{
				for (int i = 0; i < strings.Length; i++)
				{
					if (string.IsNullOrEmpty(strings[i]))
					{
						return true;
					}
				}
				return false;
			}

			#endregion
		}
	}
}
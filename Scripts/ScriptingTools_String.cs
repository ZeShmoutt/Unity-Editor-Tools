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
			public static string SubstringByIndexes(this string source, int startIndex, int endIndex)
			{
				return source.Substring(startIndex, endIndex - startIndex);
			}

			#endregion
		}
	}
}
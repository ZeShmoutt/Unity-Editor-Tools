using UnityEngine;

namespace ZeShmouttsAssets.ScriptingTools.Editor
{
	/// <summary>
	/// Library of useful methods for scripts. Editor-only.
	/// </summary>
	public static partial class ScriptingToolsEditor
	{
		/// <summary>
		/// Methods based on Unity's Debug class, with added features.
		/// </summary>
		public static class Debug
		{
			#region Colored Log (Base)

			/// <summary>
			/// Logs a message to the Unity Console, using rich text markup to add color.
			/// </summary>
			/// <param name="message">Message to display.</param>
			/// <param name="color">Color to apply to the message.</param>
			/// <param name="context">Object to which the message applies.</param>
			public static void LogColored(string message, Color color, Object context)
			{
				UnityEngine.Debug.Log(ScriptingTools.Color.RichTextColor(message, color), context);
			}

			/// <summary>
			/// Logs a message to the Unity Console, using rich text markup to add color.
			/// </summary>
			/// <param name="message">Message to display.</param>
			/// <param name="color">Color to apply to the message.</param>
			public static void LogColored(string message, Color color)
			{
				UnityEngine.Debug.Log(ScriptingTools.Color.RichTextColor(message, color));
			}

			/// <summary>
			/// Logs a formatted message to the Unity Console, using rich text markup to add color.
			/// </summary>
			/// <param name="context">Object to which the message applies.</param>
			/// <param name="color">Color to apply to the message.</param>
			/// <param name="format">A composite format string.</param>
			/// <param name="args">Format arguments.</param>
			public static void LogFormatColored(Object context, Color color, string format, params object[] args)
			{
				UnityEngine.Debug.Log(ScriptingTools.Color.RichTextColor(string.Format(format, args), color), context);
			}

			/// <summary>
			/// Logs a formatted message to the Unity Console, using rich text markup to add color.
			/// </summary>
			/// <param name="color">Color to apply to the message.</param>
			/// <param name="format">A composite format string.</param>
			/// <param name="args">Format arguments.</param>
			public static void LogFormatColored(Color color, string format, params object[] args)
			{
				UnityEngine.Debug.Log(ScriptingTools.Color.RichTextColor(string.Format(format, args), color));
			}

			#endregion

			#region Colored Log (Warning)

			/// <summary>
			/// A variant of Debug.Log that logs a warning message to the console, using rich text markup to add color.
			/// </summary>
			/// <param name="message">Message to display.</param>
			/// <param name="context">Object to which the message applies.</param>
			/// <param name="color">Color to apply to the message.</param>
			public static void LogWarningColored(string message, Object context, Color color)
			{
				UnityEngine.Debug.LogWarning(ScriptingTools.Color.RichTextColor(message, color), context);
			}

			/// <summary>
			/// A variant of Debug.Log that logs a warning message to the console, using rich text markup to add color.
			/// </summary>
			/// <param name="message">Message to display.</param>
			/// <param name="color">Color to apply to the message.</param>
			public static void LogWarningColored(string message, Color color)
			{
				UnityEngine.Debug.LogWarning(ScriptingTools.Color.RichTextColor(message, color));
			}

			/// <summary>
			/// Logs a formatted warning message to the Unity Console, using rich text markup to add color.
			/// </summary>
			/// <param name="context">Object to which the message applies.</param>
			/// <param name="color">Color to apply to the message.</param>
			/// <param name="format">A composite format string.</param>
			/// <param name="args">Format arguments.</param>
			public static void LogWarningFormatColored(Object context, Color color, string format, params object[] args)
			{
				UnityEngine.Debug.LogWarning(ScriptingTools.Color.RichTextColor(string.Format(format, args), color), context);
			}

			/// <summary>
			/// Logs a formatted warning message to the Unity Console, using rich text markup to add color.
			/// </summary>
			/// <param name="color">Color to apply to the message.</param>
			/// <param name="format">A composite format string.</param>
			/// <param name="args">Format arguments.</param>
			public static void LogWarningFormatColored(Color color, string format, params object[] args)
			{
				UnityEngine.Debug.LogWarning(ScriptingTools.Color.RichTextColor(string.Format(format, args), color));
			}

			#endregion

			#region Colored Log (Error)

			/// <summary>
			/// A variant of Debug.Log that logs an error message to the console, using rich text markup to add color.
			/// </summary>
			/// <param name="message">Message to display.</param>
			/// <param name="context">Object to which the message applies.</param>
			/// <param name="color">Color to apply to the message.</param>
			public static void LogErrorColored(string message, Object context, Color color)
			{
				UnityEngine.Debug.LogError(ScriptingTools.Color.RichTextColor(message, color), context);
			}

			/// <summary>
			/// A variant of Debug.Log that logs an error message to the console, using rich text markup to add color.
			/// </summary>
			/// <param name="message">Message to display.</param>
			/// <param name="color">Color to apply to the message.</param>
			public static void LogErrorColored(string message, Color color)
			{
				UnityEngine.Debug.LogError(ScriptingTools.Color.RichTextColor(message, color));
			}

			/// <summary>
			/// Logs a formatted error message to the Unity Console, using rich text markup to add color.
			/// </summary>
			/// <param name="context">Object to which the message applies.</param>
			/// <param name="color">Color to apply to the message.</param>
			/// <param name="format">A composite format string.</param>
			/// <param name="args">Format arguments.</param>
			public static void LogErrorFormatColored(Object context, Color color, string format, params object[] args)
			{
				UnityEngine.Debug.LogError(ScriptingTools.Color.RichTextColor(string.Format(format, args), color), context);
			}

			/// <summary>
			/// Logs a formatted error message to the Unity Console, using rich text markup to add color.
			/// </summary>
			/// <param name="color">Color to apply to the message.</param>
			/// <param name="format">A composite format string.</param>
			/// <param name="args">Format arguments.</param>
			public static void LogErrorFormatColored(Color color, string format, params object[] args)
			{
				UnityEngine.Debug.LogError(ScriptingTools.Color.RichTextColor(string.Format(format, args), color));
			}

			#endregion
		}
	}
}
﻿using System;
using UnityEditor;
using UnityEngine;

namespace ZeShmouttsAssets.ScriptingTools.Editor
{
	/// <summary>
	/// Library of useful methods for scripts. Editor-only.
	/// </summary>
	public static partial class ScriptingToolsEditor
	{
		/// <summary>
		/// Methods used to create custom editors.
		/// </summary>
		public static class CustomEditor
		{
			#region Internal

			internal const int LAYERS_COUNT = 32;

			internal const string DEFAULT_UNDO_MESSAGE = "Changed value";
			internal const string DEFAULT_LAYER_NAME = "Layer {0}";

			/// <summary>
			/// Creates an array of names generated from the list of layers.
			/// </summary>
			/// <returns>A list of layer names.</returns>
			internal static string[] GetLayersNames()
			{
				string[] layers = new string[LAYERS_COUNT];

				for (int i = 0; i < LAYERS_COUNT; i++)
				{
					string layerName = LayerMask.LayerToName(i);
					layers[i] = !string.IsNullOrEmpty(layerName) ? layerName : string.Format(DEFAULT_LAYER_NAME, i);
				}
				return layers;
			}

			#endregion

			#region Layout

			/// <summary>
			/// Draws an horizontal line with the specified dimensions and color.
			/// </summary>
			/// <param name="thickness">The thickness of the line.</param>
			/// <param name="padding">The vertical padding around the line.</param>
			/// <param name="lineColor">The color of the line.</param>
			public static void HorizontalLine(int thickness, int padding, Color lineColor)
			{
				Rect lineRect = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
				lineRect.height = thickness;
				lineRect.y += padding / 2;
				lineRect.x -= 2;
				lineRect.width += 6;
				EditorGUI.DrawRect(lineRect, lineColor);
			}

			/// <summary>
			/// Draws an horizontal line with the specified dimensions.
			/// </summary>
			/// <param name="thickness">The thickness of the line.</param>
			/// <param name="padding">The vertical padding around the line.</param>
			/// <param name="lineColor">The color of the line.</param>
			public static void HorizontalLine(int thickness, int padding)
			{
				HorizontalLine(thickness, padding, new Color(0.5f, 0.5f, 0.5f, 0.5f));
			}

			/// <summary>
			/// Draws an horizontal line.
			/// </summary>
			/// <param name="thickness">The thickness of the line.</param>
			/// <param name="padding">The vertical padding around the line.</param>
			/// <param name="lineColor">The color of the line.</param>
			public static void HorizontalLine()
			{
				HorizontalLine(1, 5);
			}

			#endregion

			#region Layer Mask

			/// <summary>
			/// Make a field for layer masks.
			/// </summary>
			/// <param name="label">Prefix label for the field.</param>
			/// <param name="selected">The current layer mask to display.</param>
			/// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.
			/// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight, GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
			/// <returns>The value modified by the user.</returns>
			public static LayerMask LayerMaskField(string label, LayerMask selected, params GUILayoutOption[] options)
			{
				selected.value = EditorGUILayout.MaskField(label, selected.value, GetLayersNames(), options);
				return selected;
			}

			/// <summary>
			/// Make a field for layer masks.
			/// </summary>
			/// <param name="selected">The current layer mask to display.</param>
			/// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.
			/// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight, GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
			/// <returns>The value modified by the user.</returns>
			public static LayerMask LayerMaskField(LayerMask selected, params GUILayoutOption[] options)
			{
				selected.value = EditorGUILayout.MaskField(selected.value, GetLayersNames(), options);
				return selected;
			}

			#endregion

			#region Recorded Field

			/// <summary>
			/// Shortcut to make a GUI field recorded by the undo/redo system.
			/// </summary>
			/// <typeparam name="T">Type of the field's value.</typeparam>
			/// <param name="target">Oject that will be recorded for undo/redo purposes.</param>
			/// <param name="value">Value that will be recorded.</param>
			/// <param name="fieldMethod">GUI method used to draw the field and set the new value.</param>
			/// <param name="undoMessage">Custom message displayed in the 'Edit/Undo' menu.</param>
			public static void RecordedField<T>(UnityEngine.Object target, ref T value, Func<T> fieldMethod, string undoMessage)
			{
				EditorGUI.BeginChangeCheck();
				T fieldValue = fieldMethod();
				if (EditorGUI.EndChangeCheck())
				{
					Undo.RecordObject(target, undoMessage);
					value = fieldValue;
					EditorUtility.SetDirty(target);
				}
			}

			/// <summary>
			/// Shortcut to make a GUI field recorded by the undo/redo system.
			/// </summary>
			/// <typeparam name="T">Type of the field's value.</typeparam>
			/// <param name="target">Oject that will be recorded for undo/redo purposes.</param>
			/// <param name="value">Value that will be recorded.</param>
			/// <param name="fieldMethod">GUI method used to draw the field and set the new value.</param>
			public static void RecordedField<T>(UnityEngine.Object target, ref T value, Func<T> fieldMethod)
			{
				RecordedField(target, ref value, fieldMethod, DEFAULT_UNDO_MESSAGE);
			}

			#endregion

			#region Enum field

			/// <summary>
			/// Shortcut for EditorGUILayout.EnumPopup with automatic cast to the desired type.
			/// </summary>
			/// <typeparam name="T">Type of enum.</typeparam>
			/// <param name="label">Optional label in front of the field.</param>
			/// <param name="selected">The enum option the field shows.</param>
			/// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.</param>
			/// <returns></returns>
			public static T EnumField<T>(string label, T selected, params GUILayoutOption[] options) where T : Enum
			{
				return (T)EditorGUILayout.EnumPopup(label, selected, options);
			}

			#endregion
		}
	}
}
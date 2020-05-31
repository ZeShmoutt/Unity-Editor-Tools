using System.Collections.Generic;
using UnityEditor;

namespace ZeShmouttsAssets.ScriptingTools.Editor
{
	/// <summary>
	/// Library of useful methods for scripts. Editor-only.
	/// </summary>
	public static partial class ScriptingToolsEditor
	{
		/// <summary>
		/// Methods to manipulate the asset database.
		/// </summary>
		public static class AssetDatabase
		{
			#region Asset Database

			/// <summary>
			/// Returns a list of all assets of the selected type.
			/// </summary>
			/// <typeparam name="T">Type of asset to find.</typeparam>
			/// <returns>Returns a list of assets.</returns>
			public static List<T> FindAssetsByType<T>() where T : UnityEngine.Object
			{
				List<T> assets = new List<T>();
				string[] guids = UnityEditor.AssetDatabase.FindAssets(string.Format("t:{0}", typeof(T).ToString().Replace("UnityEngine.", "")));
				for (int i = 0; i < guids.Length; i++)
				{
					string assetPath = UnityEditor.AssetDatabase.GUIDToAssetPath(guids[i]);
					T asset = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(assetPath);
					if (asset != null)
					{
						assets.Add(asset);
					}
				}
				return assets;
			}

			/// <summary>
			/// Focus the project window and inspector on an asset.
			/// </summary>
			/// <param name="asset">The asset to focus on.</param>
			public static void FocusAsset(UnityEngine.Object asset)
			{
				EditorUtility.FocusProjectWindow();
				Selection.activeObject = asset;
			}

			#endregion
		}
	}
}
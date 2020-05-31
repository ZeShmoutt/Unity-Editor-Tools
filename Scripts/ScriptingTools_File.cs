using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace ZeShmouttsAssets.ScriptingTools
{
	/// <summary>
	/// Library of useful methods for scripts.
	/// </summary>
	public static partial class ScriptingTools
	{
		/// <summary>
		/// File-related methods, like quick screenshots.
		/// </summary>
		public static class File
		{
			#region Internal

			internal const string SCREENSHOT_FILE_EXTENSION = ".png";
			internal const string SCREENSHOT_FILE_PREFIX = "Screenshot_";

			internal static FileInfo CheckFilePath(string path)
			{
				FileInfo file = new FileInfo(path);
				file.Directory.Create();
				return file;
			}

			#endregion

			#region Screenshot

			/// <summary>
			/// Saves a screenshot at a specified path. The folder will be created if it doesn't exist.
			/// </summary>
			/// <param name="folderPath">Path to save the screenshot at.</param>
			/// <param name="fileName">Name of the screenshot file.</param>
			public static void QuickScreenshot(string folderPath, string fileName)
			{
				if (!fileName.EndsWith(SCREENSHOT_FILE_EXTENSION))
				{
					fileName = string.Concat(fileName, SCREENSHOT_FILE_EXTENSION);
				}

				string fullPath = Path.Combine(folderPath, fileName);
				Directory.CreateDirectory(folderPath);
				ScreenCapture.CaptureScreenshot(fullPath, 1);
			}

			/// <summary>
			/// Saves a screenshot in My Documents, using Application.productName for the folder. The folder will be created if it doesn't exist.
			/// </summary>
			/// <param name="fileName">Name of the screenshot file.</param>
			public static void QuickScreenshot(string fileName)
			{
				string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Application.productName);
				QuickScreenshot(folderPath, fileName);
			}

			/// <summary>
			/// Saves a screenshot in My Documents, using Application.productName for the folder and a file name based on the current time. The folder will be created if it doesn't exist.
			/// </summary>
			public static void QuickScreenshot()
			{
				string fileName = string.Concat(SCREENSHOT_FILE_PREFIX, DateTime.Now.ToString("yyyy_MM_dd_HHmmss"), SCREENSHOT_FILE_EXTENSION);
				QuickScreenshot(fileName);
			}

			#endregion

			#region Write File

			/// <summary>
			/// Write in a file with data. This will overwrite any existing file at this path, so use with caution.
			/// </summary>
			/// <param name="filePath">Path to write the data.</param>
			/// <param name="data">Data to write.</param>
			/// <param name="overwrite">If 'true', any existing file at this path will be overwritten.</param>
			private static void WriteFile<T>(string filePath, T data, bool overwrite)
			{
				FileInfo fileInfo = new FileInfo(filePath);
				FileStream stream;
				if (fileInfo.Exists)
				{
					if (overwrite)
					{
						stream = fileInfo.OpenWrite();
					}
					else
					{
						throw new UnauthorizedAccessException("File already exists.");
					}
				}
				else
				{
					stream = fileInfo.Create();
				}

				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(stream, data);
				stream.Close();
				stream.Dispose();
			}

			/// <summary>
			/// Write in a file with data. This will overwrite any existing file at this path, so use with caution.
			/// </summary>
			/// <param name="filePath">Path to write the data.</param>
			/// <param name="data">Data to write.</param>
			private static void WriteFile<T>(string filePath, T data)
			{
				WriteFile(filePath, data);
			}

			/// <summary>
			/// Try to load a file as a specified data type.
			/// </summary>
			/// <typeparam name="T">Type of data to get.</typeparam>
			/// <param name="filePath">Path to load the data.</param>
			/// <param name="data">Loaded data.</param>
			/// <returns>Returns true if the file has been found and loaded successfully.</returns>
			private static bool TryLoadFile<T>(string filePath, out T data)
			{
				FileInfo fileInfo = new FileInfo(filePath);
				if (fileInfo.Exists)
				{
					bool returnValue;

					using (FileStream stream = fileInfo.OpenRead())
					{
						BinaryFormatter bf = new BinaryFormatter();
						object fileContent = bf.Deserialize(stream);

						if (fileContent is T)
						{
							data = (T)bf.Deserialize(stream);
							stream.Close();
							returnValue = true;
						}
						else
						{
							Debug.LogError(string.Format("Error : file \"{0}\" is not {1}", filePath, typeof(T).Name));
							data = default;
							returnValue = false;
						}
					}

					return returnValue;
				}
				else
				{
					Debug.LogError(string.Format("Error : file \"{0}\" not found", filePath));
					data = default;
					return false;
				}
			}

			#endregion
		}
	}
}

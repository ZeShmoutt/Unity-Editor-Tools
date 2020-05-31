using UnityEngine;

namespace ZeShmouttsAssets.ScriptingTools.Editor
{
	/// <summary>
	/// Library of useful methods for scripts. Editor-only.
	/// </summary>
	public static partial class ScriptingToolsEditor
	{
		/// <summary>
		/// Additional premade handles.
		/// </summary>
		public static class Handles
		{
			#region Internal

			internal static Vector3 CubeCorner(Vector3 position, Quaternion rotation, Vector3 size, bool right, bool up, bool forward)
			{
				float r = right ? 0.5f : -0.5f;
				float u = up ? 0.5f : -0.5f;
				float f = forward ? 0.5f : -0.5f;
				Vector3 pos = position + (rotation * new Vector3(size.x * r, size.y * u, size.z * f));
				return pos;
			}

			#endregion

			#region Cone

			/// <summary>
			/// Draw the outline of a cone in 3D space. Particularly useful for field of view.
			/// </summary>
			/// <param name="origin">The point corresponding to the tip of the cone.</param>
			/// <param name="rotation">The rotation of the cone. The base will be facing toward the forward direction.</param>
			/// <param name="angle">The angle of the cone.</param>
			/// <param name="length">The length of the cone.</param>
			public static void DrawWireCone(Vector3 origin, Quaternion rotation, float angle, float length)
			{
				Vector3 direction = rotation * Vector3.forward;
				Vector3 position = origin + direction * Mathf.Cos(Mathf.Deg2Rad * angle * 0.5f) * length;
				UnityEditor.Handles.DrawWireDisc(position, direction, Mathf.Sin(Mathf.Deg2Rad * angle * 0.5f) * length);

				position = origin + direction * Mathf.Cos(Mathf.Deg2Rad * angle * 0.5f) * length * 0.5f;
				UnityEditor.Handles.DrawWireDisc(position, direction, Mathf.Sin(Mathf.Deg2Rad * angle * 0.5f) * length * 0.5f);

				position = new Vector3(0f, length * Mathf.Sin(Mathf.Deg2Rad * angle * 0.5f), length * Mathf.Cos(Mathf.Deg2Rad * angle * 0.5f));
				UnityEditor.Handles.DrawWireArc(origin, (rotation * Vector3.right), rotation * position, angle, length);
				UnityEditor.Handles.DrawLine(origin, origin + (rotation * position));
				UnityEditor.Handles.DrawLine(origin, origin + (rotation * new Vector3(position.x, -position.y, position.z)));

				position = new Vector3(length * Mathf.Sin(Mathf.Deg2Rad * angle * 0.5f), 0f, length * Mathf.Cos(Mathf.Deg2Rad * angle * 0.5f));
				UnityEditor.Handles.DrawWireArc(origin, -(rotation * Vector3.up), rotation * position, angle, length);
				UnityEditor.Handles.DrawLine(origin, origin + (rotation * position));
				UnityEditor.Handles.DrawLine(origin, origin + (rotation * new Vector3(-position.x, position.y, position.z)));
			}

			#endregion

			#region Cube

			/// <summary>
			/// Draw the outline of a cube in 3D space.
			/// </summary>
			/// <param name="position">The point corresponding to the center of the cube.</param>
			/// <param name="rotation">The rotation of the cube.</param>
			/// <param name="size">The size of the cube for each axis.</param>
			public static void DrawWireCube(Vector3 position, Quaternion rotation, Vector3 size)
			{
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, true, true, true), CubeCorner(position, rotation, size, true, false, true));
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, true, true, true), CubeCorner(position, rotation, size, true, true, false));
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, true, false, false), CubeCorner(position, rotation, size, true, true, false));
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, true, false, false), CubeCorner(position, rotation, size, true, false, true));
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, false, true, true), CubeCorner(position, rotation, size, false, false, true));
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, false, true, true), CubeCorner(position, rotation, size, false, true, false));
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, false, false, false), CubeCorner(position, rotation, size, false, true, false));
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, false, false, false), CubeCorner(position, rotation, size, false, false, true));
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, true, false, false), CubeCorner(position, rotation, size, false, false, false));
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, true, true, false), CubeCorner(position, rotation, size, false, true, false));
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, true, false, true), CubeCorner(position, rotation, size, false, false, true));
				UnityEditor.Handles.DrawLine(CubeCorner(position, rotation, size, true, true, true), CubeCorner(position, rotation, size, false, true, true));
			}

			#endregion

			#region Sphere

			/// <summary>
			/// Draw the outline of a sphere in 3D Space.
			/// </summary>
			/// <param name="center">The center of the sphere.</param>
			/// <param name="rotation">The rotation of the sphere.</param>
			/// <param name="radius">The radius of the sphere.</param>
			public static void DrawWireSphere(Vector3 center, Quaternion rotation, float radius)
			{
				UnityEditor.Handles.DrawWireDisc(center, rotation * Vector3.forward, radius);
				UnityEditor.Handles.DrawWireDisc(center, rotation * Vector3.right, radius);
				UnityEditor.Handles.DrawWireDisc(center, rotation * Vector3.up, radius);

				if (Camera.current.orthographic)
				{
					Vector3 normal = center - UnityEditor.Handles.inverseMatrix.MultiplyVector(Camera.current.transform.forward);
					float sqrMagnitude = normal.sqrMagnitude;
					float num0 = radius * radius;
					UnityEditor.Handles.DrawWireDisc(center - num0 * normal / sqrMagnitude, normal, radius);
				}
				else
				{
					Vector3 normal = center - UnityEditor.Handles.inverseMatrix.MultiplyPoint(Camera.current.transform.position);
					float sqrMagnitude = normal.sqrMagnitude;
					float num0 = radius * radius;
					float num1 = num0 * num0 / sqrMagnitude;
					float num2 = Mathf.Sqrt(num0 - num1);
					UnityEditor.Handles.DrawWireDisc(center - num0 * normal / sqrMagnitude, normal, num2);
				}
			}

			#endregion
		}
	}
}
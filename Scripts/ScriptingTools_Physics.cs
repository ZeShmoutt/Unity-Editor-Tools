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
		/// Physics-related methods, like a cone version of OverlapSphere.
		/// </summary>
		public static class Physics
		{
			#region Internal

			internal const int DEFAULT_LAYER_MASK = UnityEngine.Physics.AllLayers;
			internal const QueryTriggerInteraction DEFAULT_QUERY_TRIGGER_INTERACTION = QueryTriggerInteraction.UseGlobal;

			#endregion

			#region Overlap Cone

			/// <summary>
			/// Returns an array of colliders touching or inside the cone.
			/// </summary>
			/// <param name="position">Origin of the cone.</param>
			/// <param name="direction">Direction of the cone.</param>
			/// <param name="radius">Radius (= length) of the cone.</param>
			/// <param name="angle">Angle of the cone.</param>
			/// <param name="layerMask">Mask that is used to selectively ignore colliders.</param>
			/// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
			/// <returns>Returns an array of Colliders.</returns>
			public static Collider[] OverlapCone(Vector3 position, Vector3 direction, float radius, float angle, int layerMask = UnityEngine.Physics.AllLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
			{
				Collider[] firstPass = UnityEngine.Physics.OverlapSphere(position, radius, layerMask, queryTriggerInteraction);

				Debug.DrawRay(position, direction * 2f, UnityEngine.Color.cyan, 2f);

				List<Collider> secondPass = new List<Collider>();
				for (int i = 0; i < firstPass.Length; i++)
				{
					Vector3 target = firstPass[i].transform.position - position;
					if (Vector3.Angle(direction, target) <= angle * 0.5f)
					{
						secondPass.Add(firstPass[i]);
						Debug.DrawRay(position, target, UnityEngine.Color.green, 2f);
					}
					else
					{
						Debug.DrawRay(position, target, UnityEngine.Color.red, 2f);
					}
				}

				return secondPass.ToArray();
			}

			/// <summary>
			/// Returns an array of colliders touching or inside the cone.
			/// </summary>
			/// <param name="position">Origin of the cone.</param>
			/// <param name="direction">Direction of the cone.</param>
			/// <param name="radius">Radius (= length) of the cone.</param>
			/// <param name="angle">Angle of the cone.</param>
			/// <param name="layerMask">Mask that is used to selectively ignore colliders.</param>
			/// <returns>Returns an array of Colliders.</returns>
			public static Collider[] OverlapCone(Vector3 position, Vector3 direction, float radius, float angle, int layerMask)
			{
				return OverlapCone(position, direction, radius, angle, layerMask, DEFAULT_QUERY_TRIGGER_INTERACTION);
			}

			/// <summary>
			/// Returns an array of colliders touching or inside the cone.
			/// </summary>
			/// <param name="position">Origin of the cone.</param>
			/// <param name="direction">Direction of the cone.</param>
			/// <param name="radius">Radius (= length) of the cone.</param>
			/// <param name="angle">Angle of the cone.</param>
			/// <returns>Returns an array of Colliders.</returns>
			public static Collider[] OverlapCone(Vector3 position, Vector3 direction, float radius, float angle)
			{
				return OverlapCone(position, direction, radius, angle, DEFAULT_LAYER_MASK, DEFAULT_QUERY_TRIGGER_INTERACTION);
			}

			/// <summary>
			/// Returns an array of Components strictly inside a cone.
			/// </summary>
			/// <typeparam name="T">The type of Component the cone overlap will return.</typeparam>
			/// <param name="position">Origin of the cone.</param>
			/// <param name="direction">Direction of the cone.</param>
			/// <param name="radius">Radius (= length) of the cone.</param>
			/// <param name="angle">Angle of the cone.</param>
			/// <param name="layerMask">Mask that is used to selectively ignore colliders.</param>
			/// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
			/// <returns>Returns an array of Components of the selected type.</returns>
			public static T[] OverlapCone<T>(Vector3 position, Vector3 direction, float radius, float angle, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
			{
				Collider[] overlap = OverlapCone(position, direction, radius, angle, layerMask, queryTriggerInteraction);

				List<T> components = new List<T>();
				for (int i = 0; i < overlap.Length; i++)
				{
					T currentComponent = overlap[i].GetComponent<T>();
					if (currentComponent != null)
					{
						components.Add(currentComponent);
					}
				}

				return components.ToArray();
			}

			/// <summary>
			/// Returns an array of Components strictly inside a cone.
			/// </summary>
			/// <typeparam name="T">The type of Component the cone overlap will return.</typeparam>
			/// <param name="position">Origin of the cone.</param>
			/// <param name="direction">Direction of the cone.</param>
			/// <param name="radius">Radius (= length) of the cone.</param>
			/// <param name="angle">Angle of the cone.</param>
			/// <param name="layerMask">Mask that is used to selectively ignore colliders.</param>
			/// <returns>Returns an array of Components of the selected type.</returns>
			public static T[] OverlapCone<T>(Vector3 position, Vector3 direction, float radius, float angle, int layerMask)
			{
				return OverlapCone<T>(position, direction, radius, angle, layerMask, DEFAULT_QUERY_TRIGGER_INTERACTION);
			}

			/// <summary>
			/// Returns an array of Components strictly inside a cone.
			/// </summary>
			/// <typeparam name="T">The type of Component the cone overlap will return.</typeparam>
			/// <param name="position">Origin of the cone.</param>
			/// <param name="direction">Direction of the cone.</param>
			/// <param name="radius">Radius (= length) of the cone.</param>
			/// <param name="angle">Angle of the cone.</param>
			/// <param name="layerMask">Mask that is used to selectively ignore colliders.</param>
			/// <returns>Returns an array of Components of the selected type.</returns>
			public static T[] OverlapCone<T>(Vector3 position, Vector3 direction, float radius, float angle)
			{
				return OverlapCone<T>(position, direction, radius, angle, DEFAULT_LAYER_MASK, DEFAULT_QUERY_TRIGGER_INTERACTION);
			}

			#endregion
		}
	}
}
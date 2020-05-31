using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZeShmouttsAssets.ScriptingTools
{
	/// <summary>
	/// Library of useful methods for scripts.
	/// </summary>
	public static partial class ScriptingTools
	{
		/// <summary>
		/// Additional methods for working with lists and arrays.
		/// </summary>
		public static class Lists
		{
			#region Shuffle

			/// <summary>
			/// Picks a random item from an array, then shuffles the array. Should never pick the same item twice in a row.
			/// </summary>
			/// <typeparam name="T">Type of item of the array.</typeparam>
			/// <param name="list">Array to pick from.</param>
			/// <returns>Returns an item from the array.</returns>
			public static T PickRandomAndShuffle<T>(T[] list)
			{
				if (list.Length > 0)
				{
					if (list.Length > 1)
					{
						int n = Random.Range(1, list.Length);
						T picked = list[n];
						list[n] = list[0];
						list[0] = picked;
						return picked;
					}
					else
					{
						return list[0];
					}
				}
				else
				{
					throw new System.IndexOutOfRangeException();
				}
			}

			#endregion

			#region Weighted Random

			/// <summary>
			/// Picks a random item from an array, using a list of weights to influence the random pick.
			/// </summary>
			/// <typeparam name="T">Type of item of the array.</typeparam>
			/// <param name="values">Array of values to pick from.</param>
			/// <param name="weights">Array of weights to associate to each value. Both arrays must have the same length.</param>
			/// <returns>Returns a random element from the </returns>
			public static T WeightedRandom<T>(T[] values, int[] weights)
			{
				if (values.Length <= 0 || weights.Length != values.Length)
				{
					throw new System.IndexOutOfRangeException("The object list and weight list lengths don't match.");
				}

				int total = 0;
				for (int i = 0; i < weights.Length; i++)
				{
					total += weights[i];
				}

				int rand = Random.Range(0, total);
				int counter = 0;

				for (int i = 0; i < values.Length; i++)
				{
					counter += weights[i];
					if (rand < counter)
					{
						return values[i];
					}
					else
					{
						continue;
					}
				}

				throw new System.Exception("Something went wrong with the weighted random.");
			}

			/// <summary>
			/// Picks a random item from an array, using a list of weights to influence the random pick.
			/// </summary>
			/// <typeparam name="T">Type of item of the array.</typeparam>
			/// <param name="values">List of values to pick from.</param>
			/// <param name="weights">List of weights to associate to each value. Both lists must have the same length.</param>
			/// <returns>Returns a random element from the </returns>
			public static T WeightedRandom<T>(List<T> values, List<int> weights)
			{
				return WeightedRandom(values.ToArray(), weights.ToArray());
			}

			/// <summary>
			/// Picks a random item from an array, using a list of weights to influence the random pick.\nAll weights will be added
			/// </summary>
			/// <typeparam name="T">Type of item of the array.</typeparam>
			/// <param name="values">Dictionary of weighted values to pick from.</param>
			/// <returns>Returns a random element from the </returns>
			public static T WeightedRandom<T>(Dictionary<T, int> values)
			{
				return WeightedRandom(values.Keys.ToArray(), values.Values.ToArray());
			}

			#endregion
		}
	}
}

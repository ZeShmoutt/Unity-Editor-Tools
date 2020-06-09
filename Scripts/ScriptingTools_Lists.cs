using System;
using System.Collections.Generic;
using System.Linq;

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
						int n = UnityEngine.Random.Range(1, list.Length);
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
					throw new IndexOutOfRangeException();
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
					throw new IndexOutOfRangeException("The object list and weight list lengths don't match.");
				}

				int total = 0;
				for (int i = 0; i < weights.Length; i++)
				{
					total += weights[i];
				}

				int rand = UnityEngine.Random.Range(0, total);
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

				throw new Exception("Something went wrong with the weighted random.");
			}

			/// <summary>
			/// Picks a random item from an array, using a list of weights to influence the random pick.
			/// </summary>
			/// <typeparam name="T">Type of item of the array.</typeparam>
			/// <param name="values">List of values to pick from.</param>
			/// <param name="weights">List of weights to associate to each value. Both lists must have the same count.</param>
			/// <returns>Returns a random element from the </returns>
			public static T WeightedRandom<T>(List<T> values, List<int> weights)
			{
				return WeightedRandom(values.ToArray(), weights.ToArray());
			}

			/// <summary>
			/// Picks a random item from an array, using a list of weights to influence the random pick.
			/// </summary>
			/// <typeparam name="T">Type of item of the array.</typeparam>
			/// <param name="values">Dictionary of weighted values to pick from.</param>
			/// <returns>Returns a random element from the </returns>
			public static T WeightedRandom<T>(Dictionary<T, int> values)
			{
				return WeightedRandom(values.Keys.ToArray(), values.Values.ToArray());
			}

			#endregion

			#region Add Unique

			/// <summary>
			/// Add an item to a list, but only if the list doesn't already contain an item that fits the specified comparison.
			/// </summary>
			/// <typeparam name="T">Type of item of the list.</typeparam>
			/// <param name="list">List to add the item to.</param>
			/// <param name="item">Item that will be added to the list.</param>
			/// <param name="comparator">Action used to compare two items.</param>
			public static void AddUnique<T>(List<T> list, T item, Predicate<T> comparator)
			{
				if (!list.Exists(comparator))
				{
					list.Add(item);
				}
			}

			/// <summary>
			/// Add numerous items to a list, but  for each of those items, only if the list don't already contain an item that fits the specified comparison.
			/// </summary>
			/// <typeparam name="T">Type of item of the list.</typeparam>
			/// <param name="list">List to add the item to.</param>
			/// <param name="item">Item that will be added to the list.</param>
			/// <param name="comparator">Action used to compare two items.</param>
			public static void AddUniqueRange<T>(List<T> list, List<T> collection, Predicate<T> comparator)
			{
				for (int i = 0; i < collection.Count; i++)
				{
					AddUnique(list, collection[i], comparator);
				}
			}

			#endregion
		}
	}
}

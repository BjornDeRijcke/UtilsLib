using System;

namespace UtilsLib.Extensions
{
	public static class ArrayExtensions
	{
		/// <summary>
		/// Rotates the given <paramref name="array"/> left, <paramref name="n"/> times.
		/// </summary>
		/// <typeparam name="T">Type of the elements of the array</typeparam>
		/// <param name="array">Input array</param>
		/// <param name="n">Amount of times to perform the rotate left operation</param>
		public static void RotateLeft<T>(this T[] array, int n)
		{
			if (array == null)
				throw new ArgumentNullException(nameof(array));
			if (n < 0)
				throw new IndexOutOfRangeException("n cannot be less than zero");

			n = n % array.Length;

			if (n == 0)
				return;

			Array.Reverse(array, 0, n);
			Array.Reverse(array, n, array.Length - n);
			Array.Reverse(array);
		}

		/// <summary>
		/// Rotates the given <paramref name="array"/> right, <paramref name="n"/> times.
		/// </summary>
		/// <typeparam name="T">Type of the elements of the array</typeparam>
		/// <param name="array">Input array</param>
		/// <param name="n">Amount of times to perform the rotate right operation</param>
		public static void RotateRight<T>(this T[] array, int n)
		{
			if (array == null)
				throw new ArgumentNullException(nameof(array));
			if (n < 0)
				throw new IndexOutOfRangeException("n cannot be less than zero");

			n = n % array.Length;

			if (n == 0)
				return;

			Array.Reverse(array, array.Length - n, n);
			Array.Reverse(array, 0, array.Length - n);
			Array.Reverse(array);
		}
	}
}

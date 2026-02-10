using UnityEngine;
using UnityEngine.TestTools.Utils;
using NUnit.Framework;

namespace helper.test.assert
{
	public static class vector3
	{
		/// <summary>
		/// hace un assert de los 2 vectores para una similaridad de 0.01f
		/// </summary>
		/// <param name="actual"></param>
		/// <param name="expected"></param>
		public static void similar( Vector3 actual, Vector3 expected )
		{
			Assert.That(
				actual,
				Is.EqualTo( expected ).Using( new Vector3EqualityComparer( 0.01f ) ) );
		}
	}
}

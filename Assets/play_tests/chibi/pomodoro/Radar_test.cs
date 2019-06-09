using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using chibi.radar;
using chibi.pomodoro;

namespace tests.pomodoro
{
	public class Test_pomodoro : helper.tests.Scene_test
	{
		public override string scene_dir
		{
			get {
				return "tests/scene/chibi/pomodoro/pomodoro";
			}
		}

		public override void Instanciate_scenary()
		{
			// base.Instanciate_scenary();
		}

		[UnityTest]
		public IEnumerator when_do_a_thick_should_add_the_delta_time()
		{
			Pomodoro pomodoro = Pomodoro.CreateInstance<Pomodoro>();
			Assert.AreEqual( 0, pomodoro._sigma_frecuency );
			Assert.Greater( pomodoro.frecuency, 0f );
			yield return new WaitForSeconds( 0.1f );
			pomodoro.tick();
			Assert.AreEqual( Time.deltaTime, pomodoro._sigma_frecuency );
		}

		[UnityTest]
		public IEnumerator when_sigma_is_greter_should_is_time_is_true()
		{
			Pomodoro pomodoro = Pomodoro.CreateInstance<Pomodoro>();
			Assert.AreEqual( 0, pomodoro._sigma_frecuency );
			Assert.Greater( pomodoro.frecuency, 0f );
			yield return new WaitForSeconds( 0.1f );
			pomodoro.tick( 10f );
			Assert.AreEqual( 10f, pomodoro._sigma_frecuency );
			Assert.IsTrue( pomodoro.is_time );
		}
	}
}

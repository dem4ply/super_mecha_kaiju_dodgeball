using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using SMKD.controller.npc;
using NUnit.Framework;

namespace tests.controller.motor.SMKD
{
	public class Dodger_catch : helper.tests.Scene_test
	{
		Assert_colision up, up_45;
		chibi.weapon.gun.Gun gun;
		Dodger_controller dodger;

		public override string scene_dir
		{
			get {
				return "SMKD/tests/scene/dodger/dodget catch";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			( up, up_45 ) = helper.game_object.Find._<Assert_colision>(
				scene, "assert up", "assert 45" );
			gun = helper.game_object.Find._<chibi.weapon.gun.Gun>(
				scene, "gun" );
			dodger = helper.game_object.Find._<Dodger_controller>(
				scene, "dodger mecha" );
		}

		[UnityTest]
		public IEnumerator when_is_touched_by_the_ball_should_died()
		{
			var bullet = gun.shot();
			yield return new WaitForSeconds( 2 );
			Assert.IsFalse( dodger.hp_motor.is_dead );
		}


		[UnityTest]
		public IEnumerator after_kill_the_dodger_the_ball_should_bounce()
		{
			var bullet = gun.shot();
			yield return new WaitForSeconds( 7 );
			up.assert_collision_enter( bullet );
		}
	}
}
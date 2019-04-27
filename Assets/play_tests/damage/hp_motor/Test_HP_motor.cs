using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;
using damage.motor;
using chibi.controller.ai;
using helper.test.assert;

namespace tests.damage.hp_motor
{
	public class Test_HP_motor : helper.tests.Scene_test
	{
		Assert_colision assert;
		Ai_walk ai;

		public override string scene_dir
		{
			get {
				return "tests/scene/damage/damage";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			assert = helper.game_object.Find._<Assert_colision>(
				scene, "assert" );
			ai = helper.game_object.Find._<Ai_walk>( scene, "npc" );
		}

		[UnityTest]
		public IEnumerator when_HP_motor_touch_a_damage_trigger_should_loss_hp()
		{
			ai.desire_direction = Vector3.forward;
			var hp = ai.GetComponent<HP_motor>();
			float start_hp = hp.current_points;
			yield return new WaitForSeconds( 1 );
			Assert.Less( hp.current_points, start_hp );
			assert.assert_collision_enter( ai.gameObject );
		}

		[UnityTest]
		public IEnumerator when_hp_is_0_or_less_the_motor_2d_should_be_dead()
		{
			ai.desire_direction = Vector3.forward;
			var hp = ai.GetComponent<HP_motor>();
			float start_hp = hp.current_points;

			Assert.Greater( start_hp, 0 );
			Assert.IsFalse( hp.is_dead );
			yield return new WaitForSeconds( 1 );
			Assert.LessOrEqual( hp.current_points, 0 );
			Assert.IsTrue( hp.is_dead );
		}
	}
}

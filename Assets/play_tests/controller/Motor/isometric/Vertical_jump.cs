using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using chibi.controller.npc;
using helper.test.assert;
using System.Linq;
using chibi.motor.npc;

namespace tests.controller.motor.isometric.jump
{
	public class Vertical_jump : helper.tests.Scene_test
	{
		Assert_colision jump, jump_2, jump_3;
		Controller_npc controller;

		public override string scene_dir
		{
			get {
				return "tests/scene/controller/motor/npc/motor isometric";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			jump = helper.game_object.Find._<Assert_colision>(
				scene, "assert jump 1" );

			jump_2 = helper.game_object.Find._<Assert_colision>(
				scene, "assert jump 2" );

			jump_3 = helper.game_object.Find._<Assert_colision>(
				scene, "assert jump 3" );

			controller = helper.game_object.Find._<Controller_npc>(
				scene, "npc" );
		}

		[UnityTest]
		public IEnumerator when_jump_shoult_touch_the_first_jump_assert()
		{
			yield return new WaitForSeconds( 2 );
			Motor_isometric motor = ( Motor_isometric )controller.motor;
			Assert.IsTrue(
				motor.is_grounded,
				"la colicion del motor no esta en el piso para poder saltar" );
			controller.jump();
			yield return new WaitForSeconds( 1 );
			jump.assert_collision_enter( controller.gameObject );
			jump_2.assert_collision_enter( controller.gameObject );
			jump_3.assert_not_collision_enter();
		}

		[UnityTest]
		public IEnumerator should_jump_the_expected_height()
		{
			List< float > diff = new List< float >();
			for ( int i = 0; i < 5; ++i )
			{
				yield return new WaitForSeconds( 1 );
				float lower_point = controller.transform.position.y;
				float expected_height = controller.motor_isometric.max_jump_heigh;
				controller.jump();
				float max_point = 0;
				for ( int j = 0; j < 100; ++j )
				{
					yield return null;
					float current_point = controller.transform.position.y;
					if ( current_point > max_point )
						max_point = current_point;
					if ( controller.motor.velocity.y < -0.01 )
						controller.stop_jump();
				}
				diff.Add( max_point - lower_point );
			}
			var avg = diff.Zip(diff.Skip(1), (first, second) => System.Math.Abs(second - first)).Average();
			Debug.Log( string.Format(
				"promedio de las diferencias {0}", avg ) );
			Assert.Less( avg, 0.1f, "la differencia de salto en promedio es mayor a 0.1" );
		}
	}
}

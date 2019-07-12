using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;
using UnityEngine;
using chibi.weapon.gun;
using chibi.spawner;
using chibi.damage.motor;
using chibi.controller.weapon.gun;
using helper.test.assert;

namespace tests.weapon.linerar.gun
{
	public class Test_auto_aim_gun: helper.tests.Scene_test
	{
		public Gun_aim_target_controller gun;
		public Assert_colision assert_1, assert_2;

		public override string scene_dir
		{
			get {
				return "tests/scene/chibi/weapon/gun/gun auto aim target";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			gun = helper.game_object.Find._<Gun_aim_target_controller>(
					scene, "gun" );
			assert_1 = helper.game_object.Find._<Assert_colision>(
					scene, "assert 1" );
			assert_2 = helper.game_object.Find._<Assert_colision>(
					scene, "assert 2" );
		}

		[UnityTest]
		public IEnumerator when_shot_should_kill_the_target()
		{
			gun.target.Value = assert_1.gameObject;
			var bullet = gun.shot()[0];
			yield return new WaitForSeconds( 1.5f );
			assert_1.assert_collision_enter( bullet );

			gun.target.Value = assert_2.gameObject;
			bullet = gun.shot()[0];
			yield return new WaitForSeconds( 1.5f );
			assert_2.assert_collision_enter( bullet );
		}
	}
}

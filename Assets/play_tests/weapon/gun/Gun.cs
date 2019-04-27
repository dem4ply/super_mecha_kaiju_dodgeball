using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using chibi.controller.weapon.gun.bullet;

namespace tests.controller.motor
{
	public class Gun : helper.tests.Scene_test
	{
		Assert_colision assert;
		chibi.weapon.gun.Gun gun;

		public override string scene_dir
		{
			get {
				return "tests/scene/chibi/weapon/gun/gun";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			assert = helper.game_object.Find._<Assert_colision>(
				scene, "assert" );
			gun = helper.game_object.Find._<chibi.weapon.gun.Gun>(
				scene, "linear_gun" );
		}

		[UnityTest]
		public IEnumerator when_shot_should_create_a_bullet()
		{
			var bullet = gun.shot();
			yield return new WaitForSeconds( 1 );
			tests_tool.assert.game_object.is_not_null( bullet );
		}
	}
}
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;
using UnityEngine;
using chibi.weapon.gun;
using chibi.spawner;
using chibi.damage.motor;

namespace tests.weapon.linerar.gun
{
	public class Test_linear_gun: helper.tests.Scene_test
	{
		public Linear_gun gun;
		public HP_engine hp;

		public override string scene_dir
		{
			get {
				return "tests/scene/chibi/weapon/gun/linear_gun";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			gun = helper.game_object.Find._<Linear_gun>( scene, "gun" );
			hp = helper.game_object.Find._<HP_engine>( scene, "hp_engine" );
		}

		[UnityTest]
		public IEnumerator when_shot_should_kill_the_target()
		{
			gun.shot();
			yield return new WaitForSeconds( 1f );
			Assert.IsTrue( hp.is_dead );
		}
	}
}
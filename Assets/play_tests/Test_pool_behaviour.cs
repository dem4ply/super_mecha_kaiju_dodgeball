using UnityEngine;
using NUnit.Framework;
using weapon.ammo;
using chibi.motor.weapons.gun.bullet;
using singleton.object_pool;
using chibi.pool;
using chibi;

namespace unit_tests.pool.chibi
{
	public class Test_pool_behavior : helper.tests.basic_test
	{
		[Test]
		public void should_create_the_container()
		{
			var pool = ScriptableObject.CreateInstance<Pool_behaviour>();
			var stuff = GameObject.Find(
				helper.consts.game_object_names.stuff );
			Assert.IsNotNull( stuff );
			var container = stuff.transform.Find( pool.container_name );
			Assert.IsNotNull( container );
			container = container.transform.Find( pool.name );
			Assert.IsNotNull( container );
		}
	}
}

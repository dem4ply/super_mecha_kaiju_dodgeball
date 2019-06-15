using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using chibi.rol_sheet;
using chibi.rol_sheet.buff.health;

namespace tests.rol_sheet
{
	public class Stat_variable : helper.tests.Scene_test
	{
		public Rol_sheet rol_sheet;

		public override string scene_dir
		{
			get {
				return "tests/scene/chibi/rol_sheet/rol_sheet variant";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			rol_sheet = helper.game_object.Find._<Rol_sheet>( scene, "npc" );
			Assert.IsTrue( rol_sheet );
		}

		public virtual chibi.rol_sheet.buff.Buff create_buff()
		{
			return Health_restore.CreateInstance<Health_restore>();
		}

		[UnityTest]
		public IEnumerator when_start_the_radar_should_be_empty()
		{
			yield return new WaitForSeconds( 0.1f );
			var stat = Resources.Load<chibi.rol_sheet.stat.Stat>(
				"tests/scene/chibi/rol_sheet/test_hp variable" );
			rol_sheet.hp.max += 40;
			stat.max += 10;
			Assert.AreEqual( rol_sheet.hp.max, stat.max );
			yield return new WaitForSeconds( 0.1f );
		}
	}
}
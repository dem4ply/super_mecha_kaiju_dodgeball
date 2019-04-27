using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using chibi.rol_sheet;
using chibi.rol_sheet.buff.health;
using chibi.rol_sheet.buff;

namespace tests.rol_sheet.buff
{
	public class item_Health_restore_test : Item_buff_test
	{
		public override Buff create_buff()
		{
			return Health_restore.CreateInstance<Health_restore>();
		}

		[UnityTest]
		public IEnumerator should_add_more_hp()
		{
			yield return new WaitForSeconds( 0.1f );
			var item = create_item_buff();
			var buff = ( Health_restore )item.buff;
			rol_sheet.max_hp = 10f;
			rol_sheet.hp = 1f;
			buff.duration = 3f;
			buff.amount = 1;
			item.use( rol_sheet );
			yield return new WaitForSeconds( 3f );
			Assert.AreEqual( 4, rol_sheet.hp, 0.05 );
		}
	}
}
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using chibi.rol_sheet.buff.health;
using chibi.rol_sheet.buff;

namespace tests.rol_sheet.buff.health
{
	public class Item_poison_test : Item_buff_test
	{
		public override Buff create_buff()
		{
			return Poison.CreateInstance<Poison>();
		}

		[UnityTest]
		public IEnumerator Should_reduce_the_hp()
		{
			yield return new WaitForSeconds( 0.1f );
			var item = create_item_buff();
			var buff = ( Poison )item.buff;
			rol_sheet.max_hp = 10f;
			rol_sheet.hp = 10f;
			buff.duration = 3f;
			buff.amount = 1;
			item.use( rol_sheet );
			yield return new WaitForSeconds( 3f );
			Assert.AreEqual( 7, rol_sheet.hp, 0.05 );
		}
	}
}
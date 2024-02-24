using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using chibi.motor.weapons.gun.bullet;
using metroidvania.singleton.object_pool;
using metroidvania.controller.weapons.gun.bullet;
using metroidvania.motor.weapons.gun.bullet;

namespace metroidvania.inventory.item
{
	[CreateAssetMenu( menuName = "metroidvania/inventory/item/base" )]
	public class Item_grid: chibi.inventory.item.Item
	{
		public int height = 1;
		public int width = 1;
	}
}

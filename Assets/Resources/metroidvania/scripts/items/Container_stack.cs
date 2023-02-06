using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using chibi.motor.weapons.gun.bullet;
using metroidvania.singleton.object_pool;
using metroidvania.controller.weapons.gun.bullet;
using metroidvania.motor.weapons.gun.bullet;

namespace metroidvania.inventory.item
{
	//[CreateAssetMenu( menuName = "metroidvania/inventory/item/container/base" )]
	public abstract class Container_stack : Container
	{
		public chibi.inventory.obj.Inventory_stack inventory;

		public bool is_empty
		{
			get {
				return inventory.is_empty;
			}
		}

		protected virtual void OnEnable()
		{
			if ( inventory == null )
			{
				inventory = new chibi.inventory.obj.Inventory_stack();
			}
		}

		public int amount
		{
			get {
				return inventory.amount;
			}
		}
	}
}

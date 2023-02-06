using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using chibi.motor.weapons.gun.bullet;

namespace metroidvania.inventory.item.container
{
	[CreateAssetMenu( menuName = "metroidvania/inventory/item/container/magazine" )]
	public class Magazine : Container_stack
	{
		public void push( chibi.inventory.item.Item item )
		{
			this.inventory.add( item );
		}

		public chibi.inventory.item.Item pop()
		{
			return this.inventory.pop();
		}
	}
}

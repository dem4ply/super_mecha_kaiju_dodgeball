using UnityEngine;
using System.Collections.Generic;
using weapon.ammo;
using chibi.motor.weapons.gun.bullet;
using chibi.inventory.item;
using singleton.object_pool;

namespace metroidvania.singleton.object_pool
{
	public class Cartidge_bullet_pool : Item_pool<Cartidge_bullet_pool>
	{
		public override string container_name
		{
			get {
				return "Cartidge_bullet_pool";
			}
		}

		public override GameObject instantiate( Item key )
		{
			var cartridge = key as metroidvania.inventory.item.Cartridge;
			if ( !cartridge )
				Debug.LogError(
					string.Format( "el {0} no es un item cartridge", key.name ), key );
			return cartridge.instanciate_bullet().gameObject;
		}
	}
}

using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using chibi.motor.weapons.gun.bullet;
using metroidvania.singleton.object_pool;
using metroidvania.controller.weapons.gun.bullet;
using metroidvania.motor.weapons.gun.bullet;

namespace metroidvania.inventory.item
{
	[CreateAssetMenu( menuName = "metroidvania/inventory/item/cartridge" )]
	public class Cartridge : chibi.inventory.item.Item
	{
		public GameObject casing;
		public Controller_bullet_cartridge bullet;

		public virtual Controller_bullet instanciate_bullet()
		{
			var obj = helper.instantiate._( bullet );
			obj.cartridge = this;
			return obj;
		}

		public virtual Controller_bullet_cartridge pop()
		{
			var obj = Cartidge_bullet_pool.instance.pop( this );
			return obj.GetComponent<Controller_bullet_cartridge>();
		}

		public virtual void push( GameObject bullet )
		{
			Cartidge_bullet_pool.instance.push( this, bullet );
		}

		public virtual void push( Controller_bullet_cartridge bullet )
		{
			Cartidge_bullet_pool.instance.push( this, bullet.gameObject );
		}

		public virtual void push( Bullet_motor_item bullet )
		{
			Cartidge_bullet_pool.instance.push( this, bullet.gameObject );
		}
	}
}

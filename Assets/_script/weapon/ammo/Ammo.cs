using UnityEngine;
using chibi.motor.weapons.gun.bullet;

namespace weapon
{
	namespace ammo
	{
		[ CreateAssetMenu( menuName="weapon/gun/ammo/base") ]
		public class Ammo : chibi.Chibi_object
		{
			public Bullet_motor prefab_bullet;

			public override string path_of_the_default
			{
				get { return "object/weapon/gun/ammo/default"; }
			}

			protected virtual Bullet_motor instanciate()
			{
				Bullet_motor obj =
					singleton.object_pool.Ammo_pool.instance.pop( this );
				return obj;
			}

			protected virtual Bullet_motor instanciate( Vector3 position )
			{
				Bullet_motor obj = instanciate();
				obj.transform.position = position;
				return obj;
			}

			public virtual Bullet_motor instanciate(
				Vector3 position, chibi.rol_sheet.Rol_sheet owner )
			{
				Bullet_motor obj = instanciate( position );
				var controller = obj.GetComponent<
					chibi.controller.weapon.gun.bullet.Controller_bullet>();
				var damages = controller.damages;
				foreach ( var damage in damages )
					damage.owner = owner;
				return obj;
			}

			public virtual void push( Bullet_motor bullet )
			{
				singleton.object_pool.Ammo_pool.instance.push( bullet );
			}
		}
	}
}

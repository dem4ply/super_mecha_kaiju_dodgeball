using UnityEngine;
using Unity.Entities;
using chibi.motor.weapons.gun.bullet;

namespace chibi.systems.weapon.gun.bullet
{
	public class Bullet : ComponentSystem
	{
		struct group
		{
			public chibi.motor.weapons.gun.bullet.Bullet_motor motor;
			public Rigidbody rigidbody;
		}

		protected override void OnUpdate()
		{
			foreach ( var entity in GetEntities<group>() )
			{
				entity.motor.desire_speed = entity.motor.max_speed;
				Vector3 desire_velocity = entity.motor.desire_velocity;
				entity.rigidbody.velocity = desire_velocity;
			}
		}
	}
}

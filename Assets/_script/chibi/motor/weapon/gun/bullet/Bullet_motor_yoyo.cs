using UnityEngine;
using weapon.ammo;

namespace chibi.motor.weapons.gun.bullet
{
	public class Bullet_motor_yoyo : Bullet_motor
	{
		public Transform target;
		public Transform origin;
		public float distant_for_return = 0.1f;

		protected override void FixedUpdate()
		{
			base.FixedUpdate();
			float distance = Vector3.Distance( transform.position, target.position );
			if ( distance < distant_for_return )
			{
				if ( origin )
				{
					target = origin;
					origin = null;
				}
				else
				{
					recycle();
				}
			}
			desire_direction = target.position - transform.position;
		}
	}
}

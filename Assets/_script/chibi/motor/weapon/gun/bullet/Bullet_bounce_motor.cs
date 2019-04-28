using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;
using weapon.ammo;

namespace chibi.motor.weapons.gun.bullet
{
	public class Bullet_bounce_motor : Motor
	{

		private void OnCollisionEnter( Collision collision )
		{
			var new_direction = Vector3.Reflect( desire_direction, collision.contacts[ 0 ].normal );
			desire_direction = new_direction;
		}
	}
}

using UnityEngine;
using weapon.ammo;
using chibi.motor.npc;

namespace fisher.motor.weapons.gun.bullet
{
	public class Fish_motor : Motor_isometric
	{
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
			transform.LookAt(
				transform.position + ridgetbody.velocity );
		}
	}
}

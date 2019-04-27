using System.Collections;
using System.Collections.Generic;
using chibi.controller.weapon.gun.bullet;
using UnityEngine;

namespace chibi.weapon.gun
{
	public class Linear_gun : Gun
	{
		public override Controller_bullet shot()
		{
			var bullet = ammo.instanciate( transform.position, owner );
			var controller = bullet.GetComponent<Controller_bullet>();
			controller.desire_direction = direction_shot;
			return controller;
		}
	}
}

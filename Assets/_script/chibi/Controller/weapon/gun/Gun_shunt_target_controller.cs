﻿using System.Collections.Generic;
using chibi.damage;
using UnityEngine;
using chibi.weapon.gun;
using chibi.controller.weapon.gun.bullet;

namespace chibi.controller.weapon.gun
{
	public class Gun_shunt_target_controller : Gun_single_controller
	{
		public chibi.tool.reference.Game_object_reference target;

		public override List<Controller_bullet> shot()
		{
			gun.aim_direction = 
				gun.transform.position - target.Value.transform.position;
			return base.shot();
		}
	}
}

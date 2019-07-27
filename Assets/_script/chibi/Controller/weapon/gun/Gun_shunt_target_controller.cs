using System.Collections.Generic;
using chibi.damage;
using UnityEngine;
using chibi.weapon.gun;
using chibi.controller.weapon.gun;
using System.Collections.Generic;
using chibi.damage;
using UnityEngine;
using chibi.weapon.gun;
using chibi.controller.weapon.gun.bullet;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using chibi.controller.weapon.gun;
using chibi.weapon.gun;

namespace chibi.controller.weapon.gun.single
{
	public class Gun_shunt_target_controller : Controller_gun_single
	{
		public chibi.tool.reference.Game_object_reference target;

		public override List<Controller_bullet> shot()
		{
			debug.info( "sfdasdf" );
			gun.aim_direction = 
				gun.transform.position - target.Value.transform.position;
			return base.shot();
		}
	}
}

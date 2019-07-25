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
	public class Controller_gun_burst_single : Controller_gun_single
	{
		public override List<Controller_bullet> shot()
		{
			gun.burst();
			return null;
		}
	}
}

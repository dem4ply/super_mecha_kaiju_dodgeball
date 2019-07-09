using System.Collections.Generic;
using chibi.damage;
using UnityEngine;
using chibi.weapon.gun;
using chibi.controller.weapon.gun.bullet;

namespace chibi.controller.weapon.gun
{
	public class Controller_gun : Controller
	{
		public virtual List<Controller_bullet> shot()
		{
			throw new System.NotImplementedException();
		}
	}
}

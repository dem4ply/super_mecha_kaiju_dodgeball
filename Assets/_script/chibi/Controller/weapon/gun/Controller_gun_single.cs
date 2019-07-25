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
	public class Controller_gun_single : Controller_gun
	{
		public Gun gun;

		public override List<Controller_bullet> shot()
		{
			return new List<Controller_bullet>{ gun.shot() };
		}

		protected override void _init_cache()
		{
			base._init_cache();
			gun = GetComponent<Gun>();
			if ( !gun )
				debug.error( "no se encontro una `gun`" );
		}
	}
}

using System.Collections.Generic;
using chibi.damage;
using UnityEngine;
using chibi.weapon.gun;
using chibi.controller.weapon.gun.bullet;

namespace chibi.controller.weapon.gun
{
	public class Gun_single_controller : Controller_gun
	{
		public Gun gun;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !gun )
				gun = GetComponent< chibi.weapon.gun.Gun >();
			if ( !gun )
				debug.error( "no se encontro un 'Gun'" );
		}
	}
}

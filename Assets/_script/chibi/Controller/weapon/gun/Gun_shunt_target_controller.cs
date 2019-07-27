using System.Collections.Generic;
using chibi.controller.weapon.gun.bullet;

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

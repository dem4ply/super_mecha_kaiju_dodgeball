using UnityEngine;
using chibi.controller.weapon.gun.bullet;

namespace fisher.controller
{
	public class Fisher_controller : chibi.controller.npc.Controller_npc
	{
		public chibi.weapon.gun.Gun gun;
		public GameObject prefab_target_net;

		public void throw_net( Vector3 position )
		{
			gun.aim_to( position );
			Controller_bullet_chaser bullet = (Controller_bullet_chaser)gun.shot();
			var target_net = helper.instantiate._( prefab_target_net, position );
			bullet.target = target_net.transform;
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !gun )
				Debug.Log( string.Format(
					"[Fisher_controller] no tiene asigna un arma en '{0}'",
					helper.game_object.name.full( this ), gameObject ) );
		}
	}
}
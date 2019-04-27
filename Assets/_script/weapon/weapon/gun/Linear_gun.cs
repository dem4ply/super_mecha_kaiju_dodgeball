using UnityEngine;
using controller.controllers;
using rol_sheet;

namespace weapon
{
	namespace gun
	{
		public class Linear_gun : Gun_base
		{
			public Vector3 direction_shot
			{
				get { return transform.forward.normalized; }
			}

			public override Bullet_controller_3d shot()
			{
				throw new System.NotImplementedException();
			}

			public override Bullet_controller_3d shot( Rol_sheet owner )
			{
				throw new System.NotImplementedException();
			}

			/*
			public override Bullet_controller_3d shot()
			{
				var bullet = ammo.instanciate( transform.position, owner );
				bullet.shot( direction_shot );
				return bullet;
			}

			public override Bullet_controller_3d shot( Rol_sheet owner )
			{
				var bullet = ammo.instanciate( transform.position, owner );
				bullet.shot( direction_shot );
				return bullet;
			}
			*/


			protected void OnDrawGizmos()
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawWireSphere( transform.position, 0.2f );
				Gizmos.color = Color.red;
				helper.draw.arrow.gizmo( transform.position, direction_shot );
			}

		}
	}
}
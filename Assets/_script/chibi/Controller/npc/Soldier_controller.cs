using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using rol_sheet;

namespace chibi.controller.npc
{
	public class Soldier_controller : Controller_npc
	{
		public chibi.controller.weapon.gun.turrent.Controller_turrent turrent;
		public chibi.controller.npc.Controller_npc npc;
		public Transform hold_turrent_position;

		public Rol_sheet rol;

		public bool is_using_turrent = false;

		#region funciones de controller
		public override Vector3 desire_direction
		{
			get {
				return base.desire_direction;
			}

			set {
				if ( is_using_turrent )
					turrent.desire_direction = value;
				else
					npc.desire_direction = value;
			}
		}

		public override float speed
		{
			get {
				return base.speed;
			}

			set {
				if ( is_using_turrent )
					turrent.speed = value;
				else
					npc.speed = value;
			}
		}
		#endregion

		#region controlles de torreta
		public void release_turrent()
		{
			turrent.owner = null;
			is_using_turrent = false;
		}

		public void grab_turrent()
		{
			if ( turrent )
			{
				turrent.owner = rol;
				is_using_turrent = true;
			}
		}

		public List< Controller_bullet > shot()
		{
			if ( is_using_turrent )
				return turrent.shot();
			return null;
		}
		#endregion

		protected override void _init_cache()
		{
			base._init_cache();
			rol = GetComponent< Rol_sheet >();
			if ( !rol )
				Debug.LogError( string.Format(
					"[soldier controller] no encontro un 'Rol_sheet' en {0}",
					helper.game_object.name.full( this ) ) );
		}

		protected override void load_motors()
		{
			//base.load_motors();
		}
	}
}

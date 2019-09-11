using UnityEngine;
using System.Collections.Generic;
using System;
using chibi.motor;
using chibi.motor.npc;
using chibi.manager.collision;

namespace chibi.controller.npc
{
	public class Controller_npc : Controller_motor
	{
		public chibi.damage.motor.HP_engine hp;

		public Chibi_collision_manager manager_collision;

		public virtual Motor_side_scroll motor_side_scroll
		{
			get { return motor as Motor_side_scroll; }
		}

		public virtual Motor_isometric motor_isometric
		{
			get { return motor as Motor_isometric; }
		}

		protected override void _init_cache()
		{
			base._init_cache();
			hp = GetComponent<chibi.damage.motor.HP_engine>();
			manager_collision = GetComponent< Chibi_collision_manager >();
		}

		#region manejo de salto
		public virtual void jump()
		{
			if ( motor_side_scroll != null )
				motor_side_scroll.start_jump();
			else if ( motor_isometric != null )
				motor_isometric.start_jump();
		}

		public virtual void stop_jump()
		{
			if ( motor_side_scroll != null )
				motor_side_scroll.end_jump();
			else if ( motor_isometric != null )
				motor_isometric.end_jump();
		}
		#endregion

		#region hp
		public virtual void died()
		{
			if ( !hp )
			{
				debug.error( "no tiene un HP_engine" );
			}
			else
				hp.died();
		}
		#endregion
	}
}

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

		[Header( "Wall manager" )]
		public float max_slope_angle = 45f;

		public Vector3 angle_vector_for_wall = Vector3.up;
		public float min_angle_for_wall = 70f;
		public float max_angle_for_wall = 110;

		public static string STR_WALL = "wall";
		public static string STR_FLOOR = "floor";

		public chibi.damage.motor.HP_engine hp;

		public Chibi_collision_manager manager_collision;

		public virtual Motor_side_scroll motor_side_scroll
		{
			get { return motor as Motor_side_scroll; }
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
			( (Motor_side_scroll)motor ).try_to_jump_the_next_update = true;
		}

		public virtual void stop_jump()
		{
			( (Motor_side_scroll)motor ).try_to_jump_the_next_update = false;
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

using UnityEngine;
using System;

namespace chibi.motor.npc
{
	public class Motor_side_scroll : Motor
	{
		[Header( "animator" )]
		// public Platformer_animator_npc animator;

		[Header( "jump" )]
		public float max_jump_heigh = 4f;
		public float min_jump_heigh = 1f;
		public float jump_time = 0.4f;

		public float max_jump_velocity;
		public float min_jump_velocity;
		public float gravity = -9.8f;

		public float multiplier_velocity_wall_slice = 0.8f;
		public int last_direction = 0;

		[Header( "wall jump" )]
		public Vector3 wall_jump_climp = new Vector3( 0, 14, 14 );
		public Vector3 wall_jump_off = new Vector3( 0, 5, 8 );
		public Vector3 wall_jump_leap = new Vector3( 0, 20, 14 );

		public float acceleration_time_in_ground = 0.1f;
		public float acceleration_time_in_air = 0.2f;

		public static string STR_WALL = "wall";
		public static string STR_WALL_left = "wall left";
		public static string STR_WALL_right = "wall right";
		public static string STR_FLOOR = "floor";

		protected bool _is_running = false;
		public bool try_to_jump_the_next_update = false;
		protected bool _is_grounded = false;

		protected float horizontal_velocity_smooth;

		public override Vector3 desire_direction
		{
			set {
				base.desire_direction = new Vector3( 0, 0, value.z );
			}
		}

		#region propiedades publicas
		public virtual bool is_grounded
		{
			get {
				return manager_collisions[ STR_FLOOR ];
			}
		}

		public virtual bool is_not_grounded
		{
			get {
				return !is_grounded;
			}
		}

		public virtual bool is_walled
		{
			get {
				return manager_collisions[ STR_WALL ];
			}
		}

		public virtual bool is_not_walled
		{
			get {
				return !is_walled;
			}
		}

		public virtual bool is_walled_left
		{
			get {
				return manager_collisions[ STR_WALL_left ];
			}
		}

		public virtual bool is_walled_right
		{
			get {
				return manager_collisions[ STR_WALL_right ];
			}
		}

		public virtual bool no_is_walled_left
		{
			get {
				return !is_walled_left;
			}
		}

		public virtual bool no_is_walled_right
		{
			get {
				return !is_walled_right;
			}
		}

		public virtual bool is_jumping
		{
			get; set;
		}
		#endregion

		protected override void update_motion()
		{
			current_speed = desire_velocity;
			Vector3 velocity_vector = Vector3.zero;
			if ( is_grounded )
				velocity_vector = new Vector3(
					current_speed.x, ridgetbody.velocity.y,
					current_speed.z );
			else
				velocity_vector = ridgetbody.velocity;

			_proccess_gravity( ref velocity_vector );
			_process_jump( ref velocity_vector );

			ridgetbody.velocity = velocity_vector;
		}

		protected virtual void _process_jump(ref Vector3 speed_vector)
		{
			if ( try_to_jump_the_next_update )
			{
				if ( false && is_walled && is_not_grounded )
				{
					int jump_direction = is_walled_left ? -1 : 1;
					if ( Math.Sign( desire_direction.z ) == jump_direction )
					{
						speed_vector.z = -jump_direction * wall_jump_climp.z;
						speed_vector.y = wall_jump_climp.y;
					}
					else if ( desire_direction.z == 0 )
					{
						speed_vector.z = -jump_direction * wall_jump_off.z;
						speed_vector.y = wall_jump_off.y;
					}
					else
					{
						speed_vector.z = -jump_direction * wall_jump_leap.z;
						speed_vector.y = wall_jump_leap.y;
					}
				}
				else if ( is_grounded )
				{
					speed_vector.y = max_jump_velocity;
				}
			}
			else if ( speed_vector.y > min_jump_velocity )
				speed_vector.y = min_jump_velocity;
		}

		protected virtual void _proccess_gravity(
				ref Vector3 velocity_vector )
		{
			velocity_vector.y += ( gravity * Time.deltaTime );

			if ( is_not_grounded && is_walled )
				velocity_vector.y *= multiplier_velocity_wall_slice;
		}

		protected override void _init_cache()
		{
			base._init_cache();

			gravity = -( 2 * max_jump_heigh ) / ( jump_time * jump_time );
			max_jump_velocity = Math.Abs( gravity ) * jump_time;
			min_jump_velocity = ( float )Math.Sqrt(
				2.0 * Math.Abs( gravity ) * min_jump_heigh );
		}
	}
}

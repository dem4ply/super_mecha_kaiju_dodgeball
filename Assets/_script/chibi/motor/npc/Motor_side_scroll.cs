using UnityEngine;
using System;
using chibi.manager.collision;

namespace chibi.motor.npc
{
	public class Motor_side_scroll : Motor
	{
		// [Header( "animator" )]
		// public Platformer_animator_npc animator;

		[Header( "jump" )]
		protected float _max_jump_heigh = 4f;
		protected float _min_jump_heigh = 1f;
		protected float _jump_time = 0.4f;

		protected float _max_jump_velocity;
		protected float _min_jump_velocity;
		protected float _gravity = -9.8f;

		public float multiplier_velocity_wall_slice = 0.8f;

		[Header( "wall jump" )]
		public Vector3 wall_jump_climp = new Vector3( 0, 14, 14 );
		public Vector3 wall_jump_off = new Vector3( 0, 5, 8 );
		public Vector3 wall_jump_leap = new Vector3( 0, 20, 14 );

		public float acceleration_time_in_ground = 0.1f;
		public float acceleration_time_in_air = 0.2f;

		public bool try_to_jump_the_next_update = false;

		public override Vector3 desire_direction
		{
			set {
				base.desire_direction = new Vector3( 0, 0, value.z );
			}
		}

		public virtual float max_jump_heigh
		{
			get { return _max_jump_heigh; }
			set {
				_max_jump_heigh = value;
				update_jump_properties();
			}
		}

		public virtual float min_jump_heigh
		{
			get { return _min_jump_heigh; }
			set {
				_min_jump_heigh = value;
				update_jump_properties();
			}
		}

		public virtual float jump_time
		{
			get { return _jump_time; }
			set {
				jump_time = value;
				update_jump_properties();
			}
		}

		public virtual float gravity
		{
			get { return _gravity; }
		}

		public virtual float max_jump_velocity
		{
			get { return _max_jump_velocity; }
		}

		public virtual float min_jump_velocity
		{
			get { return _min_jump_velocity; }
		}

		#region propiedades publicas
		public virtual Chibi_collision_side_scroll collision_manager_side_scroll
		{
			get { return manager_collision as Chibi_collision_side_scroll; }
		}
		#region propiedades conocer el estado de las coliciones
		public virtual bool is_grounded
		{
			get { return collision_manager_side_scroll.is_grounded; }
		}

		public virtual bool is_not_grounded
		{
			get { return !is_grounded; }
		}

		public virtual bool is_walled
		{
			get { return collision_manager_side_scroll.is_walled; }
		}

		public virtual bool is_not_walled
		{
			get { return !is_walled; }
		}

		public virtual bool is_walled_left
		{
			get { return collision_manager_side_scroll.is_walled_left; }
		}

		public virtual bool is_walled_right
		{
			get { return collision_manager_side_scroll.is_walled_right; }
		}

		public virtual bool no_is_walled_left
		{
			get { return !is_walled_left; }
		}

		public virtual bool no_is_walled_right
		{
			get { return !is_walled_right; }
		}
		#endregion
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
					speed_vector.y = _max_jump_velocity;
				}
			}
			else if ( speed_vector.y > _min_jump_velocity )
				speed_vector.y = _min_jump_velocity;
		}

		protected virtual void _proccess_gravity(
				ref Vector3 velocity_vector )
		{
			velocity_vector.y += ( _gravity * Time.deltaTime );

			if ( is_not_grounded && is_walled )
				velocity_vector.y *= multiplier_velocity_wall_slice;
		}

		protected override void _init_cache()
		{
			base._init_cache();
			update_jump_properties();
		}


		protected virtual void update_jump_properties()
		{
			_gravity = -( 2 * max_jump_heigh ) / ( jump_time * jump_time );
			_max_jump_velocity = Math.Abs( _gravity ) * jump_time;
			_min_jump_velocity = ( float )Math.Sqrt(
				2.0 * Math.Abs( _gravity ) * min_jump_heigh );
		}
	}
}

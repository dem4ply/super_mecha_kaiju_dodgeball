using UnityEngine;
using System;
using chibi.manager.collision;

namespace chibi.motor.npc
{
	public class Motor_side_scroll : Motor_physical
	{
		// [Header( "animator" )]
		public chibi.animator.Animator_side_scroll animator;

		public float max_slope_anlge = 45f;

		#region variables de jump
		[SerializeField]
		protected float _max_jump_heigh = 4f;
		[SerializeField]
		protected float _min_jump_heigh = 1f;
		[SerializeField]
		protected float _wall_climp_jump_heigh = 3f;

		[SerializeField]
		protected float _jump_time = 0.4f;
		[SerializeField]
		protected float _falling_time = 0.4f;
		[SerializeField]
		protected float _gravity_when_fall = -10f;
		[SerializeField]
		protected float _jump_time_wall_climp = 0.4f;

		protected bool do_wall_jump_climp = false;
		public float climp_wall_jump_ignore_input = 1f;
		public float wall_jump_off_ignore_input = 1f;

		public float grabity_after_wall_jump_climp = -10f;
		public float slope_gravity = -10f;

		protected float _max_jump_velocity;
		protected float _min_jump_velocity;
		protected float _climp_wall_jump_velocity;

		public float multiplier_velocity_wall_slice = 0.8f;
		public float multiplier_velocity_climp_jump = 0.8f;

		public Vector3 wall_jump_climp = new Vector3( 0, 14, 14 );
		public Vector3 wall_jump_off = new Vector3( 0, 5, 8 );
		public Vector3 wall_jump_leap = new Vector3( 0, 20, 14 );
		#endregion

		public float time_to_reach_speed_in_ground = 0.1f;
		public float time_to_reach_speed_in_air = 0.2f;

		protected bool try_to_jump_the_next_update = false;
		protected bool want_to_stop_jump = false;

		public int current_direction = 0;

		protected float current_horizontal_time_smooth = 0f;

		#region propiedades publicas
		public override Vector3 desire_direction
		{
			set {
				base.desire_direction = new Vector3( 0, 0, value.z );
			}
		}

		public virtual bool want_to_move
		{
			get {
				return desire_direction.z > 0.01 || desire_direction.z < -0.01;
			}
		}

		public virtual bool want_to_no_move
		{
			get { return !want_to_move; }
		}

		public virtual Chibi_collision_side_scroll collision_manager_side_scroll
		{
			get { return manager_collision as Chibi_collision_side_scroll; }
		}

		#region propiedades de salto
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

		public virtual float wall_climp_jump_heigh
		{
			get { return _wall_climp_jump_heigh; }
			set {
				_wall_climp_jump_heigh = value;
				update_jump_properties();
			}
		}

		public virtual float jump_time
		{
			get { return _jump_time; }
			set {
				_jump_time = value;
				update_jump_properties();
			}
		}

		public virtual float jump_time_wall_climp
		{
			get { return _jump_time_wall_climp; }
			set {
				_jump_time_wall_climp = value;
				update_jump_properties();
			}
		}

		public virtual float falling_time
		{
			get { return _falling_time; }
			set {
				_falling_time = value;
				update_jump_properties();
			}
		}

		public virtual float gravity_when_fall
		{
			get { return _gravity_when_fall; }
			set {
				_gravity_when_fall = value;
			}
		}

		public virtual float max_jump_velocity
		{
			get { return _max_jump_velocity; }
		}

		public virtual float min_jump_velocity
		{
			get { return _min_jump_velocity; }
		}

		public virtual float climp_wall_jump_velocity
		{
			get { return _climp_wall_jump_velocity; }
		}
		#endregion

		#region propiedades conocer el estado de las coliciones
		public virtual bool is_grounded
		{
			get { return collision_manager_side_scroll.is_grounded; }
		}

		public virtual bool is_not_grounded
		{
			get { return !is_grounded; }
		}

		public virtual bool is_in_slope
		{
			get { return collision_manager_side_scroll.is_in_slope; }
		}

		public virtual bool is_not_in_slope
		{
			get { return !is_in_slope; }
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

		public virtual Vector3 wall_direction
		{
			get {
				if ( is_walled_left )
					return Vector3.back;
				else if ( is_walled_right )
					return Vector3.forward;
				else
					return Vector3.zero;
			}
		}

		public virtual bool can_do_wall_jump
		{
			get {
				return is_walled && is_not_grounded && is_not_in_slope;
			}
		}

		public virtual bool can_do_jump
		{
			get { return is_grounded || is_in_slope; }
		}

		#endregion

		#endregion

		protected override void update_motion()
		{
			current_speed = velocity;
			Vector3 velocity_vector = velocity;

			update_change_direction( ref velocity_vector );

			float slope_angle = collision_manager_side_scroll.slope(
				Chibi_collision_side_scroll.STR_SLOPE );

			if ( is_grounded )
			{
				_proccess_ground_horizontal_velocity( ref velocity_vector );
				_process_jump( ref velocity_vector );
				_proccess_gravity( ref velocity_vector );
			}
			else if ( is_in_slope && slope_angle > 0f
				&& slope_angle < max_slope_anlge )
			{
				_proccess_ground_horizontal_velocity( ref velocity_vector );
				_proccess_slope_velocity( ref velocity_vector, slope_angle );
				_process_jump( ref velocity_vector );
				// _proccess_slope_gravity_gravity( ref velocity_vector );
				if ( -0.001 > velocity_vector.z && velocity_vector.z > 0.01f )
					_proccess_gravity( ref velocity_vector );
			}
			else
			{
				_proccess_air_horizontal_velocity( ref velocity_vector );
				_process_jump( ref velocity_vector );
				_proccess_gravity( ref velocity_vector );
			}

			if ( try_to_jump_the_next_update && velocity_vector.y < 0.01 )
			{
				end_jump();
			}

			ridgetbody.velocity = velocity_vector;
			// debug.draw.arrow( velocity_vector, Color.magenta, duration:1f );

			update_animator();
		}

		protected virtual void update_animator()
		{
			animator.speed = ridgetbody.velocity.z;
			animator.vertical_speed = ridgetbody.velocity.y;
			animator.is_grounded = is_grounded || is_in_slope;
			if ( is_not_grounded )
			{
				Vector3 vector_current_direction = new
					Vector3( 0, 0, current_direction );
				if ( vector_current_direction == wall_direction )
					animator.is_walled = true;
				else
					animator.is_walled = false;
			}
			else
				animator.is_walled = is_walled;
			animator.direction = new Vector3( current_direction, 0, 0 );
		}

		protected virtual void _proccess_ground_horizontal_velocity(
			ref Vector3 velocity_vector )
		{
			_proccess_horizontal_velocity(
				ref velocity_vector, time_to_reach_speed_in_ground );
		}

		protected virtual void _proccess_slope_velocity(
			ref Vector3 velocity_vector, float slope_angle )
		{
			Vector3 slope_normal = collision_manager_side_scroll.normal(
				Chibi_collision_side_scroll.STR_SLOPE );

			if ( slope_normal != Vector3.zero
				&& ( -0.1 > velocity_vector.z  || velocity_vector.z < 0.1 ) )
			{
				velocity_vector = Vector3.ProjectOnPlane( 
					velocity_vector, slope_normal );
				debug.draw.arrow( slope_normal, Color.yellow, duration:1f );
				debug.draw.arrow( velocity_vector, Color.black, duration:1f );
			}
		}

		protected virtual void _proccess_air_horizontal_velocity(
			ref Vector3 velocity_vector )
		{
			if ( want_to_no_move )
				return;
			Vector3 vector_current_direction = new Vector3(
				0, 0, current_direction );
			if ( is_walled )
			{
				if ( vector_current_direction == wall_direction )
					velocity_vector.z = 0;
				else
					_proccess_horizontal_velocity(
						ref velocity_vector, time_to_reach_speed_in_air );
			}
			else
			{
				if ( do_wall_jump_climp )
					_proccess_horizontal_velocity(
						ref velocity_vector,
						this.desire_speed * multiplier_velocity_climp_jump,
						this.max_speed, time_to_reach_speed_in_air );
				else
					_proccess_horizontal_velocity(
						ref velocity_vector, time_to_reach_speed_in_air );
			}
		}

		protected virtual void _proccess_horizontal_velocity(
			ref Vector3 velocity_vector, float time_to_reach_target )
		{
			_proccess_horizontal_velocity(
				ref velocity_vector, this.desire_speed, this.max_speed,
				time_to_reach_target );
		}

		protected virtual void _proccess_horizontal_velocity(
			ref Vector3 velocity_vector, float desire_speed,
			float max_speed, float time_to_reach_target )
		{
			float desire_horizontal_velocity =
				desire_direction.z * Mathf.Clamp( desire_speed, 0, max_speed );
			float current_horizontal_velocity = velocity_vector.z;

			float final_horizontal_velocity = Mathf.SmoothDamp(
				current_horizontal_velocity, desire_horizontal_velocity,
				ref current_horizontal_time_smooth, time_to_reach_target );

			velocity_vector.z = final_horizontal_velocity;
		}

		protected virtual void update_change_direction(
			ref Vector3 velocity_vector )
		{
			if ( want_to_move )
			{
				int new_dir = Math.Sign( desire_direction.z );
				if ( new_dir != 0 && new_dir != current_direction )
					current_direction = new_dir;
			}
		}

		protected virtual void _process_jump(ref Vector3 speed_vector)
		{
			if ( try_to_jump_the_next_update )
			{
				if ( can_do_wall_jump )
				{
					int jump_direction = is_walled_left ? -1 : 1;
					current_direction = -jump_direction;
					if ( Math.Sign( desire_direction.z ) == jump_direction )
					{
						do_wall_jump_climp = true;
						desire_direction = -desire_direction;
						start_to_ignore_input( climp_wall_jump_ignore_input );
						speed_vector.z = -jump_direction * wall_jump_climp.z;
						speed_vector.y = climp_wall_jump_velocity;
					}
					else if ( desire_direction.z == 0 )
					{
						desire_direction = Vector3.zero;
						desire_speed = 0f;
						start_to_ignore_input( wall_jump_off_ignore_input );
						speed_vector.z = -jump_direction * wall_jump_off.z;
						speed_vector.y = wall_jump_off.y;
					}
					else
					{
						desire_direction = Vector3.zero;
						desire_speed = 0f;
						start_to_ignore_input( wall_jump_off_ignore_input );
						speed_vector.z = -jump_direction * wall_jump_leap.z;
						speed_vector.y = wall_jump_leap.y;
					}
				}
				else if ( can_do_jump )
				{
					speed_vector.y = max_jump_velocity;
				}
				try_to_jump_the_next_update = false;
			}
			else if ( want_to_stop_jump
				&& speed_vector.y > _min_jump_velocity )
			{
				speed_vector.y = _min_jump_velocity;
				want_to_stop_jump = false;
			}
			else
			{
				want_to_stop_jump = false;
			}
		}

		protected override void _proccess_gravity(
				ref Vector3 velocity_vector )
		{

			if ( is_not_grounded && is_walled )
				velocity_vector.y += gravity
					* multiplier_velocity_wall_slice * Time.deltaTime;
			else
			{
				if ( velocity_vector.y > 0 )
					if ( do_wall_jump_climp )
						velocity_vector.y +=
							grabity_after_wall_jump_climp * Time.deltaTime;
					else
						velocity_vector.y += ( gravity * Time.deltaTime );
				else
				{
					velocity_vector.y += ( gravity_when_fall * Time.deltaTime );
					do_wall_jump_climp = false;
					stop_to_ignore_input();
				}
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			update_jump_properties();
			if ( !animator )
				debug.error( "no esta asignado el animator" );
		}

		protected virtual void update_jump_properties()
		{
			gravity = -( 2 * max_jump_heigh ) / ( jump_time * jump_time );
			gravity_when_fall = -( 2 * max_jump_heigh ) / ( falling_time * falling_time );
			grabity_after_wall_jump_climp  =
				-( 2 * wall_climp_jump_heigh )
				/ ( jump_time_wall_climp * jump_time_wall_climp );

			_max_jump_velocity = Math.Abs( _gravity ) * jump_time;
			_min_jump_velocity = ( float )Math.Sqrt(
				2.0 * Math.Abs( _gravity ) * min_jump_heigh );
			_climp_wall_jump_velocity =
				Math.Abs( grabity_after_wall_jump_climp ) * jump_time_wall_climp;
		}

		public void start_jump()
		{
			try_to_jump_the_next_update = true;
		}

		public void end_jump()
		{
			try_to_jump_the_next_update = false;
			want_to_stop_jump = true;
		}
	}
}

using UnityEngine;
using System.Collections.Generic;
using System;


namespace controller
{
	namespace motor
	{
		public class NPC_side_scroll_motor_3d : NPC_motor_3d
		{
			public float max_jump_heigh = 4f;
			public float min_jump_heigh = 1f;
			public float jump_time = 0.4f;

			public float max_jump_velocity;
			public float min_jump_velocity;
			public float gravity = -9.8f;

			public bool try_to_jump_next_update = false;

			#region variables para la clasificacion de los colliders
			public Vector3 angle_vector_for_floor = Vector3.left;
			public float min_angle_for_floor = 20f;
			public float max_angle_for_floor = 160;

			public Vector3 angle_vector_for_wall = Vector3.up;
			public float min_angle_for_wall = 70f;
			public float max_angle_for_wall = 110;
			#endregion

			#region propiedades publicas
			public virtual bool is_grounded
			{
				get {
					return manager_collisions[ "is_grounded" ];
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
					return manager_collisions[ "is_walled" ];
				}
			}

			public virtual bool is_not_walled
			{
				get {
					return !is_walled;
				}
			}
			#endregion

			#region funciones de movimiento
			public override void update_motion() {
				Vector3 velocity_vector = new Vector3(
					_rigidbody.velocity.x, _rigidbody.velocity.y,
					_rigidbody.velocity.z );
				_proccess_ground_velocity( ref velocity_vector );
				_proccess_gravity( ref velocity_vector );
				_proccess_jump( ref velocity_vector );

				debug.draw.arrow( direction_vector, Color.magenta );
				debug.draw.arrow( velocity_vector, Color.yellow );
				_rigidbody.velocity = velocity_vector;
			}

			protected override void _proccess_ground_velocity(
				ref Vector3 velocity_vector )
			{
				Vector3 desire_speed_vector;
				// si es true se esta moviendo a toda velocidad en diagonal
				if ( direction_vector.magnitude > 1 )
					desire_speed_vector = direction_vector.normalized * max_speed;
				else
					desire_speed_vector = direction_vector * max_speed;

				if ( is_running )
					desire_speed_vector *= runner_multiply;

				// suavizado de la velocidad horizontal
				float final_horizontal_velocity = Mathf.SmoothDamp(
					velocity_vector.z, desire_speed_vector.x,
					ref horizontal_velocity_smooth, acceleration_time_in_ground );

				velocity_vector.x = final_horizontal_velocity;
			}

			protected virtual void _proccess_jump( ref Vector3 velocity )
			{
				if ( try_to_jump_next_update )
				{
					if ( is_grounded )
					{
						velocity.y = max_jump_velocity;
					}
				}
			}

			/// <summary>
			/// agraga la velocidad de gravedad
			/// </summary>
			/// <param name="velocity"></param>
			protected virtual void _proccess_gravity( ref Vector3 velocity )
			{
				velocity.y += gravity * Time.deltaTime;
			}
			#endregion

			public override void jump()
			{
				try_to_jump_next_update = true;
			}

			public override void stop_jump()
			{
				try_to_jump_next_update = false;
			}

			#region manejo de coliciones
			protected virtual void _proccess_collsion( Collision collision )
			{
				if ( collision.gameObject.tag == helper.consts.tags.scenary )
				{
					_check_is_collision_is_a_floor( collision );
					_check_is_collision_is_a_wall( collision );
				}
			}

			protected virtual void _check_is_collision_is_a_floor(
				Collision collision )
			{
				__validate_normal_points( collision );
				foreach ( ContactPoint contact in collision.contacts )
				{
					float angle = Vector3.Angle(
						angle_vector_for_floor, contact.normal );
					if ( helper.math.between(
						angle, min_angle_for_floor, max_angle_for_floor ) )
					{
						manager_collisions.add( new manager.Collision_info(
							"is_grounded", collision ) );
						break;
					}
				}
			}

			protected virtual void _check_is_collision_is_a_wall(
				Collision collision )
			{
				__validate_normal_points( collision );
				foreach( ContactPoint contact in collision.contacts )
				{
					float angle = Vector2.Angle( angle_vector_for_wall, contact.normal );
					if ( helper.math.between(
							angle, min_angle_for_wall, max_angle_for_wall ) )
					{
						manager_collisions.add(
							new manager.Collision_info( "is_walled", collision ) );
					}
				}
			}

			protected virtual void OnCollisionEnter( Collision collision )
			{
				_proccess_collsion( collision );
			}

			protected virtual void OnCollisionExit( Collision collision )
			{
				manager_collisions.remove( collision.gameObject );
			}
			#endregion

			protected override void Start()
			{
				base.Start();
				gravity = - ( 2 * max_jump_heigh ) / ( jump_time * jump_time );
				max_jump_velocity = Math.Abs( gravity ) * jump_time;
				min_jump_velocity = ( float )Math.Sqrt(
					2.0 * Math.Abs( gravity ) * min_jump_heigh );
				_rigidbody.useGravity = false;
			}

			#region debug functions
			protected virtual void __validate_normal_points( Collision collision )
			{
				List<Vector3> normal_points = new List<Vector3>();
				foreach ( ContactPoint contact in collision.contacts )
				{
					normal_points.Add( contact.normal );
				}
				Vector3 first = normal_points[ 0 ];
				for ( int i = 1; i < normal_points.Count; ++i )
					if ( first != normal_points[ i ] )
					{
						string msg = string.Format(
							"se encontro una colision en la que los normal points " +
							"no son iguales con {0} y {1}, lista de nomral" +
							"points {2}", this, collision.gameObject, normal_points );
						Debug.LogWarning( msg );
					}
			}
			#endregion
		}
	}
}
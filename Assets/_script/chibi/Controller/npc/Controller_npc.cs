using UnityEngine;
using System.Collections.Generic;
using System;
using chibi.motor;
using chibi.motor.npc;

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

		protected manager.Collision manager_collisions;

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
		#endregion

		protected override void _init_cache()
		{
			manager_collisions = new manager.Collision();
			base._init_cache();
			hp = GetComponent<chibi.damage.motor.HP_engine>();
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

		#region manejo de coliciones
		protected virtual void _proccess_collision( Collision collision )
		{
			if ( chibi.tag.consts.is_scenary( collision ) )
			{
				__validate_normal_points( collision );
				_process_collision_scenary( collision );
			}
		}

		protected virtual void _process_collision_scenary( Collision collision )
		{
			_check_is_collision_is_a_floor( collision );
			_check_is_collision_is_a_wall( collision );
		}

		protected virtual void _check_is_collision_is_a_floor(
			Collision collision )
		{
			foreach ( ContactPoint contact in collision.contacts )
			{
				// si es piso
				float y = contact.normal.y;
				if ( y > 0.01f )
				{
					debug.draw.arrow(
						contact.point, contact.normal, Color.blue, 5f );
					var v = Vector3.up;
					debug.draw.arrow(
						contact.point, v, Color.magenta, 5f );

					var slope_angle = Vector3.Angle( contact.normal, v );
					/*
					debug.log(
						"slope angle: {0} with '{1}', normal: {2}",
						slope_angle, collision.gameObject.name, contact.normal );
					*/

					if ( slope_angle <= max_slope_angle )
					{
						manager_collisions.add( new manager.Collision_info(
							STR_FLOOR, collision, slope_angle ) );
						break;
					}
				}
				// si es pared
				else if ( y > -0.01 && y < 0.01 )
				{
					debug.draw.arrow(
						contact.point, contact.normal, Color.red, 5f );
				}
				// si es techo
				else if ( y < -0.01 )
				{
					debug.draw.arrow(
						contact.point, contact.normal, Color.yellow, 5f );
				}
				// no se que paso
				else
				{
					debug.error(
						"no esta manejando este caso en en el "
						+ "manager de las coliciones" );
					debug.draw.arrow(
						contact.point, contact.normal, Color.green, 5f );
					debug.pause();
				}
			}
		}

		protected virtual void _check_is_collision_is_a_wall(
			Collision collision )
		{
			foreach ( ContactPoint contact in collision.contacts )
			{
				float angle = Vector2.Angle(
					angle_vector_for_wall, contact.normal );
				if ( helper.math.between(
						angle, min_angle_for_wall, max_angle_for_wall )
						|| contact.normal == Vector3.forward
						|| contact.normal == Vector3.back )
				{
					manager_collisions.add(
						new manager.Collision_info( STR_WALL, collision ) );
				}
			}
		}

		protected virtual void OnCollisionEnter( Collision collision )
		{
			_proccess_collision( collision );
		}

		protected virtual void OnCollisionExit( Collision collision )
		{
			manager_collisions.remove( collision.gameObject );
		}
		#endregion

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

		protected override void load_motors()
		{
			base.load_motors();
			motor.manager_collisions = manager_collisions;
		}

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

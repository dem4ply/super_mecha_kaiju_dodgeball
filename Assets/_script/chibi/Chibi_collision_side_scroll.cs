using UnityEngine;
using System.Collections.Generic;
using System;
using chibi.motor;
using chibi.motor.npc;

namespace chibi.manager_v2.collision
{
	public class Chibi_collision_side_scroll : Chibi_collision_manager
	{
		public static string STR_WALL = "wall";
		public static string STR_WALL_left = "wall left";
		public static string STR_WALL_right = "wall right";
		public static string STR_FLOOR = "floor";
		public static string STR_CEIL = "ceil";

		public float max_slope_floor_angle;
		public float max_slope_ceil_angle;

		protected override void _process_collision_scenary( Collision collision )
		{
			foreach ( ContactPoint contact in collision.contacts )
			{
				// si es piso
				float y = contact.normal.y;
				if ( y > 0.01f )
				{
					if ( _proccess_floor( contact, collision ) )
						break;
				}
				// si es pared
				else if ( y > -0.01 && y < 0.01 )
				{
					if ( _proccess_wall( contact, collision ) )
						break;
				}
				// si es techo
				else if ( y < -0.01 )
				{
					if ( _proccess_ceil( contact, collision ) )
						break;
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

		protected virtual bool _proccess_floor(
			ContactPoint contact, Collision collision )
		{
			debug.draw.arrow(
				contact.point, contact.normal, Color.blue, 5f );
			debug.draw.arrow(
				contact.point, Vector3.up, Color.magenta, 5f );

			var slope_angle = Vector3.Angle( contact.normal, Vector3.up );
			if ( slope_angle <= max_slope_floor_angle )
			{
				manager_collisions.add( new manager.Collision_info(
					STR_FLOOR, collision, slope_angle ) );
				return true;
			}

			return false;
		}

		protected virtual bool _proccess_wall(
			ContactPoint contact, Collision collision )
		{
			debug.draw.arrow(
				contact.point, contact.normal, Color.red, 5f );
			debug.draw.arrow(
				contact.point, Vector3.up, Color.magenta, 5f );

			var slope_angle = Vector3.Angle( contact.normal, Vector3.up );

			manager_collisions.add( new manager.Collision_info(
				STR_WALL, collision, slope_angle ) );
			return true;
		}

		protected virtual bool _proccess_ceil(
			ContactPoint contact, Collision collision )
		{
			debug.draw.arrow(
				contact.point, contact.normal, Color.red, 5f );
			debug.draw.arrow(
				contact.point, Vector3.down, Color.magenta, 5f );

			var slope_angle = Vector3.Angle( contact.normal, Vector3.down );
			if ( slope_angle <= max_slope_ceil_angle )
			{
				manager_collisions.add( new manager.Collision_info(
					STR_CEIL, collision, slope_angle ) );
				return true;
			}
			return false;
		}
	}
}

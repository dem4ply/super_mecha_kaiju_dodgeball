using UnityEngine;
using route;

namespace behavior
{
	namespace two_d
	{
		public static class steering
		{
			/// <summary>
			/// genera un vector de direcion que intenta de seguir al target
			/// </summary>
			/// <param name="target">gameobject a seguir</param>
			/// <returns>direcion para seguir al target</returns>
			public static Vector3 seek( GameObject target, GameObject controller )
			{
				return seek( target.transform, controller.transform );
			}

			public static Vector3 seek( Transform target, Transform controller )
			{
				return seek( target.position, controller.position );
			}

			public static Vector3 seek( Vector3 target, Vector3 controller )
			{
				return target - controller;
			}

			/// <summary>
			/// genera el vector para huir del target
			/// </summary>
			/// <param name="target">gameobject del que se quiere huir</param>
			/// <returns>direcion para huir del target</returns>
			public static Vector3 flee( GameObject target, GameObject controller )
			{
				return flee( target.transform, controller.transform );
			}

			public static Vector3 flee( Transform target, Transform controller )
			{
				return flee( target.position, controller.position );
			}

			public static Vector3 flee( Vector3 target, Vector3 controller )
			{
				return controller - target;
			}

			/// <summary>
			/// persige al objecto predicion hacia donde estara
			/// </summary>
			/// <param name="target"></param>
			/// <param name="controller"></param>
			/// <param name="max_speed"></param>
			/// <returns></returns>
			public static Vector3 pursuit(
				GameObject target, GameObject controller, float max_speed )
			{
				Rigidbody2D rid_2d = target.GetComponent<Rigidbody2D>();
				if ( rid_2d != null )
					return pursuit(
						target.transform.position, rid_2d.velocity,
						controller.transform.position, max_speed );
				return seek( target, controller );
			}

			public static Vector3 pursuit(
				Vector3 target, Vector3 velocity, Vector3 current_position,
				float max_speed )
			{
				float distance_to_target = Vector3.Distance(
					target, current_position );
				float time_to_reach_target = distance_to_target / max_speed;
				Vector3 predicted_speed = velocity.normalized * time_to_reach_target;
				Vector3 predicted_position = target + predicted_speed;
				return seek( predicted_position, current_position );
			}

			/// <summary>
			/// huye al objecto predicion hacia donde estara
			/// </summary>
			/// <param name="target"></param>
			/// <param name="controller"></param>
			/// <param name="max_speed"></param>
			/// <returns></returns>
			public static Vector3 evade(
				GameObject target, GameObject controller, float max_speed )
			{
				Rigidbody2D rid_2d = target.GetComponent<Rigidbody2D>();
				if ( rid_2d != null )
					return evade(
						target.transform.position, rid_2d.velocity,
						controller.transform.position, max_speed );
				return flee( target, controller );
			}

			public static Vector3 evade(
				Vector3 target, Vector3 velocity, Vector3 current_position,
				float max_speed )
			{
				float distance_to_target = Vector3.Distance( target, current_position );
				float time_to_reach_target = distance_to_target / max_speed;
				Vector3 predicted_speed = velocity.normalized * time_to_reach_target;
				Vector3 predicted_position = target - predicted_speed;
				return flee( predicted_position, current_position );
			}

			public static Segment get_segmen_to_use(
				Route route, Vector3 current_position )
			{
				Segment segment = route.find_nearest_segment( current_position );

				Vector3 direction_to_end = segment.direction_to_end(
					current_position );
				float distance_to_end = direction_to_end.magnitude;
				if ( distance_to_end < segment.radius )
					segment = route.give_the_next_segment( segment );
				return segment;
			}

			public static Vector3 follow_path(
				GameObject target, GameObject controller, Vector3 velocity )
			{
				Route route = target.GetComponent<Route>();
				if ( route == null )
				{
					Debug.LogWarning( "el objetivo no tiene Route" );
					return seek( target, controller );
				}
				return follow_path(
					route, controller.transform.position, velocity );
			}

			/// <summary>
			/// suigue una el camino generado por un objeto tipo Route
			/// </summary>
			/// <param name="route"></param>
			/// <returns>direcion para moverse hacia la ruta si regresa
			/// Vector3.zero no es nesesario cambiar el vector de direcion</returns>
			public static Vector3 follow_path(
				Route route, Vector3 current_position, Vector3 velocity_vector )
			{
				Segment segment = get_segmen_to_use( route, current_position );

				Vector3 prediction_position =
					current_position + velocity_vector.normalized;
				Vector3 projection_point = segment.project( prediction_position );

				float distance = Vector3.Distance(
					prediction_position, projection_point );

				if ( distance > segment.radius )
				{
					Vector3 direction_to_move = segment.end.position - projection_point;
					direction_to_move = direction_to_move.normalized * segment.radius;
					Vector3 position_to_move = direction_to_move + projection_point;
					return position_to_move;
				}
				return Vector3.zero;
			}

			public static Vector3 follow_waypoints(
				GameObject target, GameObject controller,
				ref int current_waypoint )
			{
				Route route = target.GetComponent<Route>();
				if ( route == null )
				{
					Debug.LogWarning( "el objetivo no tiene Route" );
					return seek( target, controller );
				}
				return follow_waypoints(
					route, controller.transform.position, ref current_waypoint );
			}

			public static Vector3 follow_waypoints(
				Route route, Vector3 current_position, ref int current_waypoint )
			{
				Transform waypoint;
				try
				{
					waypoint = route.points[ current_waypoint ];
				}
				catch ( System.ArgumentOutOfRangeException )
				{
					current_waypoint = 0;
					return follow_waypoints(
						route, current_position, ref current_waypoint );
				}

				float distance = Vector3.Distance(
					current_position, waypoint.position );
				if ( distance < route.width )
				{
					++current_waypoint;
					return follow_waypoints(
						route, current_position, ref current_waypoint );
				}
				return waypoint.position;
			}
		}
	}
}
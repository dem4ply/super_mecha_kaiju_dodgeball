using UnityEngine;
using route;

namespace behavior
{
	namespace tree_d
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
				return two_d.steering.seek( target, controller );
			}

			public static Vector3 seek( Vector3 target, Vector3 controller )
			{
				return two_d.steering.seek( target, controller );
			}

			/// <summary>
			/// genera el vector para huir del target
			/// </summary>
			/// <param name="target">gameobject del que se quiere huir</param>
			/// <returns>direcion para huir del target</returns>
			public static Vector3 flee( GameObject target, GameObject controller )
			{
				return two_d.steering.flee( target, controller );
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
				Rigidbody rid = target.GetComponent<Rigidbody>();
				if ( rid != null )
					return two_d.steering.pursuit(
						target.transform.position, rid.velocity,
						controller.transform.position, max_speed );
				return seek( target, controller );
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
				Rigidbody rid = target.GetComponent<Rigidbody>();
				if ( rid != null )
					return two_d.steering.evade(
						target.transform.position, rid.velocity,
						controller.transform.position, max_speed );
				return flee( target, controller );
			}

			public static Vector3 follow_path(
				GameObject target, GameObject controller, Vector3 velocity )
			{
				return two_d.steering.follow_path(
					target, controller, velocity );
			}

			public static Vector3 follow_waypoints(
				GameObject target, GameObject controller,
				ref int current_waypoint )
			{
				return two_d.steering.follow_waypoints(
					target, controller, ref current_waypoint );
			}
		}
	}
}
using UnityEngine;
using System.Collections;
using route;

namespace controller
{
	namespace ai
	{
		public class Ai_steering_behavior : chibi_base.Chibi_behaviour
		{
			public GameObject target;
			public controllers.Controller_base controller;

			protected int last_waypoint = 0;

			public Vector3 current_position
			{
				get { return controller.transform.position; }
			}

			/// <summary>
			/// genera un vector de direcion que intenta de seguir al target
			/// </summary>
			/// <param name="target">gameobject a seguir</param>
			/// <returns>direcion para seguir al target</returns>
			public Vector3 seek( GameObject target )
			{
				return seek( target.transform.position );
			}

			/// <summary>
			/// genera un vector de direcion que intenta de seguir al target
			/// </summary>
			/// <param name="target">vector3 a seguir</param>
			/// <returns>direcion para seguir al target</returns>
			public Vector3 seek( Vector3 target )
			{
				return behavior.two_d.steering.seek( target, current_position );
			}

			/// <summary>
			/// genera el vector para huir del target
			/// </summary>
			/// <param name="target">gameobject del que se quiere huir</param>
			/// <returns>direcion para huir del target</returns>
			public Vector3 flee( GameObject target )
			{
				return flee( target.transform.position );
			}

			/// <summary>
			/// genera el vector para huir del target
			/// </summary>
			/// <param name="target">posicion del que se quiere huir</param>
			/// <returns>direcion para huir del target</returns>
			public Vector3 flee( Vector3 target )
			{
				return behavior.two_d.steering.flee( target, current_position );
			}

			public Vector3 pursuit( GameObject target )
			{
				Rigidbody2D rid_2d = target.GetComponent<Rigidbody2D>();
				if ( rid_2d != null )
					return behavior.two_d.steering.pursuit(
						target, controller.gameObject, controller.max_speed );

				Rigidbody rid = target.GetComponent<Rigidbody>();
				if ( rid != null )
					return behavior.tree_d.steering.pursuit(
						target, controller.gameObject, controller.max_speed );
				return seek( target );
			}

			public Vector3 evade( GameObject target )
			{
				Rigidbody2D rid_2d = target.GetComponent<Rigidbody2D>();
				if ( rid_2d != null )
					return behavior.two_d.steering.evade(
						target, controller.gameObject, controller.max_speed );

				Rigidbody rid = target.GetComponent<Rigidbody>();
				if ( rid != null )
					return behavior.tree_d.steering.evade(
						target, controller.gameObject, controller.max_speed );
				return flee( target );
			}

			protected Segment get_segmen_to_use( Route route )
			{
				Segment segment = route.find_nearest_segment( current_position );

				Vector3 direction_to_end = segment.direction_to_end( current_position );
				float distance_to_end = direction_to_end.magnitude;
				if ( distance_to_end < segment.radius )
					segment = route.give_the_next_segment( segment );
				return segment;
			}

			public Vector3 follow_path( GameObject target )
			{
				return behavior.two_d.steering.follow_path(
					target, controller.gameObject, controller.velocity_vector );
			}

			public Vector3 follow_waypoints( GameObject target )
			{
				return behavior.two_d.steering.follow_waypoints(
					target, controller.gameObject, ref last_waypoint );
			}

			/// <summary>
			/// asigna la direcion del control como seek
			/// </summary>
			/// <param name="target">objetivo al que se quiiere seguir</param>
			public void do_seek( GameObject target )
			{
				if ( target == null )
					do_stop();
				else
				{
					Vector3 desire_direction = seek( target );
					debug.draw.arrow( desire_direction, Color.magenta );
					controller.desire_direction = desire_direction;
				}
			}

			public void do_seek( Vector3 target )
			{
				Vector3 desire_direction = seek( target );
				debug.draw.arrow( desire_direction, Color.magenta );
				controller.desire_direction = desire_direction;
			}

			/// <summary>
			/// asigna la direcion del control como flee
			/// </summary>
			/// <param name="target">objetivo del que se quiere huir</param>
			public void do_flee( GameObject target )
			{
				if ( target == null )
					do_stop();
				else
				{
					Vector3 desire_direction = flee( target );
					debug.draw.arrow( desire_direction, Color.magenta );
					controller.desire_direction = desire_direction;
				}
			}
			
			public void do_pursuit( GameObject target )
			{
				if ( target == null )
					do_stop();
				else
				{
					Vector3 desire_direction = pursuit( target );
					debug.draw.arrow( desire_direction, Color.magenta );
					controller.desire_direction = desire_direction;
				}
			}

			public void do_evade( GameObject target )
			{
				if ( target == null )
					do_stop();
				else
				{
					Vector3 desire_direction = evade( target );
					debug.draw.arrow( desire_direction, Color.magenta );
					controller.desire_direction = desire_direction;
				}
			}

			public void do_follow_path( GameObject target )
			{
				if ( target == null )
					do_stop();
				else
				{
					Vector3 desire_position = follow_path( target );
					if ( desire_position != Vector3.zero )
						do_seek( desire_position );
				}
			}

			public void do_follow_waypoints( GameObject target )
			{
				if ( target == null )
					do_stop();
				else
				{
					Vector3 desire_position = follow_waypoints( target );
					do_seek( desire_position );
				}
			}

			public void do_stop()
			{
				controller.desire_direction = Vector3.zero;
			}
		}
	}
}


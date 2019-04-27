using UnityEngine;
using System.Collections;

namespace route
{
	public class Segment 
	{
		public Transform start, end;
		public float radius;
		public int index;

		public Vector3 direction
		{
			get { return end.position - start.position; }
		}

		public float magnitude
		{
			get { return direction.magnitude; }
		}

		public Segment( Transform start, Transform end, float radius, int index )
		{
			this.start = start;
			this.end = end;
			this.radius = radius;
			this.index = index;
		}

		public Vector3 project( Vector3 vector )
		{
			Vector3 line = direction;
			float lenght = line.magnitude;
			line.Normalize();

			Vector3 direction_of_vector = vector - start.position;
			float d = Vector3.Dot( direction_of_vector, line );
			d = Mathf.Clamp( d, 0f, lenght );

			line = start.position + ( line * d );

			return line;
		}

		public float distance_of( Vector3 vector )
		{
			Vector3 line = project( vector );
			float distance = Vector3.Distance( vector, line );
			return distance;
		}

		public Vector3 direction_to_start( Vector3 position )
		{
			return start.position - position;
		}

		public Vector3 direction_to_end( Vector3 position )
		{
			return end.position - position;
		}

		public void draw_gizmo()
		{
			Vector3 d2 = Quaternion.Euler( 0, 0, 90 ) * direction;
			Vector3 d3 = Quaternion.Euler( 0, 0, -90 ) * direction;
			d2 = start.position + ( d2.normalized * radius );
			d3 = start.position + ( d3.normalized * radius );

			helper.draw.arrow.gizmo( start.position, direction, Color.green );
			helper.draw.arrow.gizmo( d2, direction, Color.red );
			helper.draw.arrow.gizmo( d3, direction, Color.red );

			d2 = Quaternion.Euler( 0, 90, 0 ) * direction;
			d3 = Quaternion.Euler( 0, -90, 0 ) * direction;
			d2 = start.position + ( d2.normalized * radius );
			d3 = start.position + ( d3.normalized * radius );

			helper.draw.arrow.gizmo( d2, direction, Color.blue );
			helper.draw.arrow.gizmo( d3, direction, Color.blue );
		}
	}
}

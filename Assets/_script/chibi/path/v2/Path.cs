using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace chibi.path
{
	[System.Serializable]
	public class Path
	{
		public List<Segment> segments;
		public Transform container;

		public Path( Transform center )
		{
			container = center;
			segments = new List<Segment> { new Segment( center, container ) };
		}

		public void add_segment_relative( Vector3 direction )
		{
			var segment = segments.Last();
			var new_segment = new Segment(
				segment, segment.p2.position + direction );
			segments.Add( new_segment );
		}

		public IEnumerable<Transform> plain_points()
		{
			foreach ( Segment segment in segments )
			{
				yield return segment.p1;
				yield return segment.c1;
				yield return segment.c2;
			}
			yield return segments.Last().p2;
		}
	}
}

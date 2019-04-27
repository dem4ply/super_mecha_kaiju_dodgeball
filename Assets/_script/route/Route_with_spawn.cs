using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace route
{
	public class Route_with_spawn : Route
	{
		public spawner.Spawn_point proto_spawn_point;
		public override IEnumerable<GameObject> get_points()
		{
			var point = _instantiate_point( proto_spawn_point.gameObject, 0 );
			var spawn = point.GetComponent<spawner.Spawn_to_route>();
			if ( spawn != null )
				spawn.target = this;
			yield return point;
			for ( int i = 1; i < nodes; ++i )
			{
				point = _instantiate_point( proto_point, i );
				yield return point;
			}
		}
	}
}
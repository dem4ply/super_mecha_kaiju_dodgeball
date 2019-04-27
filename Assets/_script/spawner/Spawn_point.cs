using UnityEngine;
using System.Collections.Generic;

namespace spawner
{
	public class Spawn_point: chibi_base.Chibi_behaviour
	{
		public List<GameObject> objects;
		public bool is_continuos = false;
		public float rate_spawn = 1f;
		public int current = 0;

		public virtual GameObject spawn()
		{
			var result = _instance( objects[ current++ ] );
			if ( current >= objects.Count )
				current = 0;
			return result;
		}

		protected virtual GameObject _instance( GameObject obj )
		{
			return helper.instantiate._( obj, transform.position );
		}
	}
}
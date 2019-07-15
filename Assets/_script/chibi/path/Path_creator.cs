using System.Collections.Generic;
using UnityEngine;

namespace chibi.path.v1
{
	public class Path_creator : chibi.Chibi_behaviour
	{
		public Path path;

		public void create_path()
		{
			path = new Path( transform );
		}
	}
}

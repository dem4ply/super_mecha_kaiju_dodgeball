using System.Collections.Generic;
using UnityEngine;

namespace chibi.path
{
	public class Path_behaviour : chibi.Chibi_behaviour
	{
		public Path path;

		public void create_path()
		{
			if ( path != null )
				path = new Path( transform, path );
			else
				path = new Path( transform );
		}

		private void OnDrawGizmos()
		{
			foreach ( var segment in path.segments )
			{
				segment.draw_gizmo();
			}
		}
	}
}

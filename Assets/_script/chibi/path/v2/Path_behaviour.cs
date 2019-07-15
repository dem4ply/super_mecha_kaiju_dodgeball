﻿using System.Collections.Generic;
using UnityEngine;

namespace chibi.path.v2
{
	public class Path_behaviour : chibi.Chibi_behaviour
	{
		public Path path;

		public void create_path()
		{
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

using UnityEngine;
using System;
using System.Collections.Generic;

namespace radar
{
	public class Radar_hit
	{
		public Transform transform;
		public float distance;

		public Radar_hit( Transform obj, float distance )
		{
			this.transform = obj;
			this.distance = distance;
		}

		public Radar_hit( RaycastHit2D hit )
		{
			this.transform = hit.transform;
			this.distance = hit.distance;
		}
	}
}

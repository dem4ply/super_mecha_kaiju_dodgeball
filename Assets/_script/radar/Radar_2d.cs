using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace radar
{
	public class Radar_2d : Radar
	{
		public Radar_2d(
			Transform origin, Vector3 size, Vector3 direction, float distance,
			float angle, List<LayerMask> masks )
			: base( origin, size, direction, distance, angle, masks )
		{
		}
	}
}

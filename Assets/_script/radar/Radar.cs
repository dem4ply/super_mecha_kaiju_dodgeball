using UnityEngine;
using System;
using System.Collections.Generic;

namespace radar
{
	public class Radar
	{
		public Vector3 size;
		public Vector3 direction;
		public float distance;
		public float angle;

		public List< LayerMask > masks;

		public Transform origin;

		public Dictionary< LayerMask, List< Radar_hit > > masks_hits;
		public List< Radar_hit > hits;

		public Radar(
			Transform origin, Vector3 size, Vector3 direction, float distance,
			float angle, List<LayerMask> masks )
		{
			this.origin = origin;
			this.size = size;
			this.direction = direction;
			this.distance = distance;
			this.angle = angle;
			this.masks = masks;

			masks_hits = new Dictionary<LayerMask, List<Radar_hit>>();
			hits = new List< Radar_hit >();
		}

		public virtual void ping()
		{
			throw new NotImplementedException();
		}
	}
}

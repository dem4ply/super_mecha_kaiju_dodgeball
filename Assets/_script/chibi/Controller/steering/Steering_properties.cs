using UnityEngine;
using System.Collections.Generic;
using controller;
using chibi.controller.actuator;
using Unity.Entities;
using System;
using System.Linq;

namespace chibi.controller.steering
{
	public class Steering_properties
	{
		public float time = 0f;
		public Vector3 last_target;
		public Vector3 last_direction;

		public chibi.radar.Radar radar;
	}
}

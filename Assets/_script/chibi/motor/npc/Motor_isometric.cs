using UnityEngine;
using System.Collections;
using controller;
using controller.animator;
using Unity.Entities;
using System;

namespace chibi.motor.npc
{
	public class Motor_isometric : Motor
	{
		public override Vector3 desire_direction
		{
			set {
				base.desire_direction = new Vector3( value.x, 0, value.z );
			}
		}
	}
}
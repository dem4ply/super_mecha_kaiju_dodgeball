using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace chibi.actuator
{
	public class Teleporter : Actuator
	{
		public Transform destiny;

		public override void action( controller.Controller controller )
		{
			controller.transform.position = destiny.position;
		}
	}
}
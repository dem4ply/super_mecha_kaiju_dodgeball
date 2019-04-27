using UnityEngine;
using System.Collections;

namespace spawner
{
	public class Spawn_to_route : Spawn_point
	{
		public route.Route target;

		public override GameObject spawn()
		{
			var result = base.spawn();
			var ai = result.GetComponent<
				controller.controllers.ai.tree_d.AI_controller_3d>();
			if ( target != null && ai != null )
				ai.target = target.transform;
			return result;
		}
	}
}

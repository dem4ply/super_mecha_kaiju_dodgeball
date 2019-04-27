using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;

namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				public class AI_walk_3d : AI_base_3d
				{
					public Vector3 desire_direction = Vector3.zero;

					protected override void Update()
					{
						if ( desire_direction != Vector3.zero )
							controller.direction_vector = desire_direction;
					}

					protected virtual void OnDrawGizmos()
					{
						if ( desire_direction != Vector3.zero )
							helper.draw.arrow.gizmo(
								transform.position, desire_direction, Color.magenta );
					}
				}
			}
		}
	}
}

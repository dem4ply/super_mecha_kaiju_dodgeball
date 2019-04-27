using UnityEngine;
using behavior.tree_d;

namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				namespace behavior
				{
					[CreateAssetMenu( menuName="controller/3d/ai/behavior/follow_route" )]
					public class Follow_route : Behavior
					{
						public override Vector3 act( AI_controller_3d controller )
						{
							var desire_direction = steering.follow_waypoints(
								controller.target.gameObject,
								controller.gameObject,
								ref controller.properties.index );
							controller.controller.desire_direction =
								steering.seek(
									desire_direction, 
									controller.controller.transform.position );
							return desire_direction;
						}
					}
				}
			}
		}
	}
}

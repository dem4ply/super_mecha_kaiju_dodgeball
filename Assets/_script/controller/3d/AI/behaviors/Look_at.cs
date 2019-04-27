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
					[CreateAssetMenu(
						menuName = "controller/3d/ai/behavior/look_at" )]
					public class Look_at : Behavior
					{
						public override Vector3 act( AI_controller_3d controller )
						{
							if ( controller.target != null )
								controller.controller.look_at(
									controller.target.transform );
							return Vector3.zero;
						}
					}
				}
			}
		}
	}
}

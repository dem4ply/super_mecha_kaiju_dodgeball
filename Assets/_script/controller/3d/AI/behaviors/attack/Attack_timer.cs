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
						menuName = "controller/3d/ai/behavior/attack/timer" )]
					public class Attack_timer : Behavior
					{
						public float period = 1f;

						public float delta_period
						{
							get {
								return 1 / period;
							}
						}

						public override Vector3 act( AI_controller_3d controller )
						{
							var properties = controller.properties;
							properties.sum_delta_period += Time.deltaTime;
							if ( properties.sum_delta_period > delta_period )
							{
								foreach ( var weapon in controller.weapons )
								{
									weapon.attack();
								}
								properties.sum_delta_period -= delta_period;
							}
							return Vector3.zero;
						}
					}
				}
			}
		}
	}
}

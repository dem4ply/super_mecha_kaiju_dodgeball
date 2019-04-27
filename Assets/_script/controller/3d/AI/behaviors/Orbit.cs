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
					[CreateAssetMenu( menuName="controller/3d/ai/behavior/orbit" )]
					public class Orbit : Behavior
					{
						public override Vector3 act( AI_controller_3d controller )
						{
							stats.Orbit stat = controller.stat as stats.Orbit;
							if ( stat == null )
							{
								Debug.LogError( string.Format(
									"Los stat de {0} no son del tipo orbit",
									controller.name ) );
								return Vector3.zero;
							}
							Vector3 target_position =
								controller.target.transform.position;
							float angle = controller.properties.angle_x;
							angle += ( Time.deltaTime * stat.orbit_delta ) % 1f;
							controller.properties.angle_x = angle;

							Vector3 desire = helper.shapes.Ellipse.evaluate(
								stat.x_radius, stat.z_radius, angle );

							Vector3 result = new Vector3(
								desire.x + target_position.x,
								target_position.y, desire.z + target_position.z );

							result = desire + target_position;

							controller.controller.desire_direction =
								steering.seek(
									result, controller.controller.transform.position );
							return result;
						}

						public override void prepare( AI_controller_3d controller )
						{
							Vector3 current_position =
								controller.controller.transform.position;
							Vector3 direction =
								current_position
								- controller.target.transform.position;
							controller.properties.angle_x = helper.shapes.Ellipse
								.get_progrest( direction );

						}
					}
				}
			}
		}
	}
}

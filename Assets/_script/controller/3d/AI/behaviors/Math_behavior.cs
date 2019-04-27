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
						menuName = "controller/ai/behavior/math_behavior" )]
					public class Math_behavior : Behavior
					{
						public math_pattern.Math_pattern x_behavior;
						public math_pattern.Math_pattern y_behavior;
						public math_pattern.Math_pattern z_behavior;

						public Vector3 direction_move = Vector3.zero;

						public override Vector3 act( AI_controller_3d controller )
						{
							float x = 0, y = 0, z = 0;
							if ( x_behavior != null )
								x = x_behavior.calculate( controller, "x" );
							if ( y_behavior != null )
								y = y_behavior.calculate( controller, "y" );
							if ( z_behavior != null )
								z = z_behavior.calculate( controller, "z" );

							Vector3 result = new Vector3( x, y, z ) + direction_move;

							controller.controller.desire_direction = result;

							/*
							float angle = controller.properties.angle_x;
							angle += ( Time.time* (1/2f)) % 1f;
							controller.properties.angle_x = angle;

							angle = Mathf.Deg2Rad * 360 * angle;

							result = new Vector3(
								Mathf.Sin( angle ) * 1f, 0f, -1f );
							//result = Vector3.back + result;

							controller.controller.desire_direction = result;
							*/
							return result;
						}
					}
				}
			}
		}
	}
}

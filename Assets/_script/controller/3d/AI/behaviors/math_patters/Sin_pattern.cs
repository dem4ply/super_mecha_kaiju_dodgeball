using UnityEngine;


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
					namespace math_pattern
					{
						[CreateAssetMenu(
							menuName = "controller/ai/behavior/math/sin" )]
						public class Sin_pattern : Math_pattern
						{
							public float radius = 1f;
							public float period = 1f;

							protected float _orbit_delta;

							public float delta_period
							{
								get {
									return 1f / period;
								}
							}

							public override float calculate(
								AI_controller_3d controller, string angle_letter )
							{
								float angle = get_angle( controller, angle_letter );
								angle += Time.deltaTime * delta_period % 1f;
								set_angle( controller, angle_letter, angle );
								angle = Mathf.Deg2Rad * 360 * angle;
								return Mathf.Sin( angle ) * radius;
							}
						}
					}
				}
			}
		}
	}
}

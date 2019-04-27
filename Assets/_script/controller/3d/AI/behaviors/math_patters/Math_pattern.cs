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
						public abstract class Math_pattern : chibi_base.Chibi_object
						{
							public abstract float calculate(
								AI_controller_3d controller, string angle );

							public float get_angle(
								AI_controller_3d controller, string letter )
							{
								switch ( letter )
								{
									case "x":
										return controller.properties.angle_x;
									case "z":
										return controller.properties.angle_z;
								}
								return 0f;
							}

							public void set_angle(
								AI_controller_3d controller, string letter,
								float angle )
							{
								switch ( letter )
								{
									case "x":
										controller.properties.angle_x = angle;
										break;
									case "z":
										controller.properties.angle_z = angle;
										break;
								}
							}
						}
					}
				}
			}
		}
	}
}

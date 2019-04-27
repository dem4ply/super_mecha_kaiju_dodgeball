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
					[CreateAssetMenu( menuName = "controller/ai/behavior/base" )]
					public abstract class Behavior : chibi_base.Chibi_object
					{
						public abstract Vector3 act( AI_controller_3d controller );

						public virtual void prepare( AI_controller_3d controller )
						{
						}
					}
				}
			}
		}
	}
}

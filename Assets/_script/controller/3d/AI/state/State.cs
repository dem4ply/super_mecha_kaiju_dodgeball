using UnityEngine;
using System.Collections.Generic;


namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				namespace state
				{
					[CreateAssetMenu( menuName = "controller/3d/ai/state/base" )]
					public class State : chibi_base.Chibi_object
					{
						public List<behavior.Behavior> behaviors;

						public void update( AI_controller_3d controller )
						{
							do_actions( controller );
						}

						public void prepare( AI_controller_3d controller )
						{
							foreach ( behavior.Behavior behavior in behaviors )
								behavior.prepare( controller );
						}

						public virtual void do_actions( AI_controller_3d controller )
						{
							foreach ( behavior.Behavior behavior in behaviors )
								behavior.act( controller );
						}
					}
				}
			}
		}
	}
}

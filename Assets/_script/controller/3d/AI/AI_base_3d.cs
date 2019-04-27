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
				public abstract class AI_base_3d : chibi_base.Chibi_behaviour 
				{
					public Controller_3d controller;

					protected abstract void Update();

					protected override void _init_cache()
					{
						base._init_cache();
						if ( controller == null )
							controller = GetComponent<Controller_3d>();

						if ( controller == null )
						{
							Debug.LogError( string.Format(
								"no se puudo encontrar un controll en el gameoject" +
								"{0}", name ) );
						}
					}

				}
			}
		}
	}
}

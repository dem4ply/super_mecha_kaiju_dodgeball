using UnityEngine;
using System.Collections.Generic;
using controller.animator;
using controller.motor;
using System;
using damage;

namespace controller
{
	namespace controllers
	{
		public class Bullet_controller_3d : Controller_3d
		{
			public Damage[] damages
			{
				get
				{
					var damage = GetComponent<Damage>();
					var damages = GetComponentsInChildren<Damage>();
					var result = new List<Damage>( damages );
					if ( damage != null )
						result.Add( damage );
					return result.ToArray();
				}
			}
			public void shot( Vector3 direction_shot )
			{
				desire_direction = direction_shot;
			}
		}

	}
}

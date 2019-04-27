using UnityEngine;
using System.Collections.Generic;

namespace spawner
{
	namespace invoker
	{
		public class Invoker : chibi_base.Chibi_behaviour
		{
			public Spawn_point target;

			protected override void _init_cache()
			{
				base._init_cache();
				if ( target == null )
					target = GetComponent<Spawn_point>();
				if ( target == null )
					Debug.LogWarning( string.Format(
						"the gameobject {0} no tiene taget se esperaba" +
						" un Spwan_point", name ) );
			}
		}
	}
}
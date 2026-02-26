using UnityEngine;

namespace chibi.spawner.invoker
{
	public class Invoker : chibi.Chibi_behaviour
	{
		public Spawner target;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !target )
				target = GetComponent<Spawner>();
			if ( !target )
				debug.warning(
					"no tiene taget se esperaba un Spwan_point" );
		}
	}
}
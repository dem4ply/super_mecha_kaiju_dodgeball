using UnityEngine;

namespace chibi.spawner
{
	public class Spawner_pool : Spawner
	{
		public chibi.pool.Pool_behaviour pool_spawner;

		public override GameObject spawn()
		{
			var obj = pool_spawner.pop();
			obj.transform.position = transform.position;
			obj.SetActive( true );
			return obj;
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !pool_spawner )
				debug.error( "no esta asignado el pool_spawner" );
		}
	}
}

using UnityEngine;


namespace chibi.UI.chicken_o_meter
{
	public class Chicken_o_meter : Chibi_behaviour
	{
		Gauge gauge;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !gauge )
				Debug.LogError( string.Format(
					"[Chicken_o_meter] no se encontro un gauge en '{0}'",
					helper.game_object.name.full( this ), this ) );
		}
	}
}

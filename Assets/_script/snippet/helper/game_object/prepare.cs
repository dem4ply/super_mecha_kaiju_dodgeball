using UnityEngine;
using System.Linq;

namespace helper
{
	namespace game_object
	{
		public class prepare
		{
			public static GameObject stuff()
			{
				var _stuff = GameObject.Find( consts.game_object_names.stuff );
				if ( _stuff == null )
					_stuff = new GameObject( consts.game_object_names.stuff );
				return _stuff;
			}

			public static GameObject stuff_container( string name )
			{
				var _stuff = stuff();
				var container = _stuff.transform.Find( name );
				if ( !container )
				{
					var game_object = new GameObject( name );
					container = game_object.transform;
					container.parent = _stuff.transform;
				}
				return container.gameObject;
			}
		}
	}
}
using UnityEngine;

namespace helper
{
	namespace game_object
	{
		public class clean
		{
			public static void scene()
			{
				var objs = GameObject.FindObjectsOfType<GameObject>();
				foreach ( var obj in objs )
				{
					if ( obj.name != "New Game Object" )
						GameObject.Destroy( obj );
				}
			}
		}
	}
}
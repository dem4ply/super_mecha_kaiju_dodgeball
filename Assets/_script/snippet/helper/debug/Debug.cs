using UnityEngine;
using System.Collections;
using chibi_base;

namespace helper
{
	namespace debug
	{
		public class Debug
		{
			protected MonoBehaviour _instance;
			public draw.Draw draw;

			public bool debuging
			{
					get {
						var a = _instance as chibi.Chibi_behaviour;
						if ( a )
							return a.debug_mode;
						var b = _instance as chibi_base.Chibi_behaviour;
						if ( b )
							return b.debug_mode;
						return false;
					}
			}

			public Debug( chibi_base.Chibi_behaviour instance )
			{
				_instance = instance;
				draw = new draw.Draw( _instance );
			}

			public Debug( chibi.Chibi_behaviour instance )
			{
				_instance = instance;
				draw = new draw.Draw( _instance );
			}
		}
	}
}

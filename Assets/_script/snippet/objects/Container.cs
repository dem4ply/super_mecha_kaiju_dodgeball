using UnityEngine;
using chibi_base;

namespace snippet {
	namespace objects {
		public class Container : Chibi_behaviour, interfaces.Container {
			public GameObject scene_container {
				get {
					return gameObject;
				}
			}

			public void clean() {
				helper.instantiate.destroy_immediate_childrens( scene_container );
			}

			public T instanciate<T>( T original, bool is_active )
				where T : MonoBehaviour {
				if ( is_active )
					return helper.instantiate.parent<T>(
						original, scene_container );
				else
					return helper.instantiate.inactive.parent<T>(
						original, scene_container );
			}
		}
	}
}
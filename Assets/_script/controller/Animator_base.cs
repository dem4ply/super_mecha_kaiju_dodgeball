using UnityEngine;
using System.Collections;
using chibi_base;

namespace controller {
	namespace animator {
		public class Animator_base : Chibi_behaviour {
			#region Var public
			public Animator animator;
			#endregion

			#region funciones protegidas
			protected override void _init_cache() {
				if ( animator == null )
					animator = GetComponent<Animator>();
			}
			#endregion
		}
	}
}

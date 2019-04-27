using UnityEngine;
using System.Collections;

namespace chibi_base {
	public class Chibi_behaviour : MonoBehaviour {

		protected bool _is_drawing_gizmo;

		protected bool _is_instanciate;

		public bool debug_mode = false;
		protected helper.debug.Debug debug;

		protected virtual void Awake()
		{
			debug = new helper.debug.Debug( this );
			_init_cache();
		}

		protected virtual void Start() {
			debug = new helper.debug.Debug( this );
		}

		protected virtual void _init_cache() {}

		public void gizmo_awake() {
			_is_drawing_gizmo = true;
			Start();
			_is_drawing_gizmo = false;
		}

		public void extert_init_cache() {
			_init_cache();
		}
	}
}

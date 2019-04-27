using UnityEngine;
using snippet.objects;

namespace geometry {
	namespace cell {

		public class Cell: chibi_base.Chibi_behaviour {
			protected float _height = 1f, _width = 1f;

			protected BoxCollider2D _collider;

			/// <summary>
			/// propiedad para usarla de atajo para objeter el collider
			/// </summary>
			protected new BoxCollider2D collider {
				get {
					return _collider;
				}
				set {
					_collider = value;
					_width = value.size.x;
					_height = value.size.y;
				}
			}

			/// <summary>
			/// tool para obtener la posicion relativa del objeto
			/// </summary>
			public Position position {
				get; set;
			}

			/// <summary>
			/// altura de la celda
			/// </summary>
			public float height {
				get {
					return _height;
				}
				set {
					_height = value;
				}
			}

			/// <summary>
			/// anchura de la celda
			/// </summary>
			public float width {
				get {
					return _width;
				}
				set {
					_width = value;
				}
			}

			protected override void _init_cache() {
				base._init_cache();
				collider = GetComponent<BoxCollider2D>();
				_build_position();
			}

			/// <summary>
			/// contrulle la posicion para ser usado en la propiedad
			/// </summary>
			protected void _build_position() {
				position = new Position( transform, collider.bounds );
			}
		}

	}
}
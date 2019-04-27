using UnityEngine;
using System.Collections.Generic;
using chibi_base;
using snippet.objects;
using grid.cell;
using System;

using grid.cell.interfaces;

namespace grid {
	namespace cell {
		[ExecuteInEditMode]
		public class Cell : Chibi_behaviour, i_cell {
			public GameObject relative_position;

			public Position position;

			protected BoxCollider2D _collider;

			public Bounds bounds {
				get; set;
			}

			public virtual float width {
				get {
					return bounds.size.x;
				}
				set {
					bounds = _generate_bounds( value, height );
					_generate_position();
				}
			}

			public virtual float height {
				get {
					return bounds.size.y;
				}
				set {
					bounds = _generate_bounds( width, value );
					_generate_position();
				}
			}

			protected virtual void _update_collider() {
				print( "sdfasdfasdfasdf" );
				_collider.size = bounds.size;
				_generate_position();
			}

			public virtual void  resize() {
				_update_collider();
			}

			protected override void _init_cache() {
				base._init_cache();
				_collider = GetComponent<BoxCollider2D>();
				_collider.size = bounds.size;
				_generate_position();
			}

			protected virtual Bounds _generate_bounds( float width, float height ) {
				return new Bounds( Vector3.zero, new Vector3( width, height ) );
			}

			protected virtual void _generate_position() {
				position = new Position( transform, bounds );
			}
		}
	}
}
using UnityEngine;
using System.Collections.Generic;
using chibi_base;
using grid.cell;
using System;
using snippet.objects;
using grid.cell.interfaces;

namespace grid {
	public class Grid : Cell, grid.interfaces.i_grid {

		public Cell prototype_cell;

		protected Bounds _bounds_cell;

		protected int number_columns = 0;
		protected int number_rows = 0;

		protected int _columns = 1;
		protected int _rows = 1;

		protected List<List<Cell>> _cells;

		protected Container _cells_containers;

		public int columns {
			get {
				return _columns;
			}
			set {
				_columns = value;
				width = prototype_cell.width * value;
			}
		}

		public int rows {
			get {
				return _rows;
			}
			set {
				_rows = value;
				height = prototype_cell.height * value;
			}
		}

		public i_cell cell {
			get {
				return prototype_cell;
			}
		}

		public Container cell_container {
			get {
				return _cells_containers;
			}
			set {
				_cells_containers = value;
			}
		}

		public i_cell this[int row, int column] {
			get {
				throw new NotImplementedException();
			}
		}

		protected override void _init_cache() {
			base._init_cache();
			_collider = GetComponent<BoxCollider2D>();

			_init_cache_cell();
		}

		protected override void _update_collider() {
			base._update_collider();
			_collider.offset = new Vector2( width * 0.5f, -height * 0.5f );
		}

		protected virtual void _init_cache_cell() {
		}

		protected virtual void _create_cells() {
			cell_container.clean();
			_cells = new List<List<Cell>>();
			for ( int i = 0; i < rows; ++i ) {
				_cells.Add( new List<Cell>( columns ) );
				for ( int j = 0; j < columns; ++j ) {
					Cell new_cell = _instanciate_cell( i, j );
					_cells[i].Add( new_cell );
				}
			}

		}

		protected virtual Cell _instanciate_cell( int column, int row ) {
			Cell new_cell = helper.instantiate.inactive.parent<Cell>(
				prototype_cell, cell_container.transform, true );
			new_cell.name = string.Format( "cell {0}, {1}", column, row );
			new_cell.transform.localPosition = _get_vector_for_cell( column, row );
			return new_cell;
		}

		protected virtual Vector3 _get_vector_for_cell( int column, int row ) {
			float position_row = row * cell.width + cell.width * 0.5f;
			float position_column = -column * cell.height + -cell.height * 0.5f;
			return new Vector3( position_row, position_column );
		}

		protected override Bounds _generate_bounds( float width, float height ) {
			return new Bounds(
				new Vector2( width * 0.5f, -height * 0.5f ),
				new Vector3( width, height ) );
		}

		public override void resize() {
			base.resize();
			_create_cells();
		}

		protected void OnDrawGizmos() {
		//protected void OnDrawGizmosSelected() {
			Gizmos.color = Color.red;
			//gizmo_awake();

			_generate_position();

			//Gizmos.DrawLine( position_top_left, position_bottom_left);
			Vector2 tmp_position_top_left = position.top + position.left;
			Vector2 tmp_position_bottom_left = position.bottom + position.left;
			//tmp_position_bottom_left = transform.TransformPoint( tmp_position_bottom_left );
			//tmp_position_top_left = transform.TransformPoint( tmp_position_top_left );
			float step_width = cell.width;
			for ( int i = 0; i <= columns; ++i ) {
				Gizmos.DrawLine( tmp_position_top_left, tmp_position_bottom_left);
				tmp_position_bottom_left.x += step_width;
				tmp_position_top_left.x += step_width;
			}

			tmp_position_top_left = position.top + position.left;
			Vector2 tmp_position_top_rigth = position.top + position.rigth;

			//tmp_position_top_rigth = transform.TransformPoint( tmp_position_top_rigth );
			//tmp_position_top_left = transform.TransformPoint( tmp_position_top_left );
			float step_height = cell.height;
			for ( int i = 0; i <= rows; ++i ) {
				Gizmos.DrawLine( tmp_position_top_left, tmp_position_top_rigth );
				tmp_position_top_left.y -= step_height;
				tmp_position_top_rigth.y -= step_height;
			}
		}
	}
}
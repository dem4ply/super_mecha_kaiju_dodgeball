using System.Collections.Generic;
using UnityEngine;
using snippet.objects;


namespace geometry {
	namespace grid {
		public class Grid : chibi_base.Chibi_behaviour {

			protected int _columns, _rows;
			protected float _height = 1f, _width = 1f;

			protected BoxCollider2D _collider;

			public Container container;
			public cell.Cell base_cell;

			protected List<List<cell.Cell>> matriz_cell;

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
			/// Columnas que tiene el grid
			/// </summary>
			public int columns {
				get {
					return _columns;
				}
				set {
					_columns = value;
				}
			}

			/// <summary>
			/// Filas que tiene el grid
			/// </summary>
			public int rows {
				get {
					return _rows;
				}
				set {
					_rows = value;
				}
			}

			/// <summary>
			/// altura del grid
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
			/// anchura del grid
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

			/// <summary>
			/// cambia el tamano del collider segun la anchura y la altura
			/// </summary>
			protected void resize_collider() {
				collider.size = new Vector2( width, height );
				_build_position();
			}

			public void resize() {
				height = base_cell.height * rows;
				width = base_cell.width * columns;
				resize_collider();
				container.clean();
				_create_matriz_cells();
				reposicionate_cells();
			}

			/// <summary>
			/// Instancia una copia de la celda base
			/// </summary>
			/// <returns>copia de la celda base</returns>
			protected virtual cell.Cell _instanciate_cell() {
				cell.Cell new_cell = container.instanciate<cell.Cell>(
					base_cell, true );
				return new_cell;
			}

			/// <summary>
			/// contrulle la matriz de celdas
			/// </summary>
			protected virtual void _create_matriz_cells() {
				matriz_cell = new List<List<cell.Cell>>();
				for ( int i = 0; i < columns; ++i ) {
					matriz_cell.Add( new List<cell.Cell>( columns ) );
					for ( int j = 0; j < rows;  ++j ) {
						matriz_cell[i].Add( _instanciate_cell() );
					}
				}
			}

			/// <summary>
			/// reposiciona todas las celdas en su lugar correcto segun su indice
			/// </summary>
			protected virtual void reposicionate_cells() {
				for ( int i = 0; i < columns; ++i ) {
					for ( int j = 0; j < rows; ++j ) {
						matriz_cell[i][j].transform.localPosition =
							get_local_vector_of_cell( i, j );
					}
				}
			}

			protected void OnDrawGizmos() {
				_init_cache();
				base_cell.extert_init_cache();

				Gizmos.color = Color.red;
				Vector2 pos_top_left = position.top + position.left;
				Vector2 pos_bottom_left = position.bottom + position.left;
				pos_top_left = transform.TransformPoint( pos_top_left );
				pos_bottom_left = transform.TransformPoint( pos_bottom_left );
				float width = base_cell.width;
				for ( int i = 0; i <= columns; ++i ) {
					Gizmos.DrawLine( pos_top_left, pos_bottom_left );
					pos_bottom_left.x += width;
					pos_top_left.x += width;
				}

				pos_top_left = position.top + position.left;
				Vector2 pos_top_right = position.top + position.rigth;
				pos_top_left = transform.TransformPoint( pos_top_left );
				pos_top_right = transform.TransformPoint( pos_top_right );

				float height = base_cell.height;
				for ( int i = 0; i <= rows ; ++i ) {
					Gizmos.DrawLine( pos_top_left, pos_top_right);
					pos_top_left.y -= height;
					pos_top_right.y -= height;
				}

				Vector3 center = position.top + position.left;
				center = transform.TransformPoint( center );
				center.x += base_cell.width * 0.5f;
				center.y -= base_cell.height * 0.5f;

				// float x_initial = center.x;
				float y_initial = center.y;

				for ( int i = 0; i < columns; ++i ) {
					//center.x = x_initial;
					for ( int j = 0; j < rows; ++j ) {
						Gizmos.DrawWireSphere( center, 0.05f );
						center.y -= height;
					}

					center.x += width;
					center.y = y_initial;

				}
			}

			/// <summary>
			/// obtiene el vector local del centro de la celda
			/// </summary>
			/// <param name="column"> columna de la celda </param>
			/// <param name="row"> fila de la celda </param>
			/// <returns></returns>
			public virtual Vector3 get_local_vector_of_cell(
				int column, int row ) {

				Vector3 top_left = position.top + position.left;
				top_left.x += ( base_cell.width * 0.5f )
					+ ( base_cell.width * column );
				top_left.y -= ( base_cell.height * 0.5f )
					+ ( base_cell.height * row );
				return top_left;
			}

			/// <summary>
			/// obtiene el vector del mundo del centro de la celda
			/// </summary>
			/// <param name="column"> columna de la celda </param>
			/// <param name="row"> columna de la fila </param>
			/// <returns></returns>
			public virtual Vector3 get_world_vector_of_cell(
				int column, int row ) {

				return transform.TransformPoint(
					get_local_vector_of_cell( column, row ) );

			}

			/// <summary>
			/// envia la senal a todos las celdas para activarlas o desactivarlas
			/// </summary>
			/// <param name="active">senal</param>
			public virtual void activate_cells( bool active ) {
				for ( int i = 0; i < columns; ++i )
					for ( int j = 0; j < rows; ++j )
						matriz_cell[i][j].gameObject.SetActive( active );
			}

			/// <summary>
			/// desactiva o activa todos los colliders de las celdas
			/// </summary>
			/// <param name="active">senal</param>
			public virtual void activate_colliders_cells( bool active ) {
				for ( int i = 0; i < columns; ++i )
					for ( int j = 0; j < rows; ++j )
						matriz_cell[i][j].GetComponent<Collider2D>()
							.enabled = active;
			}

		}
	}
}
using System;
using System.Xml;
using helper;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace metroidvania.grid
{
	[System.Serializable]
	public class Chibi_grid<T>
	{
		public int width;
		public int height;

		public Transform origin;
		public int size;
		public TextMesh[,] debug_text;

		protected T[,] grid_array;
		protected RectTransform rect_transform;

		public virtual float offsect
		{
			get
			{
				return 1f;
			}
		}

		public Chibi_grid()
		{
			grid_array = new T[ this.width, this.height ];
		}

		public Chibi_grid( int width, int height )
		{
			this.width = width;
			this.height = height;

			grid_array = new T[ this.width, this.height ];
			debug_text = new TextMesh[ this.width, this.height ];
			//rect_transform = origin.GetComponent<RectTransform>();
		}

		public void init()
		{
			grid_array = new T[ this.width, this.height ];
			debug_text = new TextMesh[ this.width, this.height ];
			rect_transform = origin.GetComponent<RectTransform>();
		}

		public virtual void debug()
		{
			UnityEngine.Debug.Log( string.Format( "Grid shape: {0}, {1}", this.width, this.height ) );
		}

		public virtual void show_debug()
		{
			var rotation = Quaternion.Euler( 0, 0, 0 );
			var position_w = get_world_position( width, 0 );
			var position_h = get_world_position( 0, height );
			var position_x_1 = get_world_position( width, height );
			var position_y_1 = get_world_position( width, height );
			// lineas vertical final
			Debug.DrawLine( position_w, position_x_1, Color.white, 100f );
			// linea horizontal final
			Debug.DrawLine( position_h, position_y_1, Color.white, 100f );
			helper.draw.sphere.debug(
				origin.position, Color.black, 1f, 100f );
			for ( int x = 0; x < width; ++x )
				for ( int y = 0; y < height; ++y )
				{
					var position = get_world_position( x, y );
					position_x_1 = get_world_position( x + 1, y );
					position_y_1 = get_world_position( x, y + 1 );

					helper.draw.sphere.debug(
						position, new Color( 50, x * 10, y * 10 ), 1f, 100f );
					debug_text[ x, y ] = helper.text._(
						build_debug_text( x, y ), null,
						//position + new Vector3( size, -size, 0 ) * 0.5f,
						get_world_position_center_cell( x, y ),
						size,
						rotation, anchor:TextAnchor.MiddleCenter );

					Debug.DrawLine( position, position_x_1, Color.white, 100f );
					Debug.DrawLine( position, position_y_1, Color.white, 100f );
					//Debug.Log( string.Format( "x: {0}, y: {1}", x, y ) );
				}
		}

		public virtual string build_debug_text( int x, int y )
		{
			return string.Format( "{0}, {1} = {2}", x, y, grid_array[ x, y ] );
		}

		/// <summary>
		/// obtiene el vector de la esquina superior izquierda de la celda x, y
		/// <param name="x">columna del grid</param>
		/// <param name="y">fila del grid</param>
		/// </summary>
		public virtual Vector3 get_world_position( int x, int y )
		{
			return origin.position + new Vector3( x, -y, 0 ) * size;
		}

		/// <summary>
		/// obtiene el vector del centro de la celda x, y
		/// <param name="x">columna del grid</param>
		/// <param name="y">fila del grid</param>
		/// </summary>
		public virtual Vector3 get_world_position_center_cell( int x, int y )
		{
			Vector3 upper_left_corner = get_world_position( x, y );
			float offsect = this.offsect;
			return upper_left_corner
				+ ( new Vector3( size * offsect, -size * offsect, 0 ) * 0.5f );
		}

		public virtual void get_x_y_from_world( Vector3 vector, out int x, out int y )
		{
			x = Mathf.FloorToInt( ( vector.x - origin.position.x ) / size );
			y = Mathf.FloorToInt( ( vector.z - origin.position.z ) / size );
		}

		public Vector2 get_x_y_from_world( Vector3 vector )
		{
			int x, y;
			get_x_y_from_world( vector, out x, out y );
			return new Vector2( x, y );
		}

		public virtual void move_to_world_position( GameObject obj, int x, int y )
		{
			Vector3 desire_position = get_world_position( x, y );
			Vector3 offset_to_center = new Vector3( size, -size, 0 );
			offset_to_center = offset_to_center * 0.5f;
			obj.transform.position = desire_position + offset_to_center;
		}

		public virtual void move_to_ui( GameObject obj, int x, int y )
		{
			Vector3 desire_position = get_world_position( x, y );
			Vector3 offset_to_center = new Vector3( size, -size, 0 );
			offset_to_center = offset_to_center * 0.5f;
			obj.transform.position = desire_position + offset_to_center;
		}

		public virtual void get_x_y_from_ui( Vector3 vector, out int x, out int y )
		{
			float relative_grid_x = vector.x - rect_transform.position.x;
			float relative_grid_y = rect_transform.position.y - vector.y;

			x = Mathf.FloorToInt( relative_grid_x / size );
			y = Mathf.FloorToInt( relative_grid_y / size );
		}

		public virtual Vector2 get_x_y_from_ui( Vector3 vector )
		{
			int x, y;
			get_x_y_from_ui( vector, out x, out y );
			return new Vector2( x, y );
		}

		public T this[ int x, int y ]
		{
			get {
				return grid_array[ x, y ];
			}
			set {
				grid_array[ x, y ] = value;
				debug_text[ x, y ].text = value.ToString();
			}
		}

		public T this[ int x, int y, int width, int height ]
		{
			set {
				for( int i_x = x; i_x < width + x; ++i_x )
					for( int i_y = y; i_y < height + y; ++i_y )
						this[ i_x, i_y ] = value;
			}
		}

		public T this[ Vector3 vector ]
		{
			get {
				int x, y;
				get_x_y_from_world( vector, out x, out y );
				return this[ x, y ];
			}
			set {
				int x, y;
				get_x_y_from_world( vector, out x, out y );
				this[ x, y ] = value;
			}
		}

		/// <summary>
		/// busca un espacio vacio en el inventario del tamaño del rectangulo
		/// <example>
		/// For example:
		/// <code>
		/// </code>
		/// los paremetgros x, y son el output
		/// </example>
		/// <param name="wifth">ancho del rectangulo a buscar</param>
		/// <param name="height">alto del rectangulo a buscar</param>
		/// </summary>
		public void find_empty_space( int width, int height, out int x, out int y )
		{
			if ( width > this.width )
				throw new ArgumentOutOfRangeException( "el width buscado es mayor que el width del grid" );
			if ( height> this.height )
				throw new ArgumentOutOfRangeException( "el height buscado es mayor que el height del grid" );
			for( int j = 0; j < this.height; ++j )
				for( int i = 0; i < this.width; ++i )
				{
					//helper.debug.obj_debug.info( "{0}, {1} : {2}, {3}", i, j, width, height );
					if ( is_empty_this_rectangle( i, j, width, height ) )
					{
						x = i;
						y = j;
						return;
					}
				}
			x = -1;
			y = -1;
		}

		/// <summary>
		/// verifica si el rectiangulo esta desocupado en las cordenadas dadas
		/// <example>
		/// For example:
		/// <code>
		/// </code>
		/// los paremetgros x, y son el output
		/// </example>
		/// <param name="x">posicion x donde  se busca</param>
		/// <param name="y">posicion y donde se busca</param>
		/// <param name="width">ancho del rectangulo a buscar</param>
		/// <param name="height">alto del rectangulo a buscar</param>
		/// </summary>
		public bool is_empty_this_rectangle( int x, int y, int width, int height )
		{
			bool result = true;
			for( int w = x; w < x + width && result; ++w )
				for( int h = y; h < y + height && result; ++h )
				{
					// helper.debug.obj_debug.info( "{0}, {1} : {2}, {3} {4}, {5}", w, h, x, y, width, height );
					if( !position_is_empty( w, h ) )
						return false;
				}
			return result;
		}

		public bool position_is_empty( int x, int y )
		{
			object value = grid_array[ x, y ];
			switch ( value )
			{
				case int i:
					return i == 0;
				case metroidvania.inventory.item.Item_grid item:
					if ( item != null )
					{
						return false;
					}
					return item == null;
				default:
					if ( value == null )
						return true;
					throw new NotImplementedException( string.Format( "no se implemento el tipo {0}", value.GetType().ToString() ) );
			}
		}
	}
}

using System;
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
		}

		public void init()
		{
			grid_array = new T[ this.width, this.height ];
			debug_text = new TextMesh[ this.width, this.height ];
		}

		public void debug()
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
			for ( int x = 0; x < width; ++x )
				for ( int y = 0; y < height; ++y )
				{
					debug_text[ x, y ] = helper.text._(
						build_debug_text( x, y ), null,
						get_world_position( x, y ) + new Vector3( size, 0, size ) * 0.5f,
						size,
						rotation, anchor:TextAnchor.MiddleCenter );

					var position = get_world_position( x, y );
					position_x_1 = get_world_position( x + 1, y );
					position_y_1 = get_world_position( x, y + 1 );
					Debug.DrawLine( position, position_x_1, Color.white, 100f );
					Debug.DrawLine( position, position_y_1, Color.white, 100f );
					//Debug.Log( string.Format( "x: {0}, y: {1}", x, y ) );
				}
		}

		public virtual string build_debug_text( int x, int y )
		{
			return string.Format( "{0}, {1} = {2}", x, y, grid_array[ x, y ] );
		}

		public virtual Vector3 get_world_position( int x, int y )
		{
			//return new Vector3( x, y, 0 ) * size + origin.position;
			return new Vector3( x, y, 0 ) * size
			+ ( origin.position - new Vector3( width * ( size / 2 ), height * ( size / 2 ), 0 ) );
		}

		public virtual void get_x_y_from_world( Vector3 vector, out int x, out int y )
		{
			x = Mathf.FloorToInt( ( vector.x - origin.position.x ) / size );
			y = Mathf.FloorToInt( ( vector.z - origin.position.z ) / size );
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
	}
}

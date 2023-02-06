using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace tactic.grid.obj
{
	[System.Serializable]
	public class Grid_XY<T> : Grid<T>
	{
		public Grid_XY(
			int width, int height, float size, Vector3 origin,
			Func<Grid<T>, int, int, T> create_grid_object )
			: base( width, height, size, origin, create_grid_object )
		{
		}

		public override void show_debug()
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
						get_world_position( x, y ) + new Vector3( size, -size, 0) * 0.5f,
						rotation, anchor:TextAnchor.MiddleCenter );

					var position = get_world_position( x, y );
					position_x_1 = get_world_position( x + 1, y );
					position_y_1 = get_world_position( x, y + 1 );
					Debug.DrawLine( position, position_x_1, Color.white, 100f );
					Debug.DrawLine( position, position_y_1, Color.white, 100f );
					//Debug.Log( string.Format( "x: {0}, y: {1}", x, y ) );
				}
		}

		public override string build_debug_text( int x, int y )
		{
			int x2, y2;
			var v = get_world_position( x, y );
			get_x_y_from_world( v, out x2, out y2 );
			//helper.draw.sphere.debug( v, Color.blue, duration:100f  );
			return string.Format( "{0}, {1} = {2}\n{3}, {4} = {5}",
				x, y, grid[ x, y ], x2, y2, v );
		}

		public override Vector3 get_world_position( int x, int y )
		{
			//helper.draw.arrow.debug( origin, new Vector3( x, -y, 0 ) * size, Color.blue, duration:100f  );
			return new Vector3( x, -y, 0 ) * size + origin;
		}

		public override void get_x_y_from_world( Vector3 vector, out int x, out int y )
		{
			//var diff = vector - origin;
			//x = Mathf.FloorToInt( diff.x / size );
			//y = Mathf.FloorToInt( diff.y / size );
			x = Mathf.FloorToInt( ( vector.x - origin.x ) / size );
			y = Mathf.FloorToInt( ( origin.y - vector.y ) / size );
		}
	}
}

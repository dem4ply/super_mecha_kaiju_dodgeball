using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

namespace tactic.grid.ui
{
	public class Grid_ui : chibi.Chibi_behaviour
	{
		public obj.Grid_XY<bool> grid;
		public Camera camera;
		protected RectTransform _rect_transform;

		protected override void _init_cache()
		{
			base._init_cache();
			_rect_transform = this.GetComponent< RectTransform >();
			grid = new obj.Grid_XY<bool>(
				6, 5, 50, transform.position,
				( obj.Grid<bool> g, int x, int y ) => true );

			//grid[ 1, 1 ] = 33;
		}

		protected void Update()
		{
			if ( UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame )
			{

				Vector3 position_mouse = helper.mouse.axis;
				Vector3 anchored_position;
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(
            //   _rect_transform, position_mouse, null, out anchored_position );
				RectTransformUtility.ScreenPointToWorldPointInRectangle(
               _rect_transform, position_mouse, null, out anchored_position );
				int x, y;
				grid.get_x_y_from_world( anchored_position, out x, out y );

				if ( x >= 0 && y >= 0 && x < grid.width && y < grid.height )
				{
					grid[ x, y ] = !grid[ x, y ];
				}
			}
		}

	}
}

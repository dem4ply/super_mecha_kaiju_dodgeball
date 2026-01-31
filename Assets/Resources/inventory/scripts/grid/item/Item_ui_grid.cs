using System;
using helper;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using inventory.item;

namespace inventory.ui.grid.item
{
	public class Item_ui_grid: chibi.Chibi_ui, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler
	{
		//public chibi.inventory.item.Item item;
		public Item_grid item;

        public void move_to_cell_grid(
            inventory.ui.grid.Grid_ui grid, int x, int y )
        {
            debug.log( "mover a {0} en la posiscion {1} {2}", grid, x, y );
            // Vector3 final = grid.grid.get_world_position( x, y );
            grid.grid.move_to_world_position( this.gameObject, x, y );
        }

        public void move_to_cell_grid(
            inventory.ui.grid.Grid_ui grid,
            int x, int y,
            int width, int height )
        {
            grid.grid.move_to_world_position( this.gameObject, x, y, width, height );
        }

        protected override void _init_cache()
        {
            start_one_second_late_init();
        }

        protected override IEnumerator late_init(float wait)
        {
            yield return base.late_init(wait);
			if ( !item )
				debug.error( "el item no fue asignado" );
        }

        public void OnPointerExit( PointerEventData eventData )
        {
            debug.log( "mouse salio del item ui {0}", this.name );
        }

        public void OnPointerEnter( PointerEventData eventData )
        {
            debug.log( "mouse entro al item ui {0}", this.name );
        }

        public void OnPointerClick( PointerEventData eventData )
        {
			debug.log( "click en el item, cordenadas de mouse {0}", helper.mouse.axis );
			int x = 0, y = 0;
			Vector2 mouse_axis = helper.mouse.axis;
			// grid.get_x_y_from_ui( mouse_axis, out x, out y );
			// debug.log( "click fue en las celdas {0}, {1}", x, y );
        }

        public void OnDrag(PointerEventData eventData)
        {
			debug.log( "arrastrando el item {0}, cordenadas de mouse {1}", this.name, helper.mouse.axis );
        }
    }
}

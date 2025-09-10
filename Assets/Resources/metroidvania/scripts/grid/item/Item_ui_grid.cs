using System;
using helper;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

namespace metroidvania.grid.item
{
	public class Item_ui_grid: chibi.Chibi_ui, IPointerEnterHandler, IPointerExitHandler
	{
		public chibi.inventory.item.Item item;

        public void move_to_cell_grid(
            metroidvania.grid.ui.Grid_ui grid, int x, int y )
        {
            debug.log( "mover a {0} en la posiscion {1} {2}", grid, x, y );
            // Vector3 final = grid.grid.get_world_position( x, y );
            grid.grid.move_to_world_position( this.gameObject, x, y );
        }

        public void move_to_cell_grid(
            metroidvania.grid.ui.Grid_ui grid,
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

        public void OnPointerExit(PointerEventData eventData)
        {
            debug.log( "mouse salio del item ui {0}", this.name );
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            debug.log( "mouse entro al item ui {0}", this.name );
        }
    }
}

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
	public class Item_ui_grid: chibi.Chibi_ui,
		IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
	{
		//public chibi.inventory.item.Item item;
		public Item_grid item;

		protected Item_ui_grid _drag_item;

		public Item_ui_grid drag_item
		{
			get
			{
				return _drag_item;
			}
		}

		public void move_to_cell_grid(
			inventory.ui.grid.Grid_ui grid, int x, int y )
		{
			debug.log( "mover a {0} en la posiscion {1} {2}", grid, x, y );
			// Vector3 final = grid.grid.get_world_position( x, y );
			grid.grid.move_to_world_position( this.gameObject, x, y );
		}

		public void move_to_cell_grid(
			inventory.ui.grid.Grid_ui grid, int x, int y, int width, int height )
		{
			grid.grid.move_to_world_position( this.gameObject, x, y, width, height );
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !item )
				debug.error( "el item no fue asignado" );
			if( _drag_item )
			{
				debug.warning( "la variable _drag_item esta asignada en el init" );
				recicle_drag_item();
			}
			start_one_second_late_init();
		}

		protected override IEnumerator late_init(float wait)
		{
			yield return base.late_init( wait );
			// base._init_cache();
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
			move_drag_item();
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			debug.log( "inicio del arrastrado del item {0}, cordenadas de mouse {1}", this.name, helper.mouse.axis );
			start_drag_item();
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			debug.log( "termina del arrastrado del item {0}, cordenadas de mouse {1}", this.name, helper.mouse.axis );
			end_drag_item();
		}

		public void start_drag_item()
		{
			if( _drag_item )
			{
				debug.warning( "la variable _drag_item esta asignada en el start drag" );
				recicle_drag_item();
			}
			_drag_item = this.clone().GetComponent<Item_ui_grid>();
			_drag_item.rect_transform.position = this.rect_transform.position;
			_drag_item.ui.image.transparency = 0.5f;
		}

		public void end_drag_item()
		{
			recicle_drag_item();
		}

		public void move_drag_item()
		{
			_drag_item.rect_transform.position = helper.mouse.axis;
		}

		protected void recicle_drag_item()
		{
			debug.log( "reciclando _drag_item" );
			_drag_item.recycle();
		}
	}
}
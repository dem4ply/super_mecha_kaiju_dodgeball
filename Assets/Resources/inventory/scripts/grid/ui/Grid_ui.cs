using System;
using helper;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

namespace inventory.ui.grid
{
	public class Grid_ui: chibi.Chibi_ui, IPointerEnterHandler, IPointerExitHandler
	{
		public inventory.grid.Chibi_grid_ui<inventory.item.Item_grid> grid;
		public GridLayoutGroup grid_ui;
		public GameObject prefab_cell_ui;
		public GameObject canvas;

		public chibi.inventory.Inventory inventory;
		public GameObject item_ui_prefab_base;

		public bool show_init_debug = true;

        protected override void _init_cache()
        {
            base._init_cache();
			if ( !inventory )
			{
				debug.error( "no esta asignado inventory" );
			}
			prepare_rect();
			if ( !grid_ui )
				debug.error(
					"no se asigno el grid ui, deberia de ser "
					+ "un gameobject hijo de este gameobject" );
			if ( !prefab_cell_ui )
			{
				debug.error(
					"no se asigno el prefab_cell_ui para rellenar el grid ui" );
			}
			else
			{
				fill_grid();
			}
			if ( grid == null )
				this.debug.error( "no tiene asignado un grid" );
			else
			{
				if ( !grid.origin )
				{
					debug.warning(
						"no se asigno origin del grid se asume que "
						+ "es este gameobject" );
					grid.origin = this._rect_transform;
				}
				grid.init();
				//grid.origin = this.transform;
			}
			if ( !canvas )
			{
				debug.warning(
					"no se asigno el canvas al grid_ui "
					+ "se usara la busqueda del canvas" );
				canvas = helper.game_object.canvas.find_canvas();
			}
			if ( !item_ui_prefab_base )
			{
				debug.error(
					"no se asigno el item ui prefab base "
					+ "sin el no puede generar items en el grid" );
			}
			prepare_ui_grid();
			if ( this.show_init_debug )
				grid.show_debug();
        }

		protected void prepare_ui_grid()
		{
			float width = grid.size * grid.width;
			float height = grid.size * grid.height;
			// var rect = grid_ui.GetComponent< RectTransform >();
			// rect.sizeDelta = new Vector2( width, height );
			var grid_layout = grid_ui.GetComponent< GridLayoutGroup >();

			if ( grid_layout.constraint == GridLayoutGroup.Constraint.FixedColumnCount )
				grid_layout.constraintCount = grid.width;
			else if ( grid_layout.constraint == GridLayoutGroup.Constraint.FixedRowCount)
				grid_layout.constraintCount = grid.height;
			else
				throw new System.NotImplementedException( "no tengo ni idea de como implementar el flexible" );

			grid_layout.cellSize = new Vector2( grid.size, grid.size );
		}

		protected override void prepare_rect()
		{
			_rect_transform.pivot = new Vector2( 0, 1 );
			_rect_transform.anchorMax = new Vector2( 0, 1 );
			_rect_transform.anchorMin = new Vector2( 0, 1 );
		}

		protected void fill_grid()
		{
			int total_elements = grid.width * grid.height;
			for( int i = 0; i < total_elements; ++i )
				helper.instantiate.ui.parent( prefab_cell_ui, grid_ui.transform );
		}

        public void OnPointerExit(PointerEventData eventData)
        {
            debug.log( "mouse salio del inventario" );
			//helper.mouse.axis
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            debug.log( "mouse entro al inventario" );
        }

		public void add( inventory.item.Item_grid item )
		{
			debug.warning( "agregar al inventario" );
			inventory.add( item );
			// foreach( var i in inventory.inventory.stacks )
			// debug.log( "{0}: {1} : {2}", i.item, i.amount, i.ToString() );
			debug.warning( "agregar al grid" );
			debug.log( "agregar al grid: {0} * {1}", item.width, item.height );

			// GameObject canvas = helper.game_object.canvas.find_canvas();

			var item_obj = this.create_new_item_ui( item );
			var item_ui = item_obj.GetComponent< inventory.ui.grid.item.Item_ui_grid >();
			// var img = helper.game_object.canvas.add_img_canvas( canvas, item.image, item.name );
			// img.SetNativeSize();
			// GameObject img_obj = img.gameObject;
			// var item_ui = img_obj.AddComponent< inventory.ui.grid.item.Item_ui_grid >();
			// item_ui.item = item;

			int x, y;
			try
			{
				grid.find_empty_space( item.width, item.height, out x, out y );
			}
			catch ( ArgumentOutOfRangeException e )
			{
				debug.warning( "el item {0} no cabe en el inventario", item );
				return;
			}
			if ( x == -1 && y == -1 )
				debug.error( "el item no cabe {0}", item );
			else
			{
				// debug.log( "el item cabe en {0}, {1}", x, y );
				item_ui.move_to_cell_grid( this, x, y, item.width, item.height );
				grid[ x, y, item.width, item.height ] = item;

				Vector3 pos = grid.get_world_position( 0, 0 );
			}
		}

		public GameObject create_new_item_ui( inventory.item.Item_grid item )
		{
			// no prefab base
			if ( !item_ui_prefab_base )
				return scrach_create_new_item_ui( item );
			GameObject img_obj = helper.instantiate.ui.parent( item_ui_prefab_base, canvas );

			var item_ui = img_obj.GetComponent<
				inventory.ui.grid.item.Item_ui_grid >();
			if ( !item_ui )
			{
				debug.error(
					"item_ui_prefab_base no tiene el "
					+ "componente item_ui_grid" );
			}
			else
			{
				item_ui.item = item;
			}
			return img_obj;
		}

		public GameObject scrach_create_new_item_ui( inventory.item.Item_grid item )
		{
			var img = helper.game_object.canvas.add_img_canvas( canvas, item.image, item.name );
			img.SetNativeSize();
			GameObject img_obj = img.gameObject;
			var item_ui = img_obj.AddComponent< inventory.ui.grid.item.Item_ui_grid >();
			item_ui.item = item;
			return img_obj;
		}

		public void move_to_cell( int x, int y )
		{
			//Vector3 desire_position = get_world_position( x, y );
			//Vector3 offset_to_center = new Vector3( size, -size, 0 );
			//offset_to_center = offset_to_center * 0.5f;
			//obj.transform.position = desire_position + offset_to_center;
		}
    }
}

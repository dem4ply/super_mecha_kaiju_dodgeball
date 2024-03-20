using System;
using helper;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace metroidvania.grid.ui
{
	public class Grid_ui: chibi.Chibi_ui, IPointerEnterHandler, IPointerExitHandler
	{
		public Chibi_grid_ui<metroidvania.inventory.item.Item_grid> grid;
		public GridLayoutGroup grid_ui;
		public GameObject prefab_cell_ui;

		public chibi.inventory.Inventory inventory;

        protected override void _init_cache()
        {
			if ( !prefab_cell_ui )
			{
				debug.error(
					"no se asigno el prefab_cell_ui para rellenar el grid ui" );
			}
			else
			{
				fill_grid();
			}
            base._init_cache();
			if ( grid == null )
				this.debug.error( "no tiene asignado un grid" );
			else
			{
				grid.init();
				//grid.origin = this.transform;
			}
			if ( !grid_ui )
				debug.error(
					"no se asigno el grid ui, deberia de ser "
					+ "un gameobject hijo de este gameobject" );
			prepare_ui_grid();
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

		public void add( metroidvania.inventory.item.Item_grid item )
		{
			debug.warning( "agregar al inventario" );
			inventory.add( item );
			// foreach( var i in inventory.inventory.stacks )
			// debug.log( "{0}: {1} : {2}", i.item, i.amount, i.ToString() );
			debug.warning( "agregar al grid" );
			debug.log( "agregar al grid: {0} * {1}", item.width, item.height );

			GameObject canvas = helper.game_object.canvas.find_canvas();
			var img = helper.game_object.canvas.add_img_canvas( canvas, item.image, item.name );
			img.SetNativeSize();
			GameObject img_obj = img.gameObject;
			var item_ui = img_obj.AddComponent< metroidvania.grid.item.Item_ui_grid >();
			item_ui.item = item;

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
				for ( int i = 0; i < grid.width; ++i )
					for ( int j = 0; j < grid.height; ++j )
						if ( grid[ i, j ] != null )
							debug.log( grid[ i, j  ] );
						else
							debug.log( "null" );

				Vector3 pos = grid.get_world_position( 0, 0 );
				// debug.log( " posicicion: {0}", pos );
				// debug.log( item_ui );
			}
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

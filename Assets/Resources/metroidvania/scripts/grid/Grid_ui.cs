using System;
using helper;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace metroidvania.grid
{
	public class Grid_ui: chibi.Chibi_ui, IPointerEnterHandler, IPointerExitHandler
	{
		public Chibi_grid<int> grid;
		public GridLayoutGroup grid_ui;
		public GameObject prefab_cell_ui;

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
			var rect = grid_ui.GetComponent< RectTransform >();
			//rect.sizeDelta = new Vector2( width, height );
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
    }
}

using System.Collections;
using System;
using helper;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace metroidvania.grid.ui
{
	public class Grid_ui_test: chibi.Chibi_ui
	{
		public Grid_ui grid;
		public chibi.inventory.Item test_item_prefab;
		public metroidvania.inventory.item.Item_grid item_obj;
		public metroidvania.inventory.item.Item_grid item_obj_2;
		public metroidvania.inventory.item.Item_grid item_obj_4;

        protected override void _init_cache()
        {
			var grid_layout = GetComponent< Grid_ui >();
			/*
			if ( !test_item_prefab )
				debug.error( "no se asigno el item de prueba" );
			*/
			start_one_second_late_init();
        }

		protected override IEnumerator late_init( float wait )
		{
			yield return base.late_init( wait );
			test_item();
		}


        public virtual void test_item()
		{
			grid.add( item_obj_2 );
			grid.add( item_obj_4 );
			grid.add( item_obj );
		}
    }
}

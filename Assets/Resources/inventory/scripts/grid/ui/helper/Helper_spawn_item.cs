using System;
using helper;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

namespace inventory.ui.grid.test_helper
{
	public class Helper_spawn_item: chibi.Chibi_ui
	{
		public inventory.item.Item_grid item_obj;
		public inventory.ui.grid.Grid_ui inventory_grid;


		public void add_item()
		{
			debug.log( "preciono add item" );
			inventory_grid.add( item_obj );
		}
    }
}

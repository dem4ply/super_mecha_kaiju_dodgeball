using System;
using helper;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace metroidvania.grid.item
{
	public class Item_ui_grid: chibi.Chibi_ui, IPointerEnterHandler, IPointerExitHandler
	{
		public chibi.inventory.item.Item item;
        protected override void _init_cache()
        {
			if ( !item )
				debug.error( "el item no fue asignado" );
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            debug.log( "mouse salio del item ui" );
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            debug.log( "mouse entro al item ui" );
        }
    }
}

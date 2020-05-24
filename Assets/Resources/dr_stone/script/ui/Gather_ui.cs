using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dr_stone.ui
{
	public class Gather_ui : chibi.Chibi_ui
	{
		List<chibi.inventory.item.Item> items;
		public GameObject slot_prefab;

		protected void Update()
		{
			if ( items.Count > 0 )
			{
				foreach ( var item in items )
				{
				}
			}
		}
	}
}

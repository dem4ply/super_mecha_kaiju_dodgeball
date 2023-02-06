using UnityEngine;
using System.Collections.Generic;
using System.Linq;


namespace chibi.inventory.obj
{
	[System.Serializable]
	public abstract class Inventory_base
	{
		public abstract void add( item.Item item );

		public abstract void add( item.Item item, int amount );

		public abstract void remove( item.Item item, int amount );

		protected abstract items_properties build_item_property( item.Item item );
	}
}

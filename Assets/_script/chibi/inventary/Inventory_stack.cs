using UnityEngine;
using System.Collections.Generic;

namespace chibi.inventory
{
	public class Inventory_stack : chibi.Chibi_behaviour
	{
		public Transform container;
		public chibi.inventory.obj.Inventory_stack inventory;

		public void add( item.Item item )
		{
			inventory.add( item );
		}

		public item.Item pop()
		{
			return inventory.pop();
		}

		public bool is_empty
		{
			get {
				return inventory.is_empty;
			}
		}

	}
}

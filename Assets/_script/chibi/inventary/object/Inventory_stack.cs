using UnityEngine;
using System.Collections.Generic;
using System.Linq;


namespace chibi.inventory.obj
{
	[System.Serializable]
	public class Inventory_stack : Inventory_base
	{
		public Stack<items_properties> items;
		public List<items_properties> list;

		public Inventory_stack()
		{
			items = new Stack<items_properties>();
		}
		public bool is_empty
		{
			get {
				return amount == 0;
			}
		}

		public int amount
		{
			get {
				return items.Count;
			}
		}

		public override void add( item.Item item )
		{
			var property = build_item_property( item );
			property.add_amount( 1 );
			items.Push( property );
			list = items.ToList();
		}

		public override void add( item.Item item, int amount )
		{
			for ( int i = 0; i < amount; ++i )
				add( item );
		}

		public override void remove( item.Item item, int amount )
		{
			items.Pop();
			list = items.ToList();
		}

		public virtual item.Item pop()
		{
			var result = items.Pop();
			list = items.ToList();
			return result.item;
		}

		protected override items_properties build_item_property( item.Item item )
		{
			var item_prop = new items_properties();
			item_prop.item = item;
			return item_prop;
		}
	}
}

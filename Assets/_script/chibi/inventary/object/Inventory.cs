using UnityEngine;
using System.Collections.Generic;
using System.Linq;


namespace chibi.inventory.obj
{
	[System.Serializable]
	public class Inventory : Inventory_base
	{
		public Dictionary<item.Item, List<items_properties>> items;
		public List<items_properties> all_lists;

		public Inventory()
		{
			items = new Dictionary<item.Item, List<items_properties>>();
		}

		public override void add( item.Item item )
		{
			add( item, 1 );
		}

		public override void add( item.Item item, int amount )
		{
			List<items_properties> stacks = new List<items_properties>();
			if ( !items.TryGetValue( item, out stacks ) )
			{
				stacks = new List<items_properties>();
				items.Add( item, stacks );
			}
			add_item_to_stack( item, stacks, amount );
		}

		public override void remove( item.Item item, int amount )
		{
			List<items_properties> stacks = new List<items_properties>();
			if ( items.TryGetValue( item, out stacks ) )
			{
				remove_item_to_stack( item, stacks, amount );
			}
		}

		protected override items_properties build_item_property( item.Item item )
		{
			var item_prop = new items_properties();
			item_prop.item = item;
			return item_prop;
		}

		protected void add_item_to_stack(
			item.Item item, List<items_properties> stacks, int amount )
		{
			if ( item.max_stack_amount < 1 )
			{
				return;
			}
			foreach ( items_properties stack in stacks )
			{
				amount = stack.add_amount( amount );
			}
			int whiles = 0;
			while ( amount > 0 )
			{
				var stack = build_item_property( item );
				stacks.Add( stack );
				amount = stack.add_amount( amount );
				whiles += 1;
				if ( whiles > 100 )
				{
					break;
				}
			}

			//all_lists = items.Values.ToList();
			all_lists = this.stacks.ToList();
		}

		protected void remove_item_to_stack(
			item.Item item, List<items_properties> stacks, int amount )
		{
			foreach ( items_properties stack in stacks )
			{
				amount = stack.remove_amount( amount );
			}
			stacks.RemoveAll( ( stack ) => stack.amount < 1 );
			//all_lists = items.Values.ToList();
			all_lists = this.stacks.ToList();
		}

		public IEnumerable<items_properties> stacks
		{
			get {
				foreach ( var stacks in items.Values )
					foreach ( var stack in stacks )
						yield return stack;
			}
		}

	}
}

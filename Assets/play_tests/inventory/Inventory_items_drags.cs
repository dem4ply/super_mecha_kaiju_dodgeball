using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using inventory.ui.grid;
using inventory.item;
using chibi.inventory;
using tests_tool.assert;
using inventory.ui.grid.item;

namespace tests.inventory.grid.ui
{
	public class Inventory_items_drags : helper.tests.Scene_test
	{
        Grid_ui grid_ui;
		Item_grid arco, baston, rabano;

		public override string scene_dir
		{
			get {
                return "inventory/tests/scene/inventory base";
				// return "tests/scene/chibi/controller/soldier/turrent controller";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();

			grid_ui = helper.game_object.Find._< Grid_ui >(
				scene, "Inventory" );
			string arco_path = "inventory/tests/items/arco";
			string baston_path = "inventory/tests/items/baston";
			string rabano_path = "inventory/tests/items/rabano";
			arco = this.load_script_object<Item_grid>( arco_path );
			baston = this.load_script_object<Item_grid>( baston_path );
			rabano = this.load_script_object<Item_grid>( rabano_path );
		}

		[UnityTest]
		public IEnumerator should_work()
		{
			yield return new WaitForSeconds( 1f );
			Assert.NotNull( arco, "el arco no se pudo cargar" );
			Assert.Pass( "deberia de funcionar" );
		}

		public Item_ui_grid add_item( Item_grid item_to_use )
		{
			grid_ui.add( item_to_use );
			var new_item = grid_ui[ item_to_use ];
			var obj = new_item[0].gameObject;
			return obj.GetComponent< Item_ui_grid >();
		}

		public void start_drag( Item_ui_grid item_ui )
		{
			item_ui.start_drag_item();
		}

		public void end_drag( Item_ui_grid item_ui )
		{
			item_ui.end_drag_item();
		}

		public void move_drag( Item_ui_grid item_ui, float x, float y )
		{
			Vector3 new_pos = new Vector3(
				x, y, item_ui.rect_transform.position.z );
			item_ui.rect_transform.position = new_pos;
		}

		[UnityTest]
		public IEnumerator item_when_start_to_drag_should_create_a_copy()
		{
			yield return min_wait;
			Item_grid item_to_use = rabano;
			var obj = add_item( item_to_use );
			start_drag( obj );
			yield return min_wait;

			var drag_item = obj.drag_item;
			Assert.IsTrue( drag_item );
		}

		[UnityTest]
		public IEnumerator item_when_start_drag_clone_should_be_in_same_position()
		{
			yield return min_wait;
			Item_grid item_to_use = rabano;
			var obj = add_item( item_to_use );
			start_drag( obj );
			yield return min_wait;

			var drag_item = obj.drag_item;
			helper.test.assert.vector3.similar(
				drag_item.rect_transform.position,
				obj.rect_transform.position );
		}

		[UnityTest]
		public IEnumerator item_when_end_to_drag_should_remove_a_copy()
		{
			yield return min_wait;
			Item_grid item_to_use = rabano;
			var obj = add_item( item_to_use );
			start_drag( obj );
			yield return min_wait;
			end_drag( obj );
			yield return min_wait;

			var drag_item = obj.drag_item;
			Assert.IsFalse( drag_item );
		}

		[UnityTest]
		public IEnumerator navegation_move_item()
		{
			yield return min_wait;
			Item_grid item_to_use = rabano;
			var obj = add_item( item_to_use );
			start_drag( obj );
			yield return min_wait;
			var drag_item = obj.drag_item;
			move_drag( drag_item, 300, 100 );
			yield return min_wait;

			yield return new WaitForSeconds( 10.1f );
			helper.test.assert.vector3.similar(
				drag_item.rect_transform.position,
				new Vector3( 300, 100 )
			);
		}

		[UnityTest]
		public IEnumerator navegation_move_to_cell()
		{
			yield return min_wait;
			Item_grid item_to_use = rabano;
			var obj = add_item( item_to_use );
			start_drag( obj );
			yield return min_wait;
			var drag_item = obj.drag_item;
			Vector3 move_vector = grid_ui.grid.get_world_position_center_cell( 2, 2 );
			move_drag( drag_item, move_vector.x, move_vector.y );
			yield return min_wait;

			yield return new WaitForSeconds( 10.1f );
			helper.test.assert.vector3.similar(
				drag_item.rect_transform.position,
				move_vector
			);
		}

		[UnityTest]
		public IEnumerator navegation_move_to_all_cells()
		{
			yield return min_wait;
			Item_grid item_to_use = rabano;
			var obj = add_item( item_to_use );
			start_drag( obj );
			yield return min_wait;
			var drag_item = obj.drag_item;
			for ( int x = 0; x < grid_ui.grid.width; ++x )
				for ( int y = 0; y < grid_ui.grid.height; ++y )
				{
					Vector3 move_vector = grid_ui.grid.get_world_position_center_cell( x, y );
					move_drag( drag_item, move_vector.x, move_vector.y );
					yield return new WaitForSeconds( 1f );
				}
		}
	}
}
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using inventory.ui.grid;
using inventory.item;
using chibi.inventory;
using tests_tool.assert;

namespace tests.inventory.grid.ui
{
	public class Inventory_items_names : helper.tests.Scene_test
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

		[UnityTest]
		public IEnumerator add_rabano_should_have_the_expected_name_in_the_gameobject()
		{
			yield return min_wait;
			Item_grid item_to_use = rabano;
			grid_ui.add( item_to_use );
			var new_item = grid_ui[ item_to_use ];
			var obj = new_item[0].gameObject;
			Assert.True(
				obj.name.Contains( item_to_use.name ),
				string.Format(
					"se esperaba que el nombre "
					+ "del item empesara con {0} pero era {1}",
					item_to_use.name, obj.name ) );
			yield return wait_second;
		}


		[UnityTest]
		public IEnumerator add_baston_should_have_the_expected_name_in_the_gameobject()
		{
			yield return min_wait;
			Item_grid item_to_use = baston;
			grid_ui.add( item_to_use );
			var new_item = grid_ui[ item_to_use ];
			var obj = new_item[0].gameObject;
			Assert.True(
				obj.name.Contains( item_to_use.name ),
				string.Format(
					"se esperaba que el nombre "
					+ "del item empesara con {0} pero era {1}",
					item_to_use.name, obj.name ) );
			yield return wait_second;
		}

		[UnityTest]
		public IEnumerator add_arco_should_have_the_expected_name_in_the_gameobject()
		{
			yield return min_wait;
			Item_grid item_to_use = arco;
			grid_ui.add( item_to_use );
			var new_item = grid_ui[ item_to_use ];
			var obj = new_item[0].gameObject;
			Assert.True(
				obj.name.Contains( item_to_use.name ),
				string.Format(
					"se esperaba que el nombre "
					+ "del item empesara con {0} pero era {1}",
					item_to_use.name, obj.name ) );
			yield return wait_second;
		}
	}
}
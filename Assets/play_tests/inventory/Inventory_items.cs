using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using inventory.ui.grid;
using inventory.item;

namespace tests.inventory.grid.ui
{
	public class Inventory_items : helper.tests.Scene_test
	{
        Grid_ui grid_ui;
		Item_grid arco;

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
			arco = this.load_script_object<Item_grid>( arco_path );
		}

		[UnityTest]
		public IEnumerator should_work()
		{
			yield return new WaitForSeconds( 1f );
			Assert.NotNull( arco, "el arco no se pudo cargar" );
            Assert.Pass( "deberia de funcionar" );
		}

		[UnityTest]
		public IEnumerator add_arco_should_add_item_into_grid()
		{
			yield return min_wait;
			Assert.True( grid_ui.inventory.is_empty );
			grid_ui.add( arco );
			Assert.True( grid_ui.inventory.is_not_empty );
			yield return wait_second;
		}
	}
}
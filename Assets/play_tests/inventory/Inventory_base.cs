using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using inventory.ui.grid;

namespace tests.inventory.grid.ui
{
	public class Inventory_base : helper.tests.Scene_test
	{
		Grid_ui grid_ui;

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
		}

		[UnityTest]
		public IEnumerator should_work()
		{
			yield return new WaitForSeconds( 1f );
			Assert.Pass( "deberia de funcionar" );
		}

		[UnityTest]
		public IEnumerator should_exists_grid_ui()
		{
			yield return min_wait;
			Assert.True( grid_ui, "grid_ui no deberia de ser null" );
		}

		[UnityTest]
		public IEnumerator grid_ui_property_should_be_assigned()
		{
			yield return min_wait;
			Assert.True( grid_ui.grid_ui, "grid_ui.grid_ui no deberia de ser null" );
		}

		[UnityTest]
		public IEnumerator prefab_cell_ui_property_should_be_assigned()
		{
			yield return min_wait;
			Assert.True( grid_ui.prefab_cell_ui, "grid_ui.prefab_cell_ui no deberia de ser null" );
		}

		[UnityTest]
		public IEnumerator grid_property_should_be_assigned()
		{
			yield return min_wait;
			Assert.NotNull( grid_ui.grid, "grid_ui.grid no deberia de ser null" );
			Assert.Greater( grid_ui.grid.width, 0 );
			Assert.Greater( grid_ui.grid.height, 0 );
		}

		[UnityTest]
		public IEnumerator when_initialize_should_instanciate_expected_grid_ui_cells()
		{
			/*
			Assert.AreEqual(
			grid_ui.grid_ui.transform.childCount, 0,
			"no deberia de tener las celdas inicializadas al inicio" );
			*/
			yield return min_wait;
			int expected = grid_ui.grid.width * grid_ui.grid.height;
			Assert.AreEqual(
				grid_ui.grid_ui.transform.childCount, expected,
				"deberia de tener la cantidad de celdas ( ancho * alto )" );
		}
	}
}
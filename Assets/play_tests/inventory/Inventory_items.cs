using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using inventory.ui.grid;
using inventory.item;
using chibi.inventory;

namespace tests.inventory.grid.ui
{
	public class Inventory_items : helper.tests.Scene_test
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
		public IEnumerator add_arco_should_add_item_into_grid()
		{
			yield return min_wait;
			Assert.True( grid_ui.inventory.is_empty );
			grid_ui.add( arco );
			Assert.True( grid_ui.inventory.is_not_empty );
			yield return wait_second;
		}

		[UnityTest]
		public IEnumerator add_baston_should_add_item_into_grid()
		{
			yield return min_wait;
			Assert.True( grid_ui.inventory.is_empty );
			grid_ui.add( baston );
			Assert.True( grid_ui.inventory.is_not_empty );
			yield return wait_second;
		}

		[UnityTest]
		public IEnumerator add_rabano_should_add_item_into_grid()
		{
			yield return min_wait;
			Assert.True( grid_ui.inventory.is_empty );
			grid_ui.add( rabano );
			Assert.True( grid_ui.inventory.is_not_empty );
			yield return wait_second;
		}

		[UnityTest]
		public IEnumerator add_rabano_should_have_one_item_in_the_list()
		{
			yield return min_wait;
			Assert.AreEqual( grid_ui.items.Count, 0 );
			Assert.True( grid_ui.inventory.is_empty );
			grid_ui.add( rabano );
			var new_item = grid_ui[ rabano ];
			Assert.AreEqual( new_item.Count, 1 );
			Assert.True( grid_ui.inventory.is_not_empty );
			foreach( var i in new_item )
			{
				Assert.AreEqual( i.item.name, rabano.name );
				Assert.AreEqual( i.item, rabano );
			}
			yield return wait_second;
		}


		[UnityTest]
		public IEnumerator add_baston_should_have_one_item_in_the_list()
		{
			yield return min_wait;
			Assert.AreEqual( grid_ui.items.Count, 0 );
			Assert.True( grid_ui.inventory.is_empty );
			grid_ui.add( baston);
			var new_item = grid_ui[ baston ];
			Assert.AreEqual( new_item.Count, 1 );
			Assert.True( grid_ui.inventory.is_not_empty );
			foreach( var i in new_item )
			{
				Assert.AreEqual( i.item.name, baston.name );
				Assert.AreEqual( i.item, baston );
			}
			yield return wait_second;
		}

		[UnityTest]
		public IEnumerator add_arco_should_have_one_item_in_the_list()
		{
			yield return min_wait;
			Assert.AreEqual( grid_ui.items.Count, 0 );
			Assert.True( grid_ui.inventory.is_empty );
			grid_ui.add( arco );
			var new_item = grid_ui[ arco ];
			Assert.AreEqual( new_item.Count, 1 );
			Assert.True( grid_ui.inventory.is_not_empty );
			foreach( var i in new_item )
			{
				Assert.AreEqual( i.item.name, arco.name );
				Assert.AreEqual( i.item, arco );
			}
			yield return wait_second;
		}
	}
}
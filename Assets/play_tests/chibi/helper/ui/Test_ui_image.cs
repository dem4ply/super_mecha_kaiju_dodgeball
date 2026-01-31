using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace tests.chibi_ui.image
{
	public class Test_ui_image : helper.tests.Scene_test
	{
		chibi.Chibi_ui ui;

		public override string scene_dir
		{
			get {
				return "tests/scene/chibi/helper/ui/chibi_ui_image";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			ui = helper.game_object.Find._<chibi.Chibi_ui>(
				scene, "with_image" );
		}

		[UnityTest]
		public IEnumerator should_have_image()
		{
			yield return this.min_wait;
			Assert.IsTrue( ui.ui.image.has );
			yield return this.min_wait;
		}

		[UnityTest]
		public IEnumerator when_start_should_not_have_temp_changes()
		{
			yield return this.min_wait;
			Assert.IsTrue( ui.ui.image.has_not_temp_change );
			Assert.IsFalse( ui.ui.image.has_temp_change );
			yield return this.min_wait;
		}

		[UnityTest]
		public IEnumerator when_change_transparency_should_change_color_component()
		{
			yield return this.min_wait;
			ui.ui.image.transparency = 0.5f;
			Assert.IsTrue( ui.ui.image.has_temp_change );
			Assert.AreEqual( ui.ui.image.component.color.a, 0.5f );
			yield return this.min_wait;
		}

		[UnityTest]
		public IEnumerator when_reset_should_return_color_to_origin()
		{
			yield return this.min_wait;
			var origin_color = ui.ui.image.component.color;
			ui.ui.image.transparency = 0.5f;
			yield return this.min_wait;
			ui.ui.image.reset();
			Assert.AreEqual( ui.ui.image.component.color.a, origin_color.a );
		}


		[UnityTest]
		public IEnumerator when_reset_should_not_have_temp_changes()
		{
			yield return this.min_wait;
			var origin_color = ui.ui.image.component.color;
			ui.ui.image.transparency = 0.5f;
			yield return this.min_wait;
			ui.ui.image.reset();
			Assert.IsTrue( ui.ui.image.has_not_temp_change );
			Assert.IsFalse( ui.ui.image.has_temp_change );
		}

		[UnityTest]
		public IEnumerator navegation_should_see_transparency()
		{
			yield return this.min_wait;
			var origin_color = ui.ui.image.component.color;
			ui.ui.image.transparency = 0.5f;
			yield return new WaitForSeconds( 2f );
			ui.ui.image.reset();
			yield return new WaitForSeconds( 2f );
		}
	}
}

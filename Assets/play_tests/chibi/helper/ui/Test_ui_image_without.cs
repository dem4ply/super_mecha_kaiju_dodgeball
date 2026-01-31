using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace tests.chibi_ui.image
{
	public class Test_ui_image_without: helper.tests.Scene_test
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
				scene, "without_image" );
		}

		[UnityTest]
		public IEnumerator should_not_have_image()
		{
			yield return this.min_wait;
			Assert.IsFalse( ui.ui.image.has );
		}
	}
}

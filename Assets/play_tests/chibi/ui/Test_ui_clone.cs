using System.Collections;
using helper;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace tests.chibi_ui.image
{
	public class Test_ui_clone : helper.tests.Scene_test
	{
		chibi.Chibi_ui panel;

		public override string scene_dir
		{
			get {
				return "tests/scene/chibi/ui/chibi_ui_clone";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			panel = helper.game_object.Find._<chibi.Chibi_ui>(
				scene, "panel image" );
		}

		[UnityTest]
		public IEnumerator should_work()
		{
			yield return this.min_wait;
			Assert.IsTrue( panel, "no se encontro el panel en la escena" );
		}

		[UnityTest]
		public IEnumerator should_have_children()
		{
			yield return this.min_wait;
			Assert.Greater( panel.transform.childCount, 0 );
			yield return this.min_wait;
		}

		[UnityTest]
		public IEnumerator when_clone_should_clone_childrens()
		{
			yield return this.min_wait;
			var clone_obj = panel.clone();
			Assert.AreEqual(
				clone_obj.transform.childCount,
				panel.transform.childCount );
			yield return this.min_wait;
		}

		[UnityTest]
		public IEnumerator when_clone_should_be_in_the_same_position()
		{
			yield return this.min_wait;
			var clone_obj = panel.clone();
			Assert.AreEqual(
				clone_obj.transform.position,
				panel.transform.position);
			yield return new WaitForSeconds( 1f );
		}

		[UnityTest]
		public IEnumerator clone_should_have_canvas_parent()
		{
			yield return this.min_wait;
			var clone_obj = panel.clone();
			Assert.AreEqual( clone_obj.transform.parent, clone_obj.canvas.transform );
			yield return new WaitForSeconds( 1f );
		}
	}
}

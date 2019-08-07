﻿using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using chibi.controller.npc;
using chibi.controller.ai;
using chibi.motor.npc;

namespace tests.controller.npc.side_scroll
{
	public class Collisions : helper.tests.Scene_test
	{
		Controller_npc controller;
		Ai_walk ai;

		public override string scene_dir
		{
			get {
				return
					"tests/scene/controller/motor/npc/" +
					"motor side scroll collisions";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();

			controller = helper.game_object.Find._< Controller_npc >( scene, "npc" );
			ai = helper.game_object.Find._< Ai_walk >( scene, "npc" );
		}

		[UnityTest]
		public IEnumerator should_be_grounded()
		{
			ai.desire_direction = Vector3.zero;
			yield return new WaitForSeconds( 1 );
			Assert.IsTrue( controller.motor_side_scroll.is_grounded );
		}

		[UnityTest]
		public IEnumerator should_no_be_grounded_if_in_air()
		{
			ai.desire_direction = Vector3.zero;
			yield return new WaitForSeconds( 0.05f );
			Assert.IsFalse( controller.motor_side_scroll.is_grounded );
		}

		[UnityTest]
		public IEnumerator should_no_be_walled_if_is_ony_grounded()
		{
			ai.desire_direction = Vector3.zero;
			yield return new WaitForSeconds( 1 );
			Assert.IsTrue( controller.motor_side_scroll.is_grounded );
			Assert.IsFalse( controller.motor_side_scroll.is_walled );
		}

		[UnityTest]
		public IEnumerator should_be_walled_if_hit_in_front()
		{
			ai.desire_direction = Vector3.forward;
			yield return new WaitForSeconds( 2.5f );
			Assert.IsTrue( controller.motor_side_scroll.is_walled );
			Assert.IsTrue( controller.motor_side_scroll.is_walled_right );
		}

		[UnityTest]
		public IEnumerator should_be_walled_if_hit_in_back()
		{
			ai.desire_direction = Vector3.back;
			yield return new WaitForSeconds( 2.5f );
			Assert.IsTrue( controller.motor_side_scroll.is_walled );
			Assert.IsTrue( controller.motor_side_scroll.is_walled_left );
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using rol_sheet;

namespace chibi.controller
{
	public class Tutorial_pause : Controller
	{
		bool time_is_pause = false;
		public fisher.controller.Push_start_controller controller;
		public string action_string;

		private void OnTriggerEnter( Collider other )
		{
			var controller = other.transform.GetComponentInParent<
				Controller_bullet>();
			if ( controller )
			{
				Time.timeScale = 0f;
				time_is_pause = true;
			}
		}

		private void OnCollisionEnter( Collision collision )
		{
		}

		private void Update()
		{
			if ( time_is_pause )
			{
				if ( Input.anyKey )
				{
					time_is_pause = false;
					Time.timeScale = 1f;
					controller.action_tutorial( action_string );
					Destroy( this.gameObject );
				}
			}
		}

		private void OnDrawGizmos()
		{
			BoxCollider cube = GetComponent<BoxCollider>();
			Gizmos.color = Color.black;
			Gizmos.DrawWireCube( transform.position, cube.size );
		}

		protected override void _init_cache()
		{
			// base._init_cache();
		}
	}
}

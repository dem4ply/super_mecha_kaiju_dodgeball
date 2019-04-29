using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using rol_sheet;

namespace chibi.controller
{
	public class Enable_tuto: Chibi_behaviour
	{
		public GameObject tuto;

		private void OnTriggerEnter( Collider other )
		{
			var controller = other.transform.GetComponentInParent<
				Controller_bullet>();
			if ( controller )
			{
				tuto.SetActive( true );
				Destroy( gameObject );
			}
		}

		private void OnDrawGizmos()
		{
			BoxCollider cube = GetComponent<BoxCollider>();
			Gizmos.color = Color.black;
			Gizmos.DrawWireCube( transform.position, cube.size );
		}
	}
}
